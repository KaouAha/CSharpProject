using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibDTO
{
    public class ActorDTO
    {
        // <copyright file="ActorDTO" company="Haute Ecole de la Province de Liège">
        // Copyright (c) 2016 All Rights Reserved
        // <author>Cécile Moitroux</author>
        // </copyright>


        private int _id;
        private string _name;
        private string _character;

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

        public string Character
        {
            get
            {
                return _character;
            }

            set
            {
                _character = value;
            }
        }


        public ActorDTO(int id, string name, string character)
        {
            Id = id;
            Name = name;
            Character = character;
        }

        public ActorDTO(string text)
        {
            string[] actorDetails, characterdDetails;
            string tmp;
            Char[] delimiterChars = { '\u201E' };

            actorDetails = text.Split(delimiterChars);
            Id = Int32.Parse(actorDetails[0]);
            Name = actorDetails[1];

            delimiterChars[0] = '/';

            if (actorDetails.Length > 2)
            {
                tmp = actorDetails[2];
                characterdDetails = tmp.Split(delimiterChars);
                Character = characterdDetails[0];
            }
            else
            {
                Character = "NO DETAILS FOR CHARACTER";
            }
        }
    }
}
