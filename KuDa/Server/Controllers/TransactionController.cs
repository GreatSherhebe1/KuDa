using KuDa.Server.DTO;
using KuDa.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace KuDa.Server.Controllers
{
    [Route("Kuda/[group]/[controler]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService service;

        public TransactionController(ITransactionService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TransactionResponse), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TransactionResponse>> GetByID(int id, CancellationToken token)
        {
            var transaction = await service.GetTransactionByIDAsync(id, token);
            if (transaction == null)
                return NotFound();

            return Ok(transaction);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TransactionResponse>), 200)]
        public async Task<ActionResult<IEnumerable<TransactionResponse>>> GetAll(CancellationToken token)
        {
            return Ok(await service.GetAllTransactionsAsync(token));
        }

        [HttpPost]
        [ProducesResponseType(typeof(TransactionResponse), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<TransactionResponse>> Create(TransationRequest dto, CancellationToken token)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var transaction = await service.CreateTransactionAsync(dto, token);
            return CreatedAtAction(nameof(GetByID), new { id = transaction.ID }, transaction);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TransactionResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TransactionResponse>> Update(int id, TransationRequest dto, CancellationToken token)
        {
            if (dto.ID != id)
                return BadRequest("different ID in request and body");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var transaction = await service.UpdateTransactionAsync(dto, token);

            if (transaction == null)
                return NotFound();

            return Ok(transaction);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id, CancellationToken token)
        {
            var transaction = await service.GetTransactionByIDAsync(id, token);
            if (transaction == null)
                return NotFound();

            return NoContent();
        }
    }
}
