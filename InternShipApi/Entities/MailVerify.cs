using InternShipApi.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointment.Entities
{
    public class MailVerify
    {
        public int Id { get; set; }

        [ForeignKey("userId")]
        public int userId { get; set; }

        public string MailAddress { get; set; }

        public User user { get; set; }

        public bool IsVerified { get; set; }
    }
}
