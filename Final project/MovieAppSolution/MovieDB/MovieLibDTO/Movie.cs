using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibDTO
{

    public class MovieDTO
    {
        // <copyright file="MovieDTO" company="Haute Ecole de la Province de Liège">
        // Copyright (c) 2016 All Rights Reserved
        // <author>Cécile Moitroux</author>
        // </copyright>


        private List<GenreDTO> _genreList;
        private List<DirectorDTO> _directorList;
        private List<ActorDTO> _actorList;

        private int _id;
        private string _title;
        private string _originalTitle;
        private int _runtime;
        private string _posterpath;

        public List<GenreDTO> GenreList
        {
            get
            {
                return _genreList;
            }

            set
            {
                _genreList = value;
            }
        }

        public List<DirectorDTO> DirectorList
        {
            get
            {
                return _directorList;
            }

            set
            {
                _directorList = value;
            }
        }

        public List<ActorDTO> ActorList
        {
            get
            {
                return _actorList;
            }

            set
            {
                _actorList = value;
            }
        }

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
            }
        }

        public string OriginalTitle
        {
            get
            {
                return _originalTitle;
            }

            set
            {
                _originalTitle = value;
            }
        }

        public int Runtime
        {
            get
            {
                return _runtime;
            }

            set
            {
                _runtime = value;
            }
        }

        public string Posterpath
        {
            get
            {
                return _posterpath;
            }

            set
            {
                _posterpath = value;
            }
        }

       
        // Préparation de la classe pour recevoir les données
        public MovieDTO()
        {
            GenreList = new List<GenreDTO>();
            DirectorList = new List<DirectorDTO>();
            ActorList = new List<ActorDTO>();
        }
    }

}
