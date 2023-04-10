using System.Linq;
using System.Reactive;
using System.Reflection;
using ReactiveUI;

namespace SnapSharp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private string _greeting;
    public string Greeting
    {
        get => _greeting;
        set => this.RaiseAndSetIfChanged(ref _greeting, value);
    }
    
    public ReactiveCommand<Unit, Unit> SayHelloCommand { get; }

    public MainWindowViewModel()
    {
        _greeting = "This is a snapped project!";
        
        SayHelloCommand = ReactiveCommand.Create(SayHello);
    }

    void SayHello()
    {
        var dotnetVersion = System.Reflection.Assembly
            .GetExecutingAssembly()
            .GetReferencedAssemblies()
            .FirstOrDefault(a => a.Name == "System.Runtime")?
            .Version?
            .Major;
        
        Greeting = $"Hello, world from .NET {dotnetVersion}!";
    }
}