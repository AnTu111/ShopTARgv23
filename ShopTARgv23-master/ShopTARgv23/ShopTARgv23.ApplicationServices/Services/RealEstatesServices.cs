using Microsoft.EntityFrameworkCore;
using ShopTARgv23.Core.Domain;
using ShopTARgv23.Core.Dto;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Data;


namespace ShopTARgv23.ApplicationServices.Services
{
    public class RealEstatesServices : IRealEstateServices
    {
        private readonly ShopTARgv23Context _context;
        private readonly IFileServices _fileServices;

        public RealEstatesServices
            (
                ShopTARgv23Context context,
                IFileServices fileServices
            )
        {
            _context = context;
            _fileServices = fileServices;
        }


        public async Task<RealEstate> GetAsync(Guid id)
        {
            var result = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<RealEstate> Create(RealEstateDto dto)
        {
            RealEstate realEstate = new RealEstate();

            realEstate.Id = Guid.NewGuid();
            realEstate.Location = dto.Location;
            realEstate.Size = dto.Size;
            realEstate.RoomNumber = dto.RoomNumber;
            realEstate.BuildingType = dto.BuildingType;
            realEstate.CreatedAt = DateTime.Now;
            realEstate.ModifiedAt = DateTime.Now;

            if (dto.Files != null )
            {
                _fileServices.UploadFilesToDatabase(dto, realEstate);
            }

            await _context.RealEstates.AddAsync(realEstate);
            await _context.SaveChangesAsync();

            return realEstate;
        }

        public async Task<RealEstate> Update(RealEstateDto dto)
        {
            var domain = new RealEstate()
            {
                Id = dto.Id,
                Location = dto.Location,
                Size = dto.Size,
                RoomNumber = dto.RoomNumber,
                BuildingType = dto.BuildingType,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = DateTime.Now,
            };

            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, domain);
            }

            _context.RealEstates.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

        public async Task<RealEstate> Delete(Guid id)
        {
            var result = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);

            var images = await _context.FileToDatabases
                .Where(x => x.RealEstateId == id)
                .Select(y => new FileToDatabaseDto
                {
                    Id = y.Id,
                    ImageTitle = y.ImageTitle,
                    RealEstateId = y.RealEstateId
                }).ToArrayAsync();

            await _fileServices.RemoveImagesFromDatabase(images);
            _context.RealEstates.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}
