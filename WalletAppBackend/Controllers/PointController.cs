using Microsoft.AspNetCore.Mvc;
using WalletAppBackend.Services.Interfaces;

namespace WalletAppBackend.Controllers
{
    [Route("api/points")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly IPointsService _pointsService;

        public PointController(IPointsService pointsService)
        {
            _pointsService = pointsService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> GetCardBalance([FromQuery] int userId)
        {
            var points = await _pointsService.CalculatePointsAsync(userId);

            return Ok(points);
        }
    }
}
