using MovieLibDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using VideoLibBLL;
using VideoLibDTO;

namespace VideoCheckingServiceWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class VideoCheckService : IVideoCheckService
    {

        public MovieMgmtBLL BLLMovie { get; set; }
        public OrderMgmtBLL BLLOrder { get; set; }
        public UserMgmtBLL BLLUser { get; set; }


        public VideoCheckService()
        {
            BLLMovie = MovieMgmtBLL.getInstance();
            BLLOrder = OrderMgmtBLL.getInstance();
            BLLUser= UserMgmtBLL.getInstance();
        }


       /*********************************************************************************
                                      MOVIES
      **********************************************************************************/

        List<MovieDTO> IVideoCheckService.allMovies()
        {
            return BLLMovie.allMovies();
        }

        List<MovieDTO> IVideoCheckService.moviesRended()
        {
            return BLLMovie.moviesRended();
        }

        List<MovieDTO> IVideoCheckService.moviesExpired()
        {
            return BLLMovie.movieRended();
        }

        public bool movieRended(string title)
        {
            return BLLMovie.movieRended( title);
        }


        public List<MovieDTO> movieAbsoluteFree()
        {
            return BLLMovie.movieAbsoluteFree();
        }

        public bool movieExist(string u)
        {
           return BLLMovie.movieExist(u);
        }


        /*********************************************************************************
                                 ORDER
        ********************************************************************************/
        public List<OrderDTO> allOrders()
        {

            return BLLOrder.allOrders();
        }

        public bool createOrder(string m, string u, DateTime? dt)
        {
            return BLLOrder.createOrder(m, u, dt);

        }

        public List<OrderDTO> ordersByUser(string name)
        {
            return BLLOrder.ordersByUser(name);

        }



        /*********************************************************************************
                                    USER
      ********************************************************************************/
        public bool userExist(string u)
        {
            return BLLUser.userExist(u);
        }

        public List<UserDTO> allUsers()
        {
            return BLLUser.allUsers();
        }
    }
}
