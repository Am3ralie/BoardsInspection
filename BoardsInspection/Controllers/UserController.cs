using BoardsInspection.Infrastructure.Data;
using BoardsInspection.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BoardsInspection.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Получить всех пользователей (без паролей)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _context.Users
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    Email = u.Email,
                    RoleId = u.RoleId
                }).ToListAsync();

            return Ok(users);
        }

        // Создать пользователя
        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUser([FromBody] CreateUserDTO userDto)
        {
            var user = new User
            {
                Email = userDto.Email,
                Password = userDto.Password,
                RoleId = userDto.RoleId
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                RoleId = user.RoleId
            });
        }

        // Обновить пользователя
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserDTO userDto)
        {
            if (id != userDto.Id) return BadRequest();

            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            user.Email = userDto.Email;
            if (!string.IsNullOrEmpty(userDto.Password))
            {
                user.Password = userDto.Password;
            }
            user.RoleId = userDto.RoleId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Удалить пользователя
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Логин
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login([FromBody] LoginDTO loginDto)
        {
            var user = await _context.Users
                .Where(u => u.Email == loginDto.Email && u.Password == loginDto.Password)
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    Email = u.Email,
                    RoleId = u.RoleId
                })
                .FirstOrDefaultAsync();

            if (user == null)
                return Unauthorized();

            return Ok(user);
        }
    }

    // DTO классы для безопасного обмена
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public int RoleId { get; set; }
    }

    public class CreateUserDTO
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }
    }

    public class UpdateUserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string? Password { get; set; }
        public int RoleId { get; set; }
    }

    public class LoginDTO
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
