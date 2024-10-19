using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ShopTARgv23.Core.Domain;
using ShopTARgv23.Core.Dto;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Data;
using System.Xml;

namespace ShopTARgv23.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly IHostEnvironment _webHost;
        private readonly ShopTARgv23Context _context;
        public FileServices(IHostEnvironment webHost, ShopTARgv23Context context)
        {
            _webHost = webHost;
            _context = context;
        }
        public void FilesToApi(SpaceshipDto dto, Spaceship spaceship)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                if (!Directory.Exists(_webHost.ContentRootPath + "\\multipleFileUpload\\"))
                {
                    Directory.CreateDirectory(_webHost.ContentRootPath + "\\multipleFileUpload\\");
                }
                foreach (var image in dto.Files)
                {
@@ -67,25 + 68,76 @@
        }
                public async Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dtos)
                {
                    foreach (var dto in dtos)
                    {
                        var imageId = await _context.FileToApis
                            .FirstOrDefaultAsync(x => x.ExistingFilePath == dto.ExistingFilePath);
                        var filePath = _webHost.ContentRootPath + "\\multipleFileUpload\\"
                            + imageId.ExistingFilePath;
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                        _context.FileToApis.Remove(imageId);
                        await _context.SaveChangesAsync();
                    }

                    return null;
                }
            }
        }
