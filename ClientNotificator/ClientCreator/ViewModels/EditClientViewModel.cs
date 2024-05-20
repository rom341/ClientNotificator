using ClientCreator;
using ClientCreator.DataAccess;
using ClientCreator.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ClientCreator.ViewModels
{
    [QueryProperty(nameof(Client), nameof(Client))]
    public partial class EditClientViewModel : ObservableObject
    {
        private readonly AppDBContext _context;

        [ObservableProperty]
        public Client _client;

        public EditClientViewModel(AppDBContext context)
        {
            _client = new Client();
            _context = context;
        }

        public EditClientViewModel(AppDBContext context, Client client)
        {
            _client = client;
            _context = context;
        }

        [RelayCommand]
        async Task SaveClient()
        {
            try
            {
                setDateInfoForClient();
                // Если ID клиента равен 0, значит он новый и не существует в базе данных
                if (_client.ID == 0)
                {
                    _context.Clients.Add(_client);
                }
                else
                {
                    _context.Clients.Update(_client);
                }

                await _context.SaveChangesAsync();

                await Shell.Current.GoToAsync(nameof(ClientListPage));
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"{ex.Message}\n {ex.InnerException?.Message}", "OK");
            }
        }

        private void setDateInfoForClient()
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