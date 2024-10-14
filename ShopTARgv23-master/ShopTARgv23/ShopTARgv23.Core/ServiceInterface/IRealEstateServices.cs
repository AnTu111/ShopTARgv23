using ShopTARgv23.Core.Domain;
using ShopTARgv23.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv23.Core.ServiceInterface
{
    public interface IRealEstateServices
    {
        Task<RealEstate> Create(RealEstateDto dto);
        Task<RealEstate> Update(RealEstateDto dto);
        Task<RealEstate> GetAsync(Guid id);
        Task<RealEstate> Delete(Guid id);
    }
}
