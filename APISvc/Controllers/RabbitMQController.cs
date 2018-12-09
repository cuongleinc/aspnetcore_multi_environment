using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APISvc.DTOs;
using APISvc.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APISvc.Controllers
{
    [Produces("application/json")]
    [Route("api/RabbitMQ")]
    public class RabbitMQController : Controller
    {
        // POST api/values
        [HttpPost]
        public SuccessMsg sendMsg([FromBody] RabbitMsg msg)
        {
            RabbitMQUtils.sendMSG(msg.VendingCode, msg.Message);
            return new SuccessMsg(ApplicationMessage.SUCCESS, ApplicationMessage.SUCCESS);
        }
    }
}