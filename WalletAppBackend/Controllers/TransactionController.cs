using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WalletAppBackend.Core.Models;
using WalletAppBackend.DatabaseProvider.Models;
using WalletAppBackend.Services.Interfaces;

namespace WalletAppBackend.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public TransactionController(
            ITransactionService transactionService,
            IUserService userService,
            IMapper mapper)
        {
            _transactionService = transactionService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        public IActionResult GetTransaction([FromQuery] int userId)
        {
            var transactions = _transactionService.GetTransactions(userId);

            return Ok(transactions);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionClient transactionClient)
        {
            var recipient = await _userService.GetUserAsync(transactionClient.UserRecipientId);
            var sender = await _userService.GetUserAsync(transactionClient.UserSenderId);

            if (recipient is null || sender is null)
            {
                return BadRequest("Can not find such users.");
            }

            var transaction = _mapper.Map<Transaction>(transactionClient);
            transaction = await _transactionService.CreateAsync(transaction);
            transactionClient = _mapper.Map<TransactionClient>(transaction);

            return Ok(transactionClient);
        }
    }

}
