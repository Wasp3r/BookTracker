using BookTracker.ViewModels;

namespace BookTracker.Pages;

public partial class NewBook : ContentPage
{
    private readonly NewBookViewModel _viewModel;
    
    public NewBook()
    {
        _viewModel = new NewBookViewModel();
        BindingContext = _viewModel;
        InitializeComponent();
    }

    private async void Create_OnClicked(object? sender, EventArgs e)
    {
        try
        {
            await App.MainViewModel.CreateBook(_viewModel.NewBook);
            await Navigation.PopAsync();
        }
        catch (Exception error)
        {
            // TODO: Show error
        }
    }

    private void Cancel_OnClicked(object? sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}