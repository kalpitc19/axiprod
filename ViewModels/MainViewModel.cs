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
        private ObservableCollection<Customers> _allcustomers;
        private ObservableCollection<Vendors> _allvendors;
        private ObservableCollection<Jobs> _alljobs;
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

        public ObservableCollection<Customers> AllCustomers
        {
            get => _allcustomers;
            set
            {
                _allcustomers = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Vendors> AllVendors
        {
            get => _allvendors;
            set
            {
                _allvendors = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Jobs> AllJobs
        {
            get => _alljobs;
            set
            {
                _alljobs = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadDataCommand { get; }

        private void LoadData()
        {
            AllCustomers = _dataService.GetAllCustomersData();
            AllVendors = _dataService.GetAllVendorsData();
            AllJobs = _dataService.GetAllJobsData();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}