using ClientCreator.Models;
using ClientCreator.ViewModels;

namespace ClientCreator;

public partial class CreateNewClientPage: ContentPage
{
	public CreateNewClientPage(EditClientViewModel createNewClientViewModel)
	{
		InitializeComponent();
        BindingContext = createNewClientViewModel;
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs parameters)
	{
        base.OnNavigatedTo(parameters);
    }
}