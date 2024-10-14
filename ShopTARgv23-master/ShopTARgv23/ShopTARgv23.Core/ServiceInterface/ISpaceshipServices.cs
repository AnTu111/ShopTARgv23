using ShopTARgv23.Core.Domain;
using ShopTARgv23.Core.Dto;


namespace ShopTARgv23.Core.ServiceInterface
{
    public interface ISpaceshipServices
    {
        Task<Spaceship> DetailsAsync(Guid id);
        Task<Spaceship> Update(SpaceshipDto dto);
        Task<Spaceship> Delete(Guid id);
        Task<Spaceship> Create(SpaceshipDto dto);
    }
}
