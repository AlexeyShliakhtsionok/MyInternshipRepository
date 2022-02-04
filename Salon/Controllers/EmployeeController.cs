using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;


namespace Salon.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _employeeServices;

        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [HttpGet]
        [Route("GetEmployeeById")]
        public ActionResult<EmployeeModel> GetEmployeeById(int id)
        {
            var employee = _employeeServices.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound("InvalidId");
            }

            return Ok(employee);
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public ActionResult<IEnumerable<EmployeeModel>> GetEmployees()
        {
            var employees = _employeeServices.GetAllEmployees();
            return Ok(employees);
        }

        [HttpPost]
        [Route("GetToken")]
        public IActionResult Token(string employeeEmail, string password)
        {
            var identity = GetIdentity(employeeEmail, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.AuthOptions.ISSUER,
                    audience: AuthOptions.AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                employeeEmail = identity.Name,
            };
            return Ok(response);
        }

        private ClaimsIdentity GetIdentity(string email, string password)
        {
            IEnumerable<EmployeeModel> employees = _employeeServices.GetAllEmployees();

            var employee = employees.FirstOrDefault(e => e.Email == email && e.Password == password);

            if (employee != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, employee.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, employee.Role.ToString())
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }
    }
}
