using EMployeeLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Linq_Joins.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employee : ControllerBase
    {
        private readonly IEmployee _layer;

        public Employee(IEmployee layer)
        {
            _layer = layer;
        }

        [HttpGet("EmployeGEt")]
         public IActionResult grtEmployee()
        {
            var data = _layer.get();
            return Ok(data);
        }
    }
}
