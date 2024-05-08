using ClientCreator.DataAccess;
using ClientCreator.Models;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCreator.ViewModels
{
    public partial class MainPageViewModel
    {
        public MainPageViewModel()
        {

        }

        [RelayCommand]
        async Task ShowCreateNewClientPage()
        {
            await Shell.Current.GoToAsync(nameof(CreateNewClientPage));
        }

        [RelayCommand]
        async Task ShowClientsPage()
        {
            await Shell.Current.GoToAsync(nameof(ClientListPage));
        }
    }
}
