using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using EnglishPremierLeagueApp.Models;
using EnglishPremierLeagueApp.ViewModels.Manager;

namespace EnglishPremierLeagueApp.Views.Manager
{
    /// <summary>
    /// Interaction logic for Transfers.xaml
    /// </summary>
    public partial class Transfers : UserControl
    {
        public Transfers(BindingList<Transfer> transfers, BindingList<Player> players)
        {
            InitializeComponent();
            DataContext = new TransferViewModel(transfers, players);

        }

        private void TransferPropositionFeeTextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key < Key.D0 || e.Key > Key.D9) && (e.Key < Key.NumPad0 || e.Key > Key.NumPad9))
            {
                e.Handled = true;
                return;
            }
            TransferPropositionFeeTextBox.TextChanged += TransferPropositionFeeTextBoxOnTextChanged;
        }

        private void TransferPropositionFeeTextBoxOnTextChanged(object sender, TextChangedEventArgs e)
        {

            TransferPropositionFeeTextBox.TextChanged -= TransferPropositionFeeTextBoxOnTextChanged;
            TransferPropositionFeeTextBox.Text = $"{decimal.Parse(TransferPropositionFeeTextBox.Text):##,###}";
            TransferPropositionFeeTextBox.CaretIndex = TransferPropositionFeeTextBox.Text.Length;
        }
    }
}

