using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibDTO
{
    class Genres
    {
        // <copyright file="Genres" company="Haute Ecole de la Province de Liège">
        // Copyright (c) 2016 All Rights Reserved
        // <author>Cécile Moitroux</author>
        // </copyright>

        string[] _genreDetails;

        public string[] GenreDetails
        {
            get
            {
                return _genreDetails;
            }

            set
            {
                _genreDetails = value;
            }
        }


        public Genres(string text)
        {
            Char[] delimiterChars = { '\u2016' };

            GenreDetails = text.Split(delimiterChars);
        }

    }
}
