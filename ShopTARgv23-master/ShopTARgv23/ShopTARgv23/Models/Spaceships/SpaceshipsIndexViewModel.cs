namespace ShopTARgv23.Models.Spaceships
{
    public class SpaceshipsIndexViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime BuiltDate { get; set; }
        public int CargoWeight { get; set; }
        public int Crew { get; set; }
        public int EnginePower { get; set; }
    }
}
