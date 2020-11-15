namespace src.Models
{
    public class Restaurant : EntityBase
    {
        public string Name { get; set; }

        public StatusEnum Status { get; set; }
    }
}