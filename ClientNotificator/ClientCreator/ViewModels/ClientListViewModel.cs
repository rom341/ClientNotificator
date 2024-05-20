using ClientCreator.DataAccess;
using ClientCreator.Models;
using ClientCreator.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCreator.ViewModels
{
    public partial class ClientListViewModel : ObservableObject
    {
        private readonly AppDBContext _context;
        public ObservableCollection<Client> Clients { get; }

        [ObservableProperty]
        public Client selectedClient;

        public ClientListViewModel(AppDBContext context)
        {
            Clients = new ObservableCollection<Client>();
            _context = context;
            LoadClients();
        }

        private void LoadClients()
        {
            try
            {
                Clients.Clear();
                var clients = _context.Clients.
                    Include(c => c.Contacts).
                    Include(c => c.PersonalInfo).
                    Include(c => c.SubscribedServices).
                    ToList();

                foreach (var client in clients)
                {
                    Clients.Add(client);
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        [RelayCommand]
        async Task SelectClient()
        {
            try
            {
                string destination = $"{nameof(ClientDetailPage)}";
                var data = new Dictionary<string, Object>
                {
                    [nameof(Client)] = selectedClient
                };

                await Shell.Current.GoToAsync(destination, data);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }


        [RelayCommand]
        async Task EditClient(Client clientToEdit)
        {
            try
            {
                string destination = $"{nameof(CreateNewClientPage)}";
                var data = new Dictionary<string, Object>
                {
                    [nameof(Client)] = clientToEdit
                };

                await Shell.Current.GoToAsync(destination, data);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
               
        [RelayCommand]
        async Task DeleteClient(Client clientToDelete)
        {
            bool confirm = await App.Current.MainPage.DisplayAlert("Подтверждение", "Вы уверены, что хотите удалить клиента?", "Да", "Нет");
            if (confirm)
            {
                try
                {
                    _context.Clients.Remove(clientToDelete);
                    await _context.SaveChangesAsync();
                    Clients.Remove(clientToDelete);
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }
            }
        }
    }
}
