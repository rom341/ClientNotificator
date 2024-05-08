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
        [ObservableProperty]
        public Client _client;
        public CreateNewClientViewModel()
        {
            _client = new Client();
        }
        public CreateNewClientViewModel(Client client)
        {
            _client = client;
        }

        [RelayCommand]
        async Task CreateClient()
        {
            try
            {
                _client.RegistrationDate = DateTime.Now;
                using (var context = new AppDBContext())
                {
                    context.Clients.Add(_client);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
