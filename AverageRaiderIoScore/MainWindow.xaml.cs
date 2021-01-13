using System.Windows;

namespace AverageRaiderIoScore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var viewModel = new ViewModel();
            DataContext = viewModel;
            this.Resources.Add("regions", viewModel.Regions);
            InitializeComponent();            
        }
    }
}