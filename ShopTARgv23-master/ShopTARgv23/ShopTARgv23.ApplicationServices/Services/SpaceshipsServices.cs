using Microsoft.EntityFrameworkCore;
using ShopTARgv23.Core.Domain;
using ShopTARgv23.Core.Dto;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Data;


namespace ShopTARgv23.ApplicationServices.Services
{
    public class SpaceshipsServices : ISpaceshipServices
    {
        private readonly ShopTARgv23Context _context;
        private readonly IFileServices _fileServices;

        public SpaceshipsServices
            (
                ShopTARgv23Context context,
                IFileServices fileServices
            )
        {
            _context = context;
            _fileServices = fileServices;
        }

        public async Task<Spaceship> DetailsAsync(Guid id)
        {
            var result = await _context.Spaceships
                .FirstOrDefaultAsync( x => x.Id == id );

            return result;
        }

        public async Task<Spaceship> Create(SpaceshipDto dto)
        {
            Spaceship spaceship = new();

            spaceship.Id = Guid.NewGuid();
            spaceship.Name = dto.Name;
            spaceship.Type = dto.Type;
            spaceship.BuiltDate = dto.BuiltDate;
            spaceship.CargoWeight = dto.CargoWeight;
            spaceship.Crew = dto.Crew;
            spaceship.EnginePower = dto.EnginePower;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;
            _fileServices.FilesToApi(dto, spaceship);

            await _context.Spaceships.AddAsync(spaceship);
            await _context.SaveChangesAsync();

            return spaceship;
        }

        public async Task<Spaceship> Update(SpaceshipDto dto)
        {
            Spaceship domain = new();

            domain.Id = dto.Id;
            domain.Name = dto.Name;
            domain.Type = dto.Type;
            domain.BuiltDate = dto.BuiltDate;
            domain.CargoWeight = dto.CargoWeight;
            domain.Crew = dto.Crew;
            domain.EnginePower = dto.EnginePower;
            domain.CreatedAt = dto.CreatedAt;
            domain.ModifiedAt = DateTime.Now;
            _fileServices.FilesToApi(dto, domain);

            _context.Spaceships.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

        public async Task<Spaceship> Delete(Guid id)
        {
            var spaceship = await _context.Spaceships
                .FirstOrDefaultAsync(x => x.Id == id);

            var images = await _context.FileToApis
                .Where(x => x.SpaceshipId == id)
                .Select(y => new FileToApiDto
                {
                    Id = y.Id,
                    SpaceshipId = y.SpaceshipId,
                    ExistingFilePath = y.ExistingFilePath
                }).ToArrayAsync();

            await _fileServices.RemoveImagesFromApi(images);
            _context.Spaceships.Remove(spaceship);
            await _context.SaveChangesAsync();

            return spaceship;
        }
    }
}
