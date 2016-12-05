using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibDTO
{
    public class RelationDTO
    {
        // <copyright file="RelationDTO" company="Haute Ecole de la Province de Liège">
        // Copyright (c) 2016 All Rights Reserved
        // <author>Cécile Moitroux</author>
        // </copyright>


        private int _id;
        private int _idMovie;
        private int _idOther;

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

        public int IdMovie
        {
            get
            {
                return _idMovie;
            }

            set
            {
                _idMovie = value;
            }
        }

        public int IdOther
        {
            get
            {
                return _idOther;
            }

            set
            {
                _idOther = value;
            }
        }


        public RelationDTO()
        {
        }

        public RelationDTO(int id, int idMovie, int idOther)
        {
            Id = id;
            IdMovie = idMovie;
            IdOther = idOther;
        }
    }
}
