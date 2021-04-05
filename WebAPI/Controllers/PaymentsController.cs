using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        IPaymentManager _paymentManager;
        public PaymentsController(IPaymentManager paymentManager)
        {
            _paymentManager = paymentManager;
        }

        [HttpPost("add")]
        public IActionResult Add(Payment payment)
        {
            var result = _paymentManager.Add(payment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
