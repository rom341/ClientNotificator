using ClientCreator.DataAccess;
using ClientCreator.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCreator.ViewModels
{
    public partial class CreateNewClientViewModel : ObservableObject
    {
        private readonly AppDBContext _context;
        [ObservableProperty]
        public Client _client;
        public CreateNewClientViewModel(AppDBContext context)
        {
            _client = new Client();
            _context = context;
        }
        public CreateNewClientViewModel(Client client, AppDBContext context)
        {
            _client = client;
            _context = context;
        }

        [RelayCommand]
        async Task CreateClient()
        {
            try
            {
                _client.RegistrationDate = DateTime.Now;

                _context.Clients.Add(_client);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
