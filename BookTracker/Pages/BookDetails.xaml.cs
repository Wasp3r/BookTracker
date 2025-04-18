﻿namespace BookTracker.Pages;

public partial class BookDetails : ContentPage
{
    public BookDetails()
    {
        BindingContext = App.MainViewModel.SelectedBook;
        InitializeComponent();
    }

    private async void BackButtonClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void RemoveBookClicked(object? sender, EventArgs e)
    {
        await App.MainViewModel.RemoveBookCommand.ExecuteAsync(App.MainViewModel.SelectedBook);
        await Navigation.PushAsync(new MainPage());
    }
}