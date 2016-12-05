using MovieLibDTO;
using MovieMgmtDB;
using System;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace MovieMgmtDB
{
    public class MovieManagerDB
    {
        // <copyright file="MovieManagerDB" company="Haute Ecole de la Province de Liège">
        // Copyright (c) 2016 All Rights Reserved
        // <author>Cécile Moitroux</author>
        // </copyright>


        MovieDBDataClassesDataContext _context = null;
        private static MovieManagerDB _instance;

        private MovieManagerDB(String servername, String dbname)
        {
            if (dbname == null || dbname == "")
                _context = new MovieDBDataClassesDataContext();
            else
            {
                String connectionstring = "Data Source = " + servername + " ; Initial Catalog =" + dbname + "; Integrated Security = True";
                _context = new MovieDBDataClassesDataContext (connectionstring);
                //Verifying if the database exists and if so doesn't create it 
                if (!_context.DatabaseExists()) 
                    _context.CreateDatabase();   
            }
        }


        public static MovieManagerDB singleton(String servername, String dbname)
        {
            return _instance ?? (_instance = new MovieManagerDB(servername, dbname));
        }

        public bool add<T>(T rec, Func<T,bool> expr) where T : class
        {
            if (_context == null)
                throw new Exception("DAL not connected");
            try
            {
                // Query qui permet d'accéder à l'ensemble des objets d'une table dont le type est passé en paramètre
                IQueryable<T> query = ((Table<T>)_context.GetType().GetProperty(typeof(T).Name + "s").GetValue(_context));
                if(!query.Where(expr).Any()) // Vérifie sur base de l'expression que aucun objet ne correspond au critère de recherche
                {
                    ((Table<T>)_context.GetType().GetProperty(typeof(T).Name + "s").GetValue(_context)).InsertOnSubmit(rec);
                    _context.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool add<T,String,Q> (T rec, string sid) where T : class
        {
            if (_context == null)
                throw new Exception("DAL not connected");
            try
            {
                var valeur = rec.GetType().GetProperty(sid).GetValue(rec);
                IQueryable<T> query = ((Table<T>)_context.GetType().GetProperty(typeof(T).Name + "s").GetValue(_context));
                query = simplified<T,Q>(query, sid, (Q)valeur);
                if (query.Count() == 0)
                {
                    ((Table<T>)_context.GetType().GetProperty(typeof(T).Name + "s").GetValue(_context)).InsertOnSubmit(rec);
                    _context.SubmitChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        static IQueryable<T> simplified<T,Q>(IQueryable<T> query, string propertyName, Q propertyValue)
        {
            PropertyInfo propertyInfo = typeof(T).GetProperty(propertyName);
            return simplified<T,Q>(query, propertyInfo, propertyValue);
        }

        static IQueryable<T> simplified<T,Q>(IQueryable<T> query, PropertyInfo propertyInfo, Q propertyValue)
        {
            ParameterExpression e = Expression.Parameter(typeof(T), "e");
            MemberExpression m = Expression.MakeMemberAccess(e, propertyInfo);
            ConstantExpression c = Expression.Constant(propertyValue, propertyValue.GetType());
            BinaryExpression b = Expression.Equal(m, c);

            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(b, e);
            return query.Where(lambda);
        }


        #region GENRES
        public bool addGenre(GenreDTO g)
        {
            Genre newg = new Genre
            {
                id = g.Id,
                name = g.Name
            };
            //return add<Genre,String,int>(newg,"id");
            return add<Genre>(newg, xg => xg.id == g.Id);
        }

        public void addGenreRelation(MovieDTO Movie, GenreDTO g)
        {
            MovieGenre newmg = new MovieGenre
            {
                id = 0,
                id_Movie = Movie.Id,
                id_genre = g.Id
            };
            add<MovieGenre>(newmg, xg => xg.id == g.Id);
        }

        public bool addGenre(int _id, string _name)
        {
            // On vérifie si le genre n'a pas déjà été enregistré ds la BD
            var gen = from d in _context.Genres
                      where _id == d.id
                      select d;
            if (gen.Count() == 0)
            {
                Genre g = new Genre
                {
                    id = _id,
                    name = _name
                };

                // add the new object to the Orders collection.
                _context.Genres.InsertOnSubmit(g);

                // Submit the change to the database.
                try
                {
                    _context.SubmitChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    // Make some adjustments.
                    // ...
                    // Try again.
                    //_context.SubmitChanges();
                    return false;
                }
            }
            else
                return true;
        } // non utilisé
        #endregion

        #region DIRECTOR
        public void addDirectorRelation(MovieDTO movie, DirectorDTO d)
        {
            MovieDirector newdr = new MovieDirector
            {
                id = 0,
                id_Movie = movie.Id,
                id_Director = d.Id
            };
            add<MovieDirector>(newdr, xg => xg.id == d.Id);
        }

        public bool addDirector(DirectorDTO d)
        {
            Director newd = new Director
            {
                id = d.Id,
                name = d.Name
            };
            return add<Director>(newd, xg => xg.id == d.Id);
        }

        public bool addDirector(int id, string name) //non utilisé
        {
            // On vérifie si le genre n'a pas déjà été enregistré ds la BD
            var rea = from d in _context.Directors
                      where id == d.id
                      select d;
            if (rea.Count() == 0)
            {
                Director g = new Director
                {
                    id = id,
                    name = name
                };

                // add the new object to the Orders collection.
                _context.Directors.InsertOnSubmit(g);

                // Submit the change to the database.
                try
                {
                    _context.SubmitChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    // Make some adjustments.
                    // ...
                    // Try again.
                    //_context.SubmitChanges();
                    return false;
                }
            }
            else
                return true;
        }
        #endregion

        #region ACTOR
        public bool addActor(ActorDTO a)
        {
            Actor newa = new Actor
            {
                id = a.Id,
                name = a.Name,
                character = a.Character
            };
            return add(newa, xg => xg.id == a.Id);
        }

        public void addActorRelation(MovieDTO movie, ActorDTO a)
        {
            MovieActor newfa = new MovieActor
            {
                id = 0,
                id_Movie = movie.Id,
                id_actor = a.Id
            };
            add<MovieActor>(newfa, xg => xg.id == a.Id);
        }       

        public bool addActor(int _id, string _name, string _character)
        {
            // On vérifie si l'acteur et son personnage n'a pas déjà été enregistré ds la BD
            var act = from d in _context.Actors
                      where _id == d.id
                      select d;
            if (act.Count() == 0)
            {
                Actor a = new Actor
                {
                    id = _id,
                    name = _name,
                    character = _character
                };

                // add the new object to the Orders collection.
                _context.Actors.InsertOnSubmit(a);

                // Submit the change to the database.
                try
                {
                    _context.SubmitChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    // Make some adjustments.
                    // ...
                    // Try again.
                    //_context.SubmitChanges();
                    return false;
                }
            }
            else
                return true;
        } //non utilisé

        #endregion

        #region Movie
        public bool addMovie(MovieDTO m)
        {
            Movie newf = new Movie
            {
                id = m.Id,
                title = m.Title,
                original_title = m.OriginalTitle,
                runtime = m.Runtime,
                posterpath = m.Posterpath
            };
            return add<Movie>(newf, xg => xg.id == newf.id);
        }

        public bool addMovie(int _id, string _title, string _originaltitle, int _runtime, string _posterpath)
        {
            // On vérifie si le movie n'a pas déjà été enregistré ds la BD
            var movies = from f in _context.Movies
                      where _id == f.id
                      select f;
            if (movies.Count() == 0)
            {
                Movie m = new Movie
                {
                    id = _id,
                    title = _title,
                    original_title = _originaltitle,
                    runtime = _runtime,
                    posterpath = _posterpath
                };

                // add the new object to the Orders collection.
                _context.Movies.InsertOnSubmit(m);

                // Submit the change to the database.
                try
                {
                    _context.SubmitChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    // Make some adjustments.
                    // ...
                    // Try again.
                    //_context.SubmitChanges();
                    return false;
                }
            }
            else
                return true;     
        }
        #endregion
    }
}
