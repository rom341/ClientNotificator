using ClientCreator.DataAccess;
using ClientCreator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCreator.ViewModels
{
    public partial class ClientListViewModel
    {
        private readonly AppDBContext _context;
        public ObservableCollection<Client> Clients { get; }
        public ObservableCollection<DateTime> BusyDays { get; }

        public ClientListViewModel(AppDBContext context)
        {
            Clients = new ObservableCollection<Client>();
            BusyDays = new ObservableCollection<DateTime>();
            _context = context;
            LoadClients();
        }
        private void LoadClients()
        {
            try
            {
                Clients.Clear();
                var clients = _context.Clients.ToList();
                foreach (var client in clients)
                {
                    Clients.Add(client);
                }

                BusyDays.Clear();
                var busyDays = Clients.SelectMany(c => c.VisitList.Select(v => v.Date))
                                    .Distinct()
                                    .ToList();
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
