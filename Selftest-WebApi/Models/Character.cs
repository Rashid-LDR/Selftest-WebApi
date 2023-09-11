namespace Selftest_WebApi.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = null;

        public string father { get; set; }= null;

        public string contact { get; set; }=null;   

        public string phone { get; set; }   =null;

        public User User { get; set; } 
    }
}
