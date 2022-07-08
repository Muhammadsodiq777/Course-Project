using AutoMapper;
using Course_Project.Data;
using Course_Project.IRepository;
using Course_Project.Models;
using Course_Project.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;
        private ApiUser _user;
        private readonly IUnitOfWork _unitOfWork;



        public AccountController(UserManager<ApiUser> userManager,
            ILogger<AccountController> logger, IMapper mapper,
            IAuthManager auth, ApiUser user, IUnitOfWork unit)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _authManager = auth;
            _user = user;
            _unitOfWork = unit;
        }
        [HttpPost]
        [Route("register")]

        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation($"Registration Attempt for {userDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<ApiUser>(userDTO);
            user.UserName = userDTO.Email;
            var result = await _userManager.CreateAsync(user, userDTO.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest("User Registration Attemp Failed");
            }
            await _userManager.AddToRolesAsync(user, userDTO.Roles);

            return Accepted();
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO userDTO)
        {
            _logger.LogInformation($"Login Attempt for {userDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _authManager.ValidateUser(userDTO))
            {
                return Unauthorized();
            }

            return Accepted(new { Token = await _authManager.CreateToken() });
        }

        [HttpDelete("{id:string}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (id.Equals(null))
            {
                _logger.LogError($"Invalid ID attemp in {nameof(DeleteUser)}");
                return BadRequest(ModelState);
            }
            var user = await _unitOfWork.Users.Get(q => q.Id == id, null);
            if (user == null)
            {
                _logger.LogError($"Invalid Delete attemp in {nameof(DeleteUser)}");
                return BadRequest("Submitted data is invalid");
            }

            await _unitOfWork.Users.Delete(user.Id);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
