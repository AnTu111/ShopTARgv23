using Microsoft.AspNetCore.Http;

namespace ShopTARgv23.Core.Dto
{
    public class SpaceshipDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime BuiltDate { get; set; }
        public int CargoWeight { get; set; }
        public int Crew { get; set; }
        public int EnginePower { get; set; }

        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToApiDto> Image { get; set; }
            = new List<FileToApiDto>();

        //only in db
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
