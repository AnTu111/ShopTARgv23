using ShopTARgv23.Core.Domain;
using ShopTARgv23.Core.Dto;

namespace ShopTARgv23.Core.ServiceInterface
{
    public interface IFileServices
    {
        void FilesToApi(SpaceshipDto dto, Spaceship spaceship);
        Task<FileToApi> RemoveImageFromApi(FileToApiDto dto);
        Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dtos);
        void UploadFilesToDatabase(RealEstateDto dto, RealEstate domain);
        Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto);
        Task<FileToDatabase> RemoveImagesFromDatabase(FileToDatabaseDto[] dtos);
    }
}
