using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibDAL;
namespace VideoLibBLL
{
    public class VideoBLL
    {
        public DAL dal {get; set;}
        public VideoBLL()
        {
            dal = DAL.getInstance();
        }
        /*********************************************************************************
                                        BLL FOR MOVIES
        **********************************************************************************/

        // Display  films
        public List<MovieDTO> allMovies()
        {

            return dal.GetMovies();
        }


        // Display movie rended
        public List<MovieDTO> moviesRended()
        {
            return dal.MovieRended();

        }

        // Display movie expired
       public List<MovieDTO> movieRended()
        {
            return dal.MovieExpired();

        }


        // Check if a movie is rended
        public bool movieRended(string title)
        {
            MovieDTO mdt = new MovieDTO();
            mdt.Title = title;
            if (dal.movieExist(mdt))
                return dal.MovieRended(title);

            else
                throw new ExceptionBLL("Error movie doesn't exist in data base please check spelling");
        

        }

        //
        public List<MovieDTO> movieAbsoluteFree()
        {
            return dal.MovieAbsoluteFree();
        }

        public List<MovieDTO> MovieRended()
        {
            return dal.MovieRended();

        }

        // Check if movie exist
        public bool movieExist(string u)
        {
            MovieDTO udt = new MovieDTO();
            udt.Title = u;
            return dal.movieExist(udt);


        }

        /*********************************************************************************
                                        BLL FOR ORDER
        ********************************************************************************/


        // Display  Orders
        public List<OrderDTO> allOrders()
        {
            return dal.getOrders();
        }

        // Display Orders by user
        public List<OrderDTO> ordersByUser(string name)
        {
            UserDTO udt = new UserDTO();
            udt.Name = name;

            if (dal.userExist(udt))
                return    dal.OrdersByUser(name);
            else
                throw new ExceptionBLL("Error user doesn't exist in data base please check spelling");

        }
        // Create a new order 
        public bool createOrder(string m, string u, DateTime? dt)
        {

            MovieDTO mdt = new MovieDTO(m, null, 0);
            UserDTO udt = new UserDTO(u, null, null);



            //verify movie exists
            if (dal.movieExist(mdt) && dal.userExist(udt))
            {
                // verify movie is enable
                if (!dal.MovieRended(mdt.Title))
                {
                    dal.InsertOrder(mdt, udt, dt);
                    return true;

                }
                else
                    throw new ExceptionBLL("Error Movie is not avaible");

            }
            else
                 throw new ExceptionBLL("Error movie or user doesnt exist");

        }


      /*********************************************************************************
                                      BLL FOR USER
      ********************************************************************************/

        public bool userExist(string u)
        {

            UserDTO udt = new UserDTO();
            udt.Name = u;
            return dal.userExist(udt);


        }

        public List<UserDTO> allUsers()
        {
           List<UserDTO> ud= dal.getUsers();


            if (ud.Count > 1000)
            {
                for (int i = 1000; i < ud.Count; i++)
                    ud.RemoveAt(i);
            }
            return ud;

                  

        }
    }
}
