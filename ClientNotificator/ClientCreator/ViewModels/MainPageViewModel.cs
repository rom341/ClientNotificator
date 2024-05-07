using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCreator.ViewModels
{
    public partial class MainPageViewModel
    {
        [RelayCommand]
        async Task ShowCreateNewClientPage()
        {
            //await Shell.Current.GoToAsync(nameof(CreateNewClientPage));
            await Shell.Current.GoToAsync(nameof(CreateNewClientPage));

        }
    }
}
