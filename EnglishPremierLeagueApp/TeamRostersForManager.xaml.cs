using System;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MessageBox = System.Windows.MessageBox;
using UserControl = System.Windows.Controls.UserControl;

namespace EnglishPremierLeagueApp
{
    /// <summary>
    /// Interaction logic for TeamRostersForManager.xaml
    /// </summary>
    public partial class TeamRostersForManager : UserControl
    {
      
        public TeamRostersForManager()
        {
            InitializeComponent();
            PlayersListView.Visibility = Visibility.Hidden;
            PropositionGrid.Visibility = Visibility.Hidden;
            TeamsListView.ItemsSource = App.Db.Teams.Where(team => team.Name != App.CurrentUser.Team.Name).ToList();
            TeamsListView.SelectionChanged += InitializeRosterListView;
            PlayersListView.SelectionChanged += InitializePropositionPossibility;

        }

        private void InitializePropositionPossibility(object sender, SelectionChangedEventArgs e)
        {
            if(PlayersListView.SelectedItem == null)
            {
                PropositionGrid.Visibility = Visibility.Hidden;
                return;
            }
            SelectedPlayerLabel.Content = (PlayersListView.SelectedItem as Player)?.Name;
            TransferPropositionFeeTextBox.KeyDown += TransferPropositionFeeTextBoxOnKeyDown;
            TransferPropositionFeeTextBox.Text = (PlayersListView.SelectedItem as Player)?.Fee.ToString("##,###");
            TransferPropositionFeeTextBox.MaxLength = 12;
            PropositionGrid.Visibility = Visibility.Visible;
        }


        private void TransferPropositionFeeTextBoxOnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            
            if ((keyEventArgs.Key < Key.D0 || keyEventArgs.Key > Key.D9) && (keyEventArgs.Key < Key.NumPad0 || keyEventArgs.Key > Key.NumPad9))
            {
                keyEventArgs.Handled = true;
                return;
            }
            TransferPropositionFeeTextBox.TextChanged += TransferPropositionFeeTextBoxOnTextChanged;
        }

        private void TransferPropositionFeeTextBoxOnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            TransferPropositionFeeTextBox.TextChanged -= TransferPropositionFeeTextBoxOnTextChanged;
            TransferPropositionFeeTextBox.Text = $"{decimal.Parse(TransferPropositionFeeTextBox.Text):##,###}";
            TransferPropositionFeeTextBox.CaretIndex = TransferPropositionFeeTextBox.Text.Length;
        }

        private void InitializeRosterListView(object sender, SelectionChangedEventArgs e)
        {
            if (TeamsListView.SelectedItem == null) { PlayersListView.Visibility = Visibility.Hidden; return;}
            PlayersListView.Visibility = Visibility.Visible;
            PlayersListView.ItemsSource = App.Db.Teams.Find((TeamsListView.SelectedItem as Team).Id).Players.ToList();

        }

        private void ProposeButton_Click(object sender, RoutedEventArgs e)
        {
            App.Db.Entry(new Transfer
            {
                Fee = decimal.Parse(TransferPropositionFeeTextBox.Text),
                FromId = (TeamsListView.SelectedItem as Team).Id,
                ToId = App.CurrentUser.TeamId.Value,
                PlayerId = (PlayersListView.SelectedItem as Player).Id,
                Status = "Pending"
            }).State = EntityState.Added;
            //App.Db.Transfers.Add(new Transfer
            //{
            //    Fee = decimal.Parse(TransferPropositionFeeTextBox.Text),
            //    FromId = App.CurrentUser.TeamId.Value,
            //    ToId = (TeamsListView.SelectedItem as Team).Id,
            //    PlayerId = (PlayersListView.SelectedItem as Player).Id,
            //    Status = "Pending"
            //});
            App.Db.SaveChanges();
            PropositionGrid.Visibility = Visibility.Hidden;
            MessageBox.Show("Proposition is successfully sent!");
        }
    }
}
