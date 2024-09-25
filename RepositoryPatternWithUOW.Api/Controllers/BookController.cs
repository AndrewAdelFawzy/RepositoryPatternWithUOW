using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Consts;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;
using RepositoryPatternWithUOW.EF;

namespace RepositoryPatternWithUOW.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public BookController(IUnitOfWork unitOfWork)
		{
			 _unitOfWork = unitOfWork;
		}

		[HttpGet]
		public IActionResult GetById(int id)
		{
			return Ok(_unitOfWork.Books.GetById(1));
		}


		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			return Ok(_unitOfWork.Books.GetAll());
		}

		[HttpGet("GetAllByOrder")]
		public IActionResult GetAllByOrder()
		{
			return Ok(_unitOfWork.Books.FindAll(b => b.Title.Contains("book"),null,null,b=>b.Id,OrderBy.Descending));
		}

		[HttpGet("GetByName")]
		public IActionResult GetByName(string title)
		{
			return Ok(_unitOfWork.Books.Find(b => b.Title == title, new[] {"Author"} ));
		}

		[HttpGet("GetAllWithAuthors")]
		public IActionResult GetAllWithAuthors()
		{
			return Ok(_unitOfWork.Books.FindAll(b => b.Title.Contains("book"), new[] { "Author" }));
		}

		[HttpPost("AddOne")]
		public IActionResult AddOne([FromForm]Book book)
		{
			var Addedbook = _unitOfWork.Books.Add(book);

			_unitOfWork.Commit();

			return Ok(Addedbook);
		}

		
	}
}
