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
        public ObservableCollection<Client> Clients { get; }

        public ClientListViewModel()
        {
            Clients = new ObservableCollection<Client>();
            LoadClients();
        }
        private void LoadClients()
        {
            Clients.Clear();
            using (var context = new AppDBContext())
            {
                var clients = context.Clients.ToList();
                foreach (var client in clients)
                {
                    Clients.Add(client);
                }
            }
        }
    }
}
