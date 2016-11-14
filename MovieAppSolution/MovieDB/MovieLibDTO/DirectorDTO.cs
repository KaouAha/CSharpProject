using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibDTO
{
    public class DirectorDTO
    {
        // <copyright file="DirectorDTO" company="Haute Ecole de la Province de Liège">
        // Copyright (c) 2016 All Rights Reserved
        // <author>Cécile Moitroux</author>
        // </copyright>


        private int _id;
        private string _name;

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

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public DirectorDTO()
        {
        }

        public DirectorDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public DirectorDTO(string text)
        {
            string[] genreDetails;
            Char[] delimiterChars = { '\u201E' };

            genreDetails = text.Split(delimiterChars);
            Id = Int32.Parse(genreDetails[0]);
            Name = genreDetails[1];
        }
    }
}
