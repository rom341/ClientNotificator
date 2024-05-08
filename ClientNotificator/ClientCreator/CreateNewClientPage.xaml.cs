using ClientCreator.Models;
using ClientCreator.ViewModels;

namespace ClientCreator;

public partial class CreateNewClientPage: ContentPage
{
	public CreateNewClientPage(CreateNewClientViewModel createNewClientViewModel)
	{
		InitializeComponent();
        BindingContext = createNewClientViewModel;
	}
}