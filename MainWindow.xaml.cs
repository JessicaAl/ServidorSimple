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

namespace ServidorSimple_171G0214
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Server serv = new Server();
        private void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            serv.Inicio();
        }

        private void btnFinal_Click(object sender, RoutedEventArgs e)
        {
            serv.Final();
        }
    }
}
