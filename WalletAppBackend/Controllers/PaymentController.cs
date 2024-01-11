using Microsoft.AspNetCore.Mvc;

namespace WalletAppBackend.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpGet("due")]
        public ActionResult GetNoPaymentDue()
        {
            var currentMonth = DateTime.Now.ToString("MMMM");

            return Ok($"You've paid your {currentMonth} balance.");
        }
    }
}
