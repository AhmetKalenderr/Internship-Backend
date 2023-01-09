using Appointment.Interfaces.IManager;
using InternShipApi.Core;
using InternShipApi.DatabaseObject.Request;
using InternShipApi.Services.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Appointment.Controllers
{
    [Route("api/[controller]")]
    public class MailVerifyController
    {
        private readonly IMailVerifiedManager manager;
        public MailVerifyController(IMailVerifiedManager manager)
        {
            this.manager = manager; 
        }

        [HttpGet("Verifiedmail")]
        public void VerifyMail([FromQuery]string token)
        {
            TokenUtility tokenUtility = new();
            Cryption crt = new Cryption();
            manager.MailVerify(tokenUtility.getUserFromMailVerification(token));
        }
    }
}
