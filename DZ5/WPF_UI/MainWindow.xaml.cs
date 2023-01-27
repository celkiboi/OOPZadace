using System;
using System.Collections.Generic;
using System.DirectoryServices;
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
using System.Windows.Threading;
using TVShowLogic;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Show[]? shows;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        
        void Search_Click(object sender, RoutedEventArgs e)
        {

            string input = SearchTextBox.Text;
            shows = Utilities.SearchShows(input);

            ShowList.ItemsSource = shows;
            ShowList.Items.Refresh();
        }

        void ShowList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Show? selectedShow = ShowList.SelectedItem as Show;
            if (selectedShow == null)
            {
                ShowInfoLabel.Text = "No show selected";
                return;
            }
            ShowInfoLabel.Text = $"Show info:\n{selectedShow.GetInfo()}";


            SeasonList.ItemsSource = Utilities.GetSeasons(selectedShow);
            SeasonList.Items.Refresh();

        }

        void SeasonList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Season? selectedSeason = SeasonList.SelectedItem as Season;

            if (selectedSeason == null)
            {
                SeasonInfoLabel.Text = "No show selected";
                return;
            }
            if (selectedSeason.Episodes == null)
            {
                SeasonInfoLabel.Text = "Season not released yet";
                return;
            }
            SeasonInfoLabel.Text = $"Season info:\n{selectedSeason.GetInfo()}";


            EpisodeList.ItemsSource = Utilities.GetEpisodes(selectedSeason);
            EpisodeList.Items.Refresh();
        }
        
        void EpisodeList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
