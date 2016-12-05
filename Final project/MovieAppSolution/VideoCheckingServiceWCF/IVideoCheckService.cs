using MovieLibDTO;
using VideoLibDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace VideoCheckingServiceWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IVideoCheckService
    {
        [OperationContract]
        List<MovieDTO> allMovies();

        [OperationContract]
         List<MovieDTO> moviesRended();

        [OperationContract]
        List<MovieDTO> moviesExpired();

        [OperationContract]
         bool movieRended(string title);

        [OperationContract]
        List<MovieDTO> movieAbsoluteFree();

        [OperationContract]
        bool movieExist(string u);

        [OperationContract]
        List<OrderDTO> allOrders();


        [OperationContract]
        bool createOrder(string m, string u, DateTime? dt);

        [OperationContract]
        List<OrderDTO> ordersByUser(string name);

        [OperationContract]
        bool userExist(string u);

        [OperationContract]
        List<UserDTO> allUsers();



    }

}
