using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using System.Web.Http.Description;
using ZipPay.Service.Contracts;
using ZipPay.WebApi.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestProject.WebAPI.Controllers
{
    //[System.Web.Http.Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUsersService _usersService;

        public UsersController(
            IUsersService usersService, ILogger<UsersController> logger)
        {
            _usersService = usersService;
            _logger = logger;
        }

        // POST api/v1/<users>
        [Microsoft.AspNetCore.Mvc.Route("api/v1/user")]
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [ResponseType(typeof(UserResponse))]
        public IActionResult Create([System.Web.Http.FromBody] CreateUserRequest request)
        {
            try
            {
                //TODO: uri is empty.
                return Created("", _usersService.Create(request));
            }
            catch (ArgumentNullException ex)
            {
                _logger?.LogError($"Exception while creating user. UserEmail: {request.EmailAddress}", ex);
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                _logger?.LogError($"Exception while creating user. UserEmail: {request.EmailAddress}", ex);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger?.LogError($"Exception while creating user. UserEmail: {request.EmailAddress}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Exception while creating user. UserEmail: {request.EmailAddress}");
            }            
        }

        // GET api/v1/<users>/{id}
        [Microsoft.AspNetCore.Mvc.Route("api/v1/user/{id}")]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [ResponseType(typeof(UserResponse))]
        public IActionResult Get(long id)
        {
            try
            {
                return Ok(_usersService.Get(id));
            }
            catch (ArgumentNullException ex)
            {
                _logger?.LogError($"Exception while getting users", ex);
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                _logger?.LogError($"Exception while getting user. UserId: {id}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Exception while getting user. UserId: {id}");
            }
        }

        // POST api/v1/<users>
        [Microsoft.AspNetCore.Mvc.Route("api/v1/users")]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [ResponseType(typeof(UsersListResponse))]
        public IActionResult List([FromQuery] int page = 0, [FromQuery] int pageSize = 100)
        {
            try
            {
                return Ok(_usersService.List(page, pageSize));
            }
            catch (Exception ex)
            {
                _logger?.LogError($"Exception while getting users", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Exception while getting users");
            }
        }
    }
}
