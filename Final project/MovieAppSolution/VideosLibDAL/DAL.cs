using MovieLibDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibDTO;

namespace VideosLibDAL
{
    public class DAL
    {
        VideoDBDataContext _DB = null;
        private static DAL _instance;

        private DAL()
        {
            _DB = new VideoDBDataContext();
        }


        public static DAL getInstance()
        {
            return _instance ?? (_instance = new DAL());
        }


        /*********************************************************************************
                                        DAL FOR MOVIES
        ********************************************************************************/

        //List of all the movies with the details
        public List<MovieDetailsDTO> GetAllMovies()
        {
            List<MovieDetailsDTO> movies = (from movie in _DB.Movies
                                            select new MovieDetailsDTO()).ToList();
            return movies;
        }

        //List of all the movies by genre
        public List<MovieDetailsDTO> GetMoviesByGenre(int? genreId)
        {
            List<MovieDetailsDTO> moviesByGenre = (from movie in _DB.Movies
                                                   where (from mg in _DB.MovieGenres
                                                          where mg.id_genre == genreId
                                                          select mg.id_Movie).Contains(movie.id)
                                                   select new MovieDetailsDTO()).ToList();
            return moviesByGenre;
        }

        //List of all the movies by title
        public MovieDetailsDTO GetMovieByTitle(string title)
        {
            MovieDetailsDTO movieByTitle = (from movie in _DB.Movies
                                            where movie.title == title
                                            select new MovieDetailsDTO()).First();

            return movieByTitle;

        }

        //List of all the movies by the id of the movie
        public MovieDetailsDTO GetMovieByTitleId(int? movieId)
        {
            List<MovieDetailsDTO> movieByTitle = (from movie in _DB.Movies
                                                  where movie.id == movieId
                                                  select new MovieDetailsDTO()).ToList();

            return movieByTitle.First();

        }

        //List of all the genres
        public List<GenreDTO> GetAllGenres()
        {
            List<GenreDTO> genresList = (from genre in _DB.Genres
                                         select new GenreDTO()).ToList();
            return genresList;
        }


        //List of movies
        public List<MovieDTO> GetMovies()
        {
            IEnumerable<MovieDTO> movies = (from m in _DB.Movies
                                            select new MovieDTO()
                                            {
                                                Title = m.title,
                                                OriginalTitle = m.original_title,
                                                Runtime = m.runtime
                                            });

            return movies.ToList();
        }

        // Display state of movie
        public List<MovieDTO> MovieExpired()
        {
            IEnumerable<MovieDTO> queryOder = (from o in _DB.Orders
                                               join m in _DB.Movies on o.idMovie equals m.id
                                               where o.endDate < DateTime.Now
                                               select new MovieDTO()
                                               {
                                                   Title = m.title,
                                                   endDate = o.endDate,
                                                   OriginalTitle = m.original_title,
                                                   Runtime = m.runtime,
                                               });


            return queryOder.ToList<MovieDTO>();
        }
        //f
        public List<MovieDTO> MovieAbsoluteFree()
        {
            var query = from mo in _DB.Movies
                        where !(from o in _DB.Orders
                                join m in _DB.Movies on o.idMovie equals m.id
                                where o.endDate > DateTime.Now
                                select m.id)
                               .Contains(mo.id)
                        select new MovieDTO()
                        {
                            Title = mo.title,
                            endDate = null,
                            OriginalTitle = mo.original_title,
                            Runtime = mo.runtime,
                        };

            return query.ToList<MovieDTO>();
        }

        // Display state of movie
        public List<MovieDTO> MovieRended()
        {
            var queryOder = (from o in _DB.Orders
                             join m in _DB.Movies on o.idMovie equals m.id
                             where o.endDate > DateTime.Now
                             select new MovieDTO()
                             {
                                 Title = m.title,
                                 endDate = o.endDate,
                                 OriginalTitle = m.original_title,
                                 Runtime = m.runtime,
                             });
            return queryOder.ToList<MovieDTO>();
        }

        // Display state of movie
        public bool MovieRended(string movieName)
        {
            var movie = (from m in _DB.Movies
                         where m.title == movieName
                         select m).First();
            int idMovie = movie.id;


            return _DB.Orders.Any(m => m.idMovie == idMovie && m.endDate <= DateTime.Now);


        }

        // Check if movie exist in database
        public bool movieExist(MovieDTO mdt)
        {

            return _DB.Movies.Any(m => m.title == mdt.Title);

        }

        /*********************************************************************************
                                        DAL FOR ORDERS
        ********************************************************************************/
        public List<OrderDTO> getOrders()
        {
            var orders = (from u in _DB.Users
                          join ou in _DB.OrderUsers on u.Id equals ou.idUser
                          join o in _DB.Orders on ou.idOrder equals o.Id
                          join m in _DB.Movies on o.idMovie equals m.id
                          select new OrderDTO(o.endDate, m.title, u.name));
            return orders.ToList<OrderDTO>();
        }


        //Insert new Order
        public bool InsertOrder(MovieDTO md, UserDTO ud, DateTime? dt)
        {
            var queryMovie = (from m in _DB.Movies
                              where m.title == md.Title
                              select m);
            Movie movie = queryMovie.FirstOrDefault();


            var queryUser = (from m in _DB.Users
                             where m.name == ud.Name
                             select m);
            User user = queryUser.First();


            Order order = new Order();
            order.Movie = movie;
            order.endDate = dt;


            OrderUser ou = new OrderUser();
            //ou.User = user;
            ou.Order = order;


            _DB.Orders.InsertOnSubmit(order);

            _DB.OrderUsers.InsertOnSubmit(ou);



            try
            {
                this._DB.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exeption caught " + e.Message);
                return false;

            }


        }


        // Display list of orders for one user
        public List<OrderDTO> OrdersByUser(string uname)
        {
            var user = (from m in _DB.Users
                        where m.name == uname
                        select m).First();
            int idUser = user.Id;

            var queryOder = (from o in _DB.Orders
                             join uo in _DB.OrderUsers on o.Id equals uo.idOrder
                             join m in _DB.Movies on o.idMovie equals m.id
                             where uo.idUser == idUser
                             select new OrderDTO()
                             {
                                 EndDate = o.endDate,
                                 movieName = m.title,
                                 userName = uname

                             });
            return queryOder.ToList<OrderDTO>();
        }


        /*********************************************************************************
                                        DAL FOR USERS
        ********************************************************************************/

        // Check if  exist in database
        public bool userExist(UserDTO udt)
        {

            return _DB.Users.Any(m => m.name == udt.Name);

        }
        public List<UserDTO> getUsers()
        {
            var users = (from u in _DB.Users

                         select new UserDTO()
                         {
                             Address = u.address,
                             Name = u.name,
                             Sex = u.sex
                         });


            return users.ToList<UserDTO>();
        }
    }
}
