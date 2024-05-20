using ClientCreator.ViewModels;

namespace ClientCreator.Pages;

public partial class ClientDetailPage : ContentPage
{
	public ClientDetailPage(ClientDetailViewModel clientDetailViewModel)
	{
		InitializeComponent();
		BindingContext = clientDetailViewModel;
	}
}