using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace YourNamespace.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserController : ControllerBase
  {
    private readonly IConfiguration _configuration;

    public UserController(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(string id)
    {
      using (var connection = new SqlConnection(_configuration.GetConnectionString("YourConnectionString")))
      {
        connection.Open();

        var query = $"SELECT * FROM Users WHERE Id = @id";
        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();
        // Process the results
        // ...
      }

      return Ok();
    }
  }
}