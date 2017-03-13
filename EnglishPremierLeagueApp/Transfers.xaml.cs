using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace EnglishPremierLeagueApp
{
    /// <summary>
    /// Interaction logic for Transfers.xaml
    /// </summary>
    public partial class Transfers : UserControl
    {
        public Transfers(BindingList<Transfer> transfers)
        {
            InitializeComponent();
            DataContext = new TransferViewModel(transfers);

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

