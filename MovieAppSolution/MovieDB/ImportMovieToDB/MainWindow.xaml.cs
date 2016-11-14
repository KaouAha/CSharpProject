using MovieMgmtDB;
using MovieLibDTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImportMovieToDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // <copyright file="MainWindow" company="Haute Ecole de la Province de Liège">
        // Copyright (c) 2016 All Rights Reserved
        // <author>Cécile Moitroux</author>
        // </copyright>


        private StreamReader _movie = null;
        private MovieManagerDB _dbman = null;
        private string _line;


        public MainWindow()
        {
            InitializeComponent();            
        }


        private void importWindowLoaded(object sender, RoutedEventArgs e)
        {
            // Open file to read it
            //_movie = new StreamReader(@"C:\Data\OneDrive\HEPL 2016-2017\B2 3 INFO SYST GEST Prog .NET\Lecture DB\ImportMovieToDB\movies.txt");            
            _movie = new StreamReader(@"C:\Users\kaou-\Documents\Cours\C#\C# project\movies\movies.txt");            
        }

        private void windowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Close file
            _movie.Close();
        }

        private void databaseOpenClick(object sender, RoutedEventArgs e)
        {
            _dbman = MovieManagerDB.singleton(Servername.Text, DBname.Text);
            if (_dbman != null)
            {
                readline.IsEnabled = true;
                openDB.IsEnabled = false;
                Servername.IsEnabled = false;
                DBname.IsEnabled = false;
            }
        }

        private void readlineClick(object sender, RoutedEventArgs e)
        {
            readAndDecodeline();
        }

        private bool readAndDecodeline()
        {
            _line = _movie.ReadLine();

            if (_line == null)
                return false;

            movieFullData.Text = _line;

            // Create movie object
            MovieText filmtext = new MovieText();
            MovieDTO movie = filmtext.decodeMovieText(_line);

            // User GUI updating
            if(movie == null)
            {
                filmdetaildata.Text = "Error not found ";
                return false;
            }
            movieDisplay(filmtext, movie);

            // Enregistrement des données du movie dans la base de données uniquement si la longueur du titre est < à 100 char
            if (movie.Title.Length <= 100)
                SaveFilmToDataBase(movie);

            return true;
        }

        private void SaveFilmToDataBase(MovieDTO film)
        {
            foreach (GenreDTO g in film.GenreList)                 _dbman.addGenre(g);
            foreach (DirectorDTO r in film.DirectorList)     _dbman.addDirector(r);
            foreach (MovieLibDTO.ActorDTO a in film.ActorList) _dbman.addActor(a);
            _dbman.addMovie(film);
            foreach (GenreDTO g in film.GenreList)              _dbman.addGenreRelation(film,g);
            foreach (DirectorDTO r in film.DirectorList)  _dbman.addDirectorRelation(film,r);
            foreach (MovieLibDTO.ActorDTO a in film.ActorList) _dbman.addActorRelation(film, a);
        }

        private void movieDisplay(MovieText filmtext, MovieDTO film)
        {
            // Affichage de la ligne lue dans la textbox
            filmdetaildata.Text = "";
            foreach (string s in filmtext.MovieDetailsWords)
                filmdetaildata.Text += s + "\n";
            // Affichage des Genres décodés
            filmdetaildata.Text += "GENRES\n";
            foreach (GenreDTO g in film.GenreList)
            {
                filmdetaildata.Text += "\t" + g.Id + "\t" + g.Name + "\n";
            }
            // Affichage des Réalisateurs décodés
            filmdetaildata.Text += "REALISATEURS\n";
            foreach (DirectorDTO r in film.DirectorList)
            {
                filmdetaildata.Text += "\t" + r.Id + "\t" + r.Name + "\n";
            }
            // Affichage des ActorDTO décodés
            filmdetaildata.Text += "ACTEURS\n";
            foreach (MovieLibDTO.ActorDTO a in film.ActorList)
            {
                filmdetaildata.Text += "\t" + a.Id + "\t" + a.Name + "\t" + a.Character + "\n";
            }
        }

        private void CountLine_Click(object sender, RoutedEventArgs e)
        {
            _movie.Close();
            //_movie = new StreamReader(@"C:\Data\OneDrive\HEPL 2016-2017\B2 3 INFO SYST GEST Prog .NET\Lecture DB\ImportMovieToDB\movies.txt");
            _movie = new StreamReader(@"C:\Users\kaou-\Documents\Cours\C#\C# project\movies\movies.txt");
            int i = 0;
            do
            {
                _line = _movie.ReadLine();
                if (i % 100 == 0)
                    i++;
                movieFullData.Text = i.ToString();
            }
            while (_line != null);
            movieFullData.Text = i.ToString();

            _movie.Close();
            //_movie = new StreamReader(@"C:\Data\OneDrive\HEPL 2016-2017\B2 3 INFO SYST GEST Prog .NET\Lecture DB\ImportMovieToDB\movies.txt");
            _movie = new StreamReader(@"C:\Users\kaou-\Documents\Cours\C#\C# project\movies\movies.txt");
        }
    }
}
