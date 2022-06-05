namespace InternShipApi.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }

        public string WebSite { get; set; }

        public int CityId { get; set; }

        public City city { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string PassWord { get; set; }
    }
}
