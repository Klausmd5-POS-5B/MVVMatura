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
using DB;

namespace LernSiegWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SiegContext _db;
        private MainViewModel _mvm;
        
        public MainWindow()
        {
            InitializeComponent();
            _db = new SiegContext();
            _db.Database.EnsureDeleted();
            _db.Database.EnsureCreated();

            Title = _db.Teachers.Count().ToString();
            
            _mvm = new MainViewModel(_db);
            
            DataContext = _mvm;

        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}