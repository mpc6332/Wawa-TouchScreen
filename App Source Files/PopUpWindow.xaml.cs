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
using System.Windows.Shapes;

namespace Lab_WawaApp
{
    /// <summary>
    /// Interaction logic for PopUpWindow.xaml
    /// </summary>
    public partial class PopUpWindow : Window
    {
        public string AnswerChoice { get; set; }

        public PopUpWindow()
        {
            InitializeComponent();
        }

        // If the "OK" button was clicked, signal to the PrintOutWindow that it is ok to cancel the order and close the pop-up window.
        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            AnswerChoice = "OK";
            Close();
        }

        // If the "Cancel" button was clicked, just only close the pop-up window.
        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            AnswerChoice = "Cancel";
            Close();
        }
    }
}
