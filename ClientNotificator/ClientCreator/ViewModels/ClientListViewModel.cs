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

        public ClientListViewModel(AppDBContext context)
        {
            Clients = new ObservableCollection<Client>();
            _context = context;
            LoadClients();
        }
        private void LoadClients()
        {
            Clients.Clear();
            var a = _context.ClientContacts.ToList();
            var b = _context.ClientPersonalInfo.ToList();
            List<Client> clients = _context.Clients.ToList();
            foreach (var client in clients)
            {
                Clients.Add(client);
            }
        }
    }
}
