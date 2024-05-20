using ClientCreator.Pages;

namespace ClientCreator
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(CreateNewClientPage), typeof(CreateNewClientPage));
            Routing.RegisterRoute(nameof(ClientListPage), typeof(ClientListPage));
            Routing.RegisterRoute(nameof(ClientDetailPage), typeof(ClientDetailPage));
        }
    }
}
