using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibDTO
{
    public class MovieText
    {
        // <copyright file="MovieText" company="Haute Ecole de la Province de Liège">
        // Copyright (c) 2016 All Rights Reserved
        // <author>Cécile Moitroux</author>
        // </copyright>


        private string[] _movieDetailsWords;
        private string[] _genres;
        private string[] _directors;
        private string[] _actors;

        //private MovieDTO _movie;
        private int _log;

        public string[] MovieDetailsWords
        {
            get
            {
                return _movieDetailsWords;
            }

            set
            {
                _movieDetailsWords = value;
            }
        }


        public MovieText()
        {
        }

        public MovieDTO decodeMovieText(string movieText)
        {
            try
            {
                MovieDTO f = new MovieDTO();

                Char[] delimiterChars = { '\u2059' };
                MovieDetailsWords = movieText.Split(delimiterChars);
                delimiterChars[0] = '\u2016';

                // Initialisation des champs de base du film
                f.Id = Int32.Parse(MovieDetailsWords[0]);
                f.Title = MovieDetailsWords[1];
                f.OriginalTitle = MovieDetailsWords[1];

                if (!String.IsNullOrEmpty(MovieDetailsWords[7]))
                    f.Runtime = Int32.Parse(MovieDetailsWords[7]);
                else
                    f.Runtime = -1;
                f.Posterpath = MovieDetailsWords[9];

                // Initialisation des champs détails du film
                if (MovieDetailsWords.Length == 15)
                {
                    _genres = MovieDetailsWords[12].Split(delimiterChars);
                    foreach (string s in _genres)
                    {
                        if (s.Length > 0)
                            f.GenreList.Add(new GenreDTO(s));
                    }
                    _directors = MovieDetailsWords[13].Split(delimiterChars);
                    foreach (string s in _directors)
                    {
                        if (s.Length > 0)
                            f.DirectorList.Add(new DirectorDTO(s));
                    }
                    _actors = MovieDetailsWords[14].Split(delimiterChars);
                    foreach (string s in _actors)
                        if (s.Length > 0)
                            f.ActorList.Add(new ActorDTO(s));
                }
                return f;
            }
            catch (Exception ex)
            {
                _log++;
                Console.WriteLine(ex + "Error");
                return null;
            }

        }

    }
}
