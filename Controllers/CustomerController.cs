using ShekelWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ShekelWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        SqlConnection connection = new SqlConnection(@"server=NOACOHEN-PC\SQLEXPRESS; database=Shekel; Integrated Security=true;");

        [HttpGet]
        [Route("GetList")]
        public GetResponse GetList()
        {
            GetResponse getResponse = new GetResponse();
            API api = new API();
            getResponse = api.GetList(connection);
            return getResponse;
        }

        [HttpPost]
        [Route("AddCustomer")]
        public PostResponse AddCustomer(Customer customer)
        {
            PostResponse postResponse = new PostResponse();
            API api = new API();
            postResponse = api.AddCustomer(connection, customer);
            return postResponse;
        }
    }
}
