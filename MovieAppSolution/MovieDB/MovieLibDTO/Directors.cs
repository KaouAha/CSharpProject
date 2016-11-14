using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibDTO
{
    public class Directors
    {
        // <copyright file="Director" company="Haute Ecole de la Province de Liège">
        // Copyright (c) 2016 All Rights Reserved
        // <author>Cécile Moitroux</author>
        // </copyright>


        string[] _directorDetails;

        public string[] DirectorDetails
        {
            get
            {
                return _directorDetails;
            }

            set
            {
                _directorDetails = value;
            }
        }


        public Directors(string text)
        {
            Char[] delimiterChars = { '\u2016' };
            DirectorDetails = text.Split(delimiterChars);
        }        
    }
}
