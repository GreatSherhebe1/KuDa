using KuDa.Server.DTO;
using KuDa.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KuDa.Server.Controllers
{
    [Route("Kuda/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService) 
        {
            this.userService = userService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserResponse), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UserResponse>> GetByID(int id, CancellationToken token)
        {
            var user = await userService.GetUserByIDAsync(id, token);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserResponse>), 200)]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetAll(CancellationToken token)
        {
            return Ok(await userService.GetAllUsersAsync(token));
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserResponse), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<UserResponse>> Create(UserRequest dto, CancellationToken token)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await userService.CreateUserAsync(dto, token);
            return CreatedAtAction(nameof(GetByID), new { id = user.ID }, user);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UserResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UserResponse>> Update(int id, UserRequest dto, CancellationToken token)
        {
            if (dto.id != id)
                return BadRequest("different ID in request and body");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var transaction = await userService.UpdateUserAsync(id, dto, token);

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
