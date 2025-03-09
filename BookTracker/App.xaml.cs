using BookTracker.DataAccess;
using BookTracker.ViewModels;

namespace BookTracker;

public partial class App : Application
{
    private readonly IBooksRepository _repository;
    public static BookListViewModel MainViewModel { get; private set; } 
    
    public App(IBooksRepository repository)
    {
        _repository = repository;
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        MainViewModel = new(_repository);
        MainViewModel.RefreshBooks().ContinueWith(s => { });
        return new Window(new AppShell());   
    }
}