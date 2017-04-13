using System.Windows.Controls;
using System.Windows.Input;
using EnglishPremierLeagueApp.ViewModels.User;

namespace EnglishPremierLeagueApp.Views.User
{
    /// <summary>
    /// Interaction logic for AnalysisTabView.xaml
    /// </summary>
    public partial class AnalysisTabView : UserControl
    {
        public AnalysisTabView()
        {
            InitializeComponent();
            DataContext = new AnalysisTabViewModel();
        }

        private void MinPriceTextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key < Key.D0 || e.Key > Key.D9) && (e.Key < Key.NumPad0 || e.Key > Key.NumPad9))
            {
                e.Handled = true;
                return;
            }
            minPriceTextBox.TextChanged += MinPriceTextBoxOnTextChanged;
        }

        private void MinPriceTextBoxOnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            minPriceTextBox.TextChanged -= MinPriceTextBoxOnTextChanged;
            minPriceTextBox.Text = $"{decimal.Parse(minPriceTextBox.Text):##,###}";
            minPriceTextBox.CaretIndex = minPriceTextBox.Text.Length;

        }

        private void MaxPriceTextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key < Key.D0 || e.Key > Key.D9) && (e.Key < Key.NumPad0 || e.Key > Key.NumPad9))
            {
                e.Handled = true;
                return;
            }
            maxPriceTextBox.TextChanged += MaxPriceTextBoxOnTextChanged;
        }

        private void MaxPriceTextBoxOnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            maxPriceTextBox.TextChanged -= MaxPriceTextBoxOnTextChanged;
            maxPriceTextBox.Text = $"{decimal.Parse(maxPriceTextBox.Text):##,###}";
            maxPriceTextBox.CaretIndex = maxPriceTextBox.Text.Length;
        }
    }
}
