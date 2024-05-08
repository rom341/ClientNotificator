namespace ClientCreator
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CreateNewClientPage), typeof(CreateNewClientPage));
            Routing.RegisterRoute(nameof(ClientListPage), typeof(ClientListPage));
        }
    }
}
