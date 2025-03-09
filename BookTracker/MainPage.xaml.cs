using BookTracker.DataAccess;
using BookTracker.Models;

namespace BookTracker;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void ListView_OnItemTapped(object? sender, ItemTappedEventArgs e)
    {
        Console.WriteLine("Tapped");
    }
}