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

        [HttpGet("EmployeInnerJoin")]
        public IActionResult getEmployeeInnerJoin()
        {
            var data = _layer.get();
            return Ok(data);
        }

        [HttpGet("EmployeeLeftjoin")]
        public IActionResult getEmployeeLeftJoin()
        {
            var data = _layer.leftjoin();
            return Ok(data);
        }

        [HttpGet("EmployeGroupJoin")]
        public IActionResult getEmployeeGroupJoin()
        {
            var data = _layer.groupJoin();
            return Ok(data);
        }
    }
}
