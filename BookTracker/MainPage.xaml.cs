using BookTracker.DataAccess;
using BookTracker.Models;
using BookTracker.Pages;

namespace BookTracker;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void ListView_OnItemTapped(object? sender, ItemTappedEventArgs e)
    {
        await Navigation.PushAsync(new BookDetails());
    }
}