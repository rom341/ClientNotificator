using ClientCreator.DataAccess;
using ClientCreator.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCreator.ViewModels
{
    [QueryProperty(nameof(Client), nameof(Client))]
    public partial class ClientDetailViewModel : ObservableObject
    {
        private AppDBContext _context;
        [ObservableProperty]
        private Client _client;
        public ClientDetailViewModel(AppDBContext context, Client client)
        {
            _context = context;
            LoadClientData(client.ID);
        }

        private void LoadClientData(int clientId)
        {
            var client = _context.Clients.
                    Include(c => c.Contacts).
                    Include(c => c.PersonalInfo).
                    Include(c => c.SubscribedServices).
                    FirstOrDefault(c => c.ID == clientId);
            _client = client;
        }
    }
}
