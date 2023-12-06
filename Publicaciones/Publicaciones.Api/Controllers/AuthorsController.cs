using Microsoft.AspNetCore.Mvc;
using Publicaciones.Api.Models.Modules.Authors;
using Publicaciones.Api.Models.Modules.TitleAuthor;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Dtos.Authors;
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
		private readonly IAuthorsService _authorsService;	
		public AuthorsController(IAuthorsService _authorsService)
		{
			this._authorsService = _authorsService;
		}

		[HttpGet("GetAuthors")]
		public IActionResult GetAuthors()
		{
			var result = this._authorsService.GetAll();
			if (!result.Success)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}

		[HttpGet("GetAuthorByID")] 
		public IActionResult GetAuthorByID(int ID)
        {
			var result = this._authorsService.GetById(ID);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
		}

		[HttpGet("GetAuthorByCity")]
		public IActionResult GetAuthorByCity(string city)
		{
			var authors = this._authorsService.GetAuthorsByCity(city);
			return Ok(authors);
		}

		[HttpGet("GetAuthorByState")]
		public IActionResult GetAuthorByState(string state)
		{
			var authors = this._authorsService.GetAuthorsByState(state);
			return Ok(authors);
		}

		[HttpGet("GetAuthorByContract")]
		public IActionResult GetAuthorByContract(int contract)
		{
			var authors = this._authorsService.GetAuthorsByContract(contract);
			return Ok(authors);
		}

		[HttpPost("SaveAuthor")]
		public IActionResult Save([FromBody] AuthorsDtoAdd authorAdd)
		{
			var result = this._authorsService.Save(authorAdd);
			if (!result.Success)
				return BadRequest(result);

			return Ok(result);
		}    

		[HttpPost("UpdateAuthor")]
		public IActionResult Update([FromBody] AuthorsDtoUpdate authorsDtoUpdate)
		{
			var result = this._authorsService.Update(authorsDtoUpdate); 
			if(!result.Success)
				return BadRequest(result);
			
			return Ok(result);
		}

        [HttpPut("DeleteAuthor")]
        public IActionResult Delete([FromBody] AuthorsDtoRemove authorsDtoRemove)
        {
            var result = this._authorsService.Remove(authorsDtoRemove);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

    }
}
