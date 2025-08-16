using Core.DTOs.UserDTOs;
using Core.Model;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // api/users
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        // api/users/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound("Kullanıcı bulunamadı.");

            return Ok(user);
        }

        // api/users/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO loginDto)
        {
            try
            {
                var user = await _userService.LoginAsync(loginDto);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // api/users
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateDTO createDto)
        {
            var result = await _userService.CreateAsync(createDto);
            if (result == null)
                return BadRequest("Kullanıcı oluşturulamadı.");

            var userDTO = new UserDTO
            {
                Id = result.UserId,
                UserName = result.UserName,
                Email = result.UserEmail,
                UserPassword = result.UserPassword
            };
            return Ok(userDTO);
    }
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateDTO user)
        {
            var result = await _userService.UpdateAsync(id, user);
            if (result == null)
                return BadRequest("Kullanıcı oluşturulamadı.");

            
            return Ok(user);
    }

        //  api/users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteAsync(id);
            if (!result)
                return NotFound("Kullanıcı bulunamadı veya silinemedi.");

            return Ok("Kullanıcı başarıyla silindi.");
        }
    }
}
