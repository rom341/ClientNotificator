using ClientCreator.DataAccess;
using ClientCreator.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
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
                updateOtherClientData();

                _context.Clients.Add(_client);
                await _context.SaveChangesAsync();

                await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
            }
            catch (DbUpdateException ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"{ex.Message}\n {ex.InnerException?.Message}", "OK");
            }
        }

        private void updateOtherClientData()
        {
            _client.RegistrationDate = DateTime.Now;
            _client.lastEditDate = DateTime.Now;
            if (_client.NextVisitDate.HasValue)
            {
                _client.VisitList.Add(_client.NextVisitDate.Value);
            }
        }
    }
}
