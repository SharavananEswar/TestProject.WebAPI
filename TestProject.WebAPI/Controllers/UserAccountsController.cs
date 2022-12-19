using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using System.Web.Http.Description;
using ZipPay.Service.Contracts;
using ZipPay.WebApi.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestProject.WebAPI.Controllers
{
    [ApiController]
    public class UserAccountsController : ControllerBase
    {
        private readonly ILogger<UserAccountsController> _logger;
        private readonly IUserAccountsService _userAccountService;

        public UserAccountsController(
            IUserAccountsService userAccountService,
            ILogger<UserAccountsController> logger)
        {
            _userAccountService = userAccountService;
            _logger = logger;
        }

        // POST api/v1/<users>
        [Microsoft.AspNetCore.Mvc.Route("api/v1/useraccount")]
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [ResponseType(typeof(UserAccountResponse))]
        public async Task<IActionResult> Create([System.Web.Http.FromBody] CreateUserAccountRequest request)
        {
            try
            {
                //TODO: uri is empty.
                return Created("", await _userAccountService.CreateAsync(request));
            }
            catch (ArgumentNullException ex)
            {
                _logger?.LogError($"Exception while creating user account. UserId: {request.UserId}", ex);
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                _logger?.LogError($"Exception while creating user account. UserId: {request.UserId}", ex);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger?.LogError($"Exception while creating user account. UserId: {request.UserId}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Exception while creating user account. UserId: {request.UserId}");
            }            
        }

        // POST api/v1/<users>
        [Microsoft.AspNetCore.Mvc.Route("api/v1/useraccounts")]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [ResponseType(typeof(UsersAccountsListResponse))]
        public async Task<IActionResult> List([FromQuery] int page = 0, [FromQuery] int pageSize = 100)
        {
            try
            {
                return Ok(await _userAccountService.ListAsync(page, pageSize));
            }
            catch (Exception ex)
            {
                _logger?.LogError($"Exception while getting user accounts", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Exception while getting user accounts");
            }
        }
    }
}
