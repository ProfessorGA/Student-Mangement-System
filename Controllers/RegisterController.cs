using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Mangement_System.Models;
using System.Data.SqlClient;

namespace Student_Mangement_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        SqlConnection connection = null;

        public RegisterController(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString()); 

        }

        [HttpPost]
        [Route("RegistrationNewUser")]
        public Response RegistrationNewUser(Users users)
        {
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.Registartion(users, connection);
            return response;
        }

        [HttpPost]
        [Route("Login")]
        public Response Login(Users users)
        {
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.Login(users, connection);
            return response;
        }
    }
}
