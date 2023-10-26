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

namespace VeterinarySmilesWPF
{
    /// <summary>
    /// Lógica de interacción para WinMenuVet.xaml
    /// </summary>
    public partial class WinMenuVet : Window
    {
        public WinMenuVet()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPet_Click(object sender, RoutedEventArgs e)
        {
            WinAdmPet wp = new WinAdmPet();
            wp.Show();
            this.Visibility = Visibility.Hidden;
        }
    }
}
