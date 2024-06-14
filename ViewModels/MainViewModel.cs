using Axiprod.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Axiprod.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string connectionString;
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        private ObservableCollection<Customers> _items4;
        private readonly DataService _dataService;
        public MainViewModel()
        {

        }
        public MainViewModel(string connectionString):this()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();

            _dataService = new DataService(connectionString);
           // LoadDataCommand = new RelayCommand(LoadData);
            LoadData();
        }

        public ObservableCollection<Customers> Items4
        {
            get => _items4;
            set
            {
                _items4 = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadDataCommand { get; }

        private void LoadData()
        {
            Items4 = _dataService.GetData();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}