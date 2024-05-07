using ClientCreator.Models;

namespace ClientCreator;

public partial class CreateNewClientPage: ContentPage
{
	public CreateNewClientPage(Client client)
	{
		InitializeComponent();
		BindingContext = client;
	}
}