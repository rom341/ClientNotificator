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

        [RelayCommand]
        public void CreateClient()
        {
            _client = new Client();
        }
    }
}
