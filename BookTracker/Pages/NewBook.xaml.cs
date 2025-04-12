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
            var newBookViewModel = await App.MainViewModel.CreateBook(_viewModel.NewBook);
            App.MainViewModel.SelectedBook = newBookViewModel;
            await Navigation.PushAsync(new BookDetails());
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