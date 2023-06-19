using Business.Abstract;
using DTO.DTOEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_9F.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeService _employeeService;

		public EmployeeController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var values=_employeeService.GetAll();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult Add(EmployeeDTO p)
		{
			_employeeService.Insert(p);
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var values = _employeeService.GetById(id);
			if (values==null)
			{
				return NotFound();
			}
			return Ok(values);
		}

		[HttpPut]
		public IActionResult Update(EmployeeDTO p)
		{
			_employeeService.Update(p);
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_employeeService.Delete(id);
			return Ok();
		}
	}
}
