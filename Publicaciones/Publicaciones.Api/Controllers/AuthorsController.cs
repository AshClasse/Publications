using Microsoft.AspNetCore.Mvc;
using Publicaciones.Api.Models.Modules.Authors;
using Publicaciones.Api.Models.Modules.TitleAuthor;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interfaces;
using Publicaciones.Infrastructure.Repository;

namespace Publicaciones.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorsController : ControllerBase
	{
		private readonly IAuthorsRepository _authorsRepository;	
		public AuthorsController(IAuthorsRepository authorsRepository)
		{
			_authorsRepository = authorsRepository;
		}

		[HttpGet("GetAuthors")]
		public IActionResult GetAuthors()
		{
			var authors = this._authorsRepository.GetEntities().Select(a => new AuthorsGetModel()
			{
				Au_ID = a.Au_ID,
				Au_FName = a.Au_FName,
				Au_LName = a.Au_LName,
				Address = a.Address,
				Phone = a.Phone,
				City = a.City,
				State = a.State,
				Zip = a.Zip,
				Contract = a.Contract
			}).ToList();

			return Ok(authors);
		}

		[HttpGet("GetAuthorByID")]
		public IActionResult GetAuthorByID(int ID)
		{
			var authors = this._authorsRepository.GetEntityByID(ID);
			return Ok(authors);
		}

		[HttpGet("GetAuthorByCity")]
		public IActionResult GetAuthorByCity(string city)
		{
			var authors = this._authorsRepository.GetAuthorsByCity(city);
			return Ok(authors);
		}

		[HttpGet("GetAuthorByState")]
		public IActionResult GetAuthorByState(string state)
		{
			var authors = this._authorsRepository.GetAuthorsByState(state);
			return Ok(authors);
		}

		[HttpGet("GetAuthorByContract")]
		public IActionResult GetAuthorByContract(int contract)
		{
			var authors = this._authorsRepository.GetAuthorsByContract(contract);
			return Ok(authors);
		}

		[HttpPost("SaveAuthor")]
		public IActionResult Post([FromBody] AuthorsAddModel authorAdd)
		{
			Authors authors = new Authors()
			{
				CreationDate = authorAdd.ChangeDate,
				IDCreationUser = authorAdd.ChangeUser,
				Au_FName = authorAdd.Au_FName,
				Au_LName = authorAdd.Au_LName,
				Phone = authorAdd.Phone,
				Address	= authorAdd.Address,
				City = authorAdd.City,
				State = authorAdd.State,
				Zip = authorAdd.Zip,
				Contract = authorAdd.Contract
			};
			this._authorsRepository.Save(authors);
			return Created("Object Created", authors);
		}

		[HttpPut("UpdateAuthor")]
		public IActionResult Put([FromBody] AuthorsUpdateModel authorUpdate)
		{
			Authors authors = new Authors()
			{
				Au_ID = authorUpdate.Au_ID,
				Au_FName = authorUpdate.Au_FName,
				Au_LName = authorUpdate.Au_LName,
				Phone = authorUpdate.Phone,
				Address = authorUpdate.Address,
				City = authorUpdate.City,
				State = authorUpdate.State,
				Zip = authorUpdate.Zip,
				Contract = authorUpdate.Contract,
				ModifiedDate = authorUpdate.ChangeDate,
				IDModifiedUser = authorUpdate.ChangeUser
			};
			this._authorsRepository.Update(authors);
			return Ok();
		}

	}
}
