using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.IO;
using System;
using img_stitch.Services;
using Microsoft.Extensions.DependencyInjection;


namespace img_stitch.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";

    public string File1Name { get; set; }


    public MainViewModel()
    {
        File1Name = "Select File";
    }

    [RelayCommand]
    private async Task OpenFile(CancellationToken token)
    {
        try
        {
            var filesService = App.Current?.Services?.GetService<IFileService>();
            if (filesService is null) throw new NullReferenceException("Missing File Service instance.");

            var file = await filesService.OpenFileAsync();
            if (file is null) return;

            File1Name = file.Name;

        }
        catch (Exception e)
        {
        }
    }
}
