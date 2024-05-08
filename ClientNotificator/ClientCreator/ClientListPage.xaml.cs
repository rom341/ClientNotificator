using ClientCreator.ViewModels;

namespace ClientCreator;

public partial class ClientListPage : ContentPage
{
	public ClientListPage(ClientListViewModel clientListViewModel)
	{
		InitializeComponent();
		BindingContext = clientListViewModel;
	}
}