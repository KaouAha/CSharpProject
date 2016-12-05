﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VideoCheckingWPF.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IVideoCheckService")]
    public interface IVideoCheckService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoCheckService/allMovies", ReplyAction="http://tempuri.org/IVideoCheckService/allMoviesResponse")]
        MovieLibDTO.MovieDTO[] allMovies();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoCheckService/allMovies", ReplyAction="http://tempuri.org/IVideoCheckService/allMoviesResponse")]
        System.Threading.Tasks.Task<MovieLibDTO.MovieDTO[]> allMoviesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoCheckService/moviesRended", ReplyAction="http://tempuri.org/IVideoCheckService/moviesRendedResponse")]
        MovieLibDTO.MovieDTO[] moviesRended();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoCheckService/moviesRended", ReplyAction="http://tempuri.org/IVideoCheckService/moviesRendedResponse")]
        System.Threading.Tasks.Task<MovieLibDTO.MovieDTO[]> moviesRendedAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoCheckService/moviesExpired", ReplyAction="http://tempuri.org/IVideoCheckService/moviesExpiredResponse")]
        MovieLibDTO.MovieDTO[] moviesExpired();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoCheckService/moviesExpired", ReplyAction="http://tempuri.org/IVideoCheckService/moviesExpiredResponse")]
        System.Threading.Tasks.Task<MovieLibDTO.MovieDTO[]> moviesExpiredAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoCheckService/movieRended", ReplyAction="http://tempuri.org/IVideoCheckService/movieRendedResponse")]
        bool movieRended(string title);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoCheckService/movieRended", ReplyAction="http://tempuri.org/IVideoCheckService/movieRendedResponse")]
        System.Threading.Tasks.Task<bool> movieRendedAsync(string title);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoCheckService/movieAbsoluteFree", ReplyAction="http://tempuri.org/IVideoCheckService/movieAbsoluteFreeResponse")]
        MovieLibDTO.MovieDTO[] movieAbsoluteFree();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoCheckService/movieAbsoluteFree", ReplyAction="http://tempuri.org/IVideoCheckService/movieAbsoluteFreeResponse")]
        System.Threading.Tasks.Task<MovieLibDTO.MovieDTO[]> movieAbsoluteFreeAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoCheckService/movieExist", ReplyAction="http://tempuri.org/IVideoCheckService/movieExistResponse")]
        bool movieExist(string u);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoCheckService/movieExist", ReplyAction="http://tempuri.org/IVideoCheckService/movieExistResponse")]
        System.Threading.Tasks.Task<bool> movieExistAsync(string u);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoCheckService/allOrders", ReplyAction="http://tempuri.org/IVideoCheckService/allOrdersResponse")]
        VideoLibDTO.OrderDTO[] allOrders();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoCheckService/allOrders", ReplyAction="http://tempuri.org/IVideoCheckService/allOrdersResponse")]
        System.Threading.Tasks.Task<VideoLibDTO.OrderDTO[]> allOrdersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoCheckService/createOrder", ReplyAction="http://tempuri.org/IVideoCheckService/createOrderResponse")]
        bool createOrder(string m, string u, System.Nullable<System.DateTime> dt);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoCheckService/createOrder", ReplyAction="http://tempuri.org/IVideoCheckService/createOrderResponse")]
        System.Threading.Tasks.Task<bool> createOrderAsync(string m, string u, System.Nullable<System.DateTime> dt);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoCheckService/ordersByUser", ReplyAction="http://tempuri.org/IVideoCheckService/ordersByUserResponse")]
        VideoLibDTO.OrderDTO[] ordersByUser(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoCheckService/ordersByUser", ReplyAction="http://tempuri.org/IVideoCheckService/ordersByUserResponse")]
        System.Threading.Tasks.Task<VideoLibDTO.OrderDTO[]> ordersByUserAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoCheckService/userExist", ReplyAction="http://tempuri.org/IVideoCheckService/userExistResponse")]
        bool userExist(string u);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoCheckService/userExist", ReplyAction="http://tempuri.org/IVideoCheckService/userExistResponse")]
        System.Threading.Tasks.Task<bool> userExistAsync(string u);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoCheckService/allUsers", ReplyAction="http://tempuri.org/IVideoCheckService/allUsersResponse")]
        VideoLibDTO.UserDTO[] allUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoCheckService/allUsers", ReplyAction="http://tempuri.org/IVideoCheckService/allUsersResponse")]
        System.Threading.Tasks.Task<VideoLibDTO.UserDTO[]> allUsersAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IVideoCheckServiceChannel : VideoCheckingWPF.ServiceReference1.IVideoCheckService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class VideoCheckServiceClient : System.ServiceModel.ClientBase<VideoCheckingWPF.ServiceReference1.IVideoCheckService>, VideoCheckingWPF.ServiceReference1.IVideoCheckService {
        
        public VideoCheckServiceClient() {
        }
        
        public VideoCheckServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public VideoCheckServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VideoCheckServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VideoCheckServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public MovieLibDTO.MovieDTO[] allMovies() {
            return base.Channel.allMovies();
        }
        
        public System.Threading.Tasks.Task<MovieLibDTO.MovieDTO[]> allMoviesAsync() {
            return base.Channel.allMoviesAsync();
        }
        
        public MovieLibDTO.MovieDTO[] moviesRended() {
            return base.Channel.moviesRended();
        }
        
        public System.Threading.Tasks.Task<MovieLibDTO.MovieDTO[]> moviesRendedAsync() {
            return base.Channel.moviesRendedAsync();
        }
        
        public MovieLibDTO.MovieDTO[] moviesExpired() {
            return base.Channel.moviesExpired();
        }
        
        public System.Threading.Tasks.Task<MovieLibDTO.MovieDTO[]> moviesExpiredAsync() {
            return base.Channel.moviesExpiredAsync();
        }
        
        public bool movieRended(string title) {
            return base.Channel.movieRended(title);
        }
        
        public System.Threading.Tasks.Task<bool> movieRendedAsync(string title) {
            return base.Channel.movieRendedAsync(title);
        }
        
        public MovieLibDTO.MovieDTO[] movieAbsoluteFree() {
            return base.Channel.movieAbsoluteFree();
        }
        
        public System.Threading.Tasks.Task<MovieLibDTO.MovieDTO[]> movieAbsoluteFreeAsync() {
            return base.Channel.movieAbsoluteFreeAsync();
        }
        
        public bool movieExist(string u) {
            return base.Channel.movieExist(u);
        }
        
        public System.Threading.Tasks.Task<bool> movieExistAsync(string u) {
            return base.Channel.movieExistAsync(u);
        }
        
        public VideoLibDTO.OrderDTO[] allOrders() {
            return base.Channel.allOrders();
        }
        
        public System.Threading.Tasks.Task<VideoLibDTO.OrderDTO[]> allOrdersAsync() {
            return base.Channel.allOrdersAsync();
        }
        
        public bool createOrder(string m, string u, System.Nullable<System.DateTime> dt) {
            return base.Channel.createOrder(m, u, dt);
        }
        
        public System.Threading.Tasks.Task<bool> createOrderAsync(string m, string u, System.Nullable<System.DateTime> dt) {
            return base.Channel.createOrderAsync(m, u, dt);
        }
        
        public VideoLibDTO.OrderDTO[] ordersByUser(string name) {
            return base.Channel.ordersByUser(name);
        }
        
        public System.Threading.Tasks.Task<VideoLibDTO.OrderDTO[]> ordersByUserAsync(string name) {
            return base.Channel.ordersByUserAsync(name);
        }
        
        public bool userExist(string u) {
            return base.Channel.userExist(u);
        }
        
        public System.Threading.Tasks.Task<bool> userExistAsync(string u) {
            return base.Channel.userExistAsync(u);
        }
        
        public VideoLibDTO.UserDTO[] allUsers() {
            return base.Channel.allUsers();
        }
        
        public System.Threading.Tasks.Task<VideoLibDTO.UserDTO[]> allUsersAsync() {
            return base.Channel.allUsersAsync();
        }
    }
}
