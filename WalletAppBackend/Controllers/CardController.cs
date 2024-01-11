using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WalletAppBackend.Core.Models;
using WalletAppBackend.Services.Interfaces;

namespace WalletAppBackend.Controllers
{
    [Route("api/cards")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICardService _cardService;
        private readonly IMapper _mapper;

        public CardController(
            IUserService userService,
            ICardService cardService,
            IMapper mapper)
        {
            _userService = userService;
            _cardService = cardService;
            _mapper = mapper;
        }

        [HttpPost("balance/{userId}")]
        public async Task<ActionResult> CreateCard([FromQuery] int userId)
        {
            var user = await _userService.GetUserAsync(userId);

            if (user is null)
            {
                return BadRequest("User is not found.");
            }

            var card = await _cardService.CreateCardAsync(userId);
            var cardClient = _mapper.Map<CardClient>(card);

            return Ok(cardClient);
        }


        [HttpGet("balance/{userId}/{cardId}")]
        public async Task<ActionResult> GetCardBalance([FromQuery] int userId, [FromQuery] int cardId)
        {
            var card = await _cardService.GetCardAsync(userId, cardId);

            if (card is null)
            {
                return BadRequest("Can not find card for such user.");
            }

            var cardClient = _mapper.Map<CardClient>(card);

            return Ok(cardClient);
        }
    }
}
