using Avalonia.Platform.Storage;
using System.Threading.Tasks;

namespace img_stitch.Services
{
    internal interface IFileService
    {
        public Task<IStorageFile?> OpenFileAsync();
        public Task<IStorageFile?> SaveFileAsync();
    }
}
