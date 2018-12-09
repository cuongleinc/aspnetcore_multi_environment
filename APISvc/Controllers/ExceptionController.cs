using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APISvc.DTOs;
using APISvc.Exceptions;
using APISvc.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APISvc.Controllers
{
    [Produces("application/json")]
    [Route("api/ExceptionC")]
    public class ExceptionController : Controller
    {
        // POST api/values
        [HttpPost]
        public SuccessMsg testNotfound()
        {
            throw new NotFoundException("cuong.not.found", "cuong.not.found");
        }
    }
}