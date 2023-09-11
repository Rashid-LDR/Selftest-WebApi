namespace Selftest_WebApi.DTO.AnimalDTO
{
    public class GetAnimalDTO
    {
        public int ID { get; set; }
        public string Name { get; set; } = null;
        public string Color { get; set; } = null;

        public double height { get; set; } = 0;
    }
}
