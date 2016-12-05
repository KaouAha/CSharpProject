using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibDAL
{
    public class InsertDAL
    {
        MoviesDBDataContext _DB = null;
        private static DAL _instance;

        private DAL()
        {
            _DB = new VideoDBDataContext();
        }


        public static DAL getInstance()
        {
            return _instance ?? (_instance = new DAL());
        }

        public void InsertAllAfterMoves()
        {
            List<MovieDetailsDTO> moviesList = this.GetAllMovies();

            moviesList
            //Insert genres

            //Insert actors

            //Insert directors

        }
    }
}
