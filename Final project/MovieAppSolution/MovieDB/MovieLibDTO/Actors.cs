using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibDTO
{  
    public class Actors
    {
        // <copyright file="Actors" company="Haute Ecole de la Province de Liège">
        // Copyright (c) 2016 All Rights Reserved
        // <author>Cécile Moitroux</author>
        // </copyright>


        string[] _actorDetails;

        public string[] ActorDetails
        {
            get
            {
                return _actorDetails;
            }

            set
            {
                _actorDetails = value;
            }
        }


        public Actors(string text)
        {
            Char[] delimiterChars = { '\u2016' };
            ActorDetails = text.Split(delimiterChars);
        }
    }
}
