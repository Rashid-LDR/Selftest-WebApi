namespace Selftest_WebApi.DTO.CollegeDTO
{
    public class UpdateCollegeInfoDto
    {
        public int id { get; set; }

        public string college_Name { get; set; }

        public string college_Address { get; set; }
        public string college_City { get; set; }
        public string college_Region { get; set; }
        public int college_PostalCode { get; set; }
        public string college_Country { get; set; }
    }
}
