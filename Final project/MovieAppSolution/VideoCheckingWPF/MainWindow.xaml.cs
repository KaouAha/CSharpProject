using System;
using System.Collections.Generic;
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
using VideoCheckingWPF.ServiceReference1;

namespace VideoCheckingWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public VideoCheckServiceClient serviceClient;
      
        public MainWindow()
        {
            InitializeComponent();
            serviceClient = new VideoCheckServiceClient();

        }

        private void buttonAllMovie_Click(object sender, RoutedEventArgs e)
        {

            this.MovieDataGrid.ItemsSource = serviceClient.allMovies();
            MovieDataGrid.ColumnFromDisplayIndex(3).Visibility = Visibility.Collapsed;
        }

        private void ButtonAvaibleMovie_Click(object sender, RoutedEventArgs e)
        {

            this.MovieDataGrid.ItemsSource = serviceClient.movieAbsoluteFree();
            MovieDataGrid.ColumnFromDisplayIndex(3).Visibility = Visibility.Collapsed;

        }

        private void UnavaibleMoviesButton_Click(object sender, RoutedEventArgs e)
        {
            this.MovieDataGrid.ItemsSource = serviceClient.moviesRended();
        }

        private void AllOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            this.dataGridOrder.ItemsSource = serviceClient.allOrders();
        }

        private void ConfirmNewOrderButton_Click(object sender, RoutedEventArgs e)
        {

            

            string username = this.TextBoxUsername.Text;
            string Movie = this.TextBoxMovieName.Text;
            DateTime? dt = this.DataPickerOrder.SelectedDate;

            serviceClient.createOrder(Movie, username, dt);

           

        }


        private void buttonCheckSpell_Click(object sender, RoutedEventArgs e)
        {

            string uname = this.TextBoxUsername.Text;
            string movie = this.TextBoxMovieName.Text;

            if (serviceClient.movieExist(movie) && serviceClient.userExist(uname))
            {
                this.ConfirmNewOrderButton.IsEnabled = true;
                this.checkBoxMovieName.IsChecked = true;
                this.checkBoxUserName.IsChecked = true;

            }


        }

        private void ButtonAllUsers_Click(object sender, RoutedEventArgs e)
        {

            
            this.UsersdataGrid.ItemsSource = serviceClient.allUsers();



        }

        private void UsersdataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
