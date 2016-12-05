using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using VideoLibBLL;
using VideoLibDAL;


namespace MovieServiceWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "VideothequeCheckService" in both code and config file together.
    public class VideothequeCheckService : IVideothequeCheckService
    {
        private VideoBLL bll = new VideoBLL();

        List<MovieDTO> IVideothequeCheckService.GetMovies()
        {
            return bll.GetMovies();
        }

       
    }
}