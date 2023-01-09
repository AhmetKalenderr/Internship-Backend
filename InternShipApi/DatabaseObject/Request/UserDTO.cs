namespace InternShipApi.DatabaseObject.Request
{
    public class UserDTO
    {
        public string Name { get; set; }

        public int cityId { get; set; }

        public int userTypeId { get; set; } = 1;
        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string phoneNumber { get; set; }



    }
}
