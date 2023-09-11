using Selftest_WebApi.Controllers;

namespace Selftest_WebApi.Models
{
    public class TeacherModel
    {
        public int Id { get; set; }

        public string TeacherName { get; set; }
        public string TeacherSubject { get; set; }

        public string Sallary { get; set; }

        public string TeacherContact {get; set;}
    }
}
