using InternShipApi.Entities;

namespace InternShipApi.DatabaseObject.Response
{
    public class UserFromApp
    {
        public string Email { get; set; }

        public School school { get; set; }

        public int BornYear { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string AppTime { get; set; }
    }
}
