using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;

namespace RepositoryPatternWithUOW.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public AuthorController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpGet]
		public IActionResult GetById(int id)
		{
			return Ok(_unitOfWork.Authors.GetById(1));
		}

		[HttpGet("GetByIdAsync")]
		public async Task <IActionResult> GetByIdAsync(int id)
		{
			return Ok(await _unitOfWork.Authors.GetByIdAsync(1));
		}
	}
}
