﻿using Avalonia.Platform.Storage;
using System.Threading.Tasks;
using Avalonia.Controls;

namespace img_stitch.Services;

public partial class FileService : IFileService
{
    private readonly Window _target;

    public FileService(Window target)
    {
        _target = target;
    }

    public async Task<IStorageFile?> OpenFileAsync()
    {
        var files = await _target.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions()
        {
            Title = "Open Text File",
            AllowMultiple = false
        });

        return files.Count >= 1 ? files[0] : null;
    }

    public async Task<IStorageFile?> SaveFileAsync()
    {
        return await _target.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions()
        {
            Title = "Save Text File"
        });
    }
}

