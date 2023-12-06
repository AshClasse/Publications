using Microsoft.AspNetCore.Mvc;
using Publicaciones.Api.Models.Modules.TitleAuthor;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Dtos.TitleAuthor;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interfaces;

namespace Publicaciones.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TitleAuthorController : ControllerBase
	{
		private readonly ITitleAuthorService titleAuthorService;
		public TitleAuthorController(ITitleAuthorService titleAuthorService)
		{
			this.titleAuthorService = titleAuthorService;
		}

		[HttpGet("GetTitlesAuthors")]
		public IActionResult GetTitleAuthors()
		{
			var result = this.titleAuthorService.GetAll();
			if (!result.Success)
			{
				return BadRequest(result);
			}
            return Ok(result);
        }

		[HttpGet("GetTitlesAuthorByID")]
		public IActionResult GetTitlesAuthorByID(int title_ID, int author_ID)
		{
            var existsInTitlesResult = this.titleAuthorService.ExistInTitles(title_ID);
            var existsInAuthorResult = this.titleAuthorService.ExistInAuthor(author_ID);

            if (!existsInTitlesResult.Success)
            {
                return BadRequest(existsInTitlesResult.Message);
            }
            if (!existsInAuthorResult.Success)
            {
                return BadRequest(existsInAuthorResult.Message);
            }
            var result = this.titleAuthorService.GetTitleAuthorById(title_ID, author_ID);
			if (!result.Success)
			{
				BadRequest(result);
			}
			return Ok(result);
		}

		[HttpGet("GetTitlesAuthorByAuthor")]
		public IActionResult GetTitlesAuthorByAuthor(int authorID)
		{
            var existsInAuthorResult = this.titleAuthorService.ExistInAuthor(authorID);
            if (!existsInAuthorResult.Success)
            {
                return BadRequest(existsInAuthorResult.Message);
            }
            var result = this.titleAuthorService.GetTitleByAu_ID(authorID);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
		}

		[HttpGet("GetTitlesAuthorByAuthorOrder")]
		public IActionResult GetTitlesAuthorByAuthorOrder(int authorOrd)
		{
			var result = this.titleAuthorService.GetTitleAuthorByAuthorOrder(authorOrd);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

		[HttpGet("GetTitlesAuthorByRoyalty")]
		public IActionResult GetTitlesAuthorByRoyalty(int royalty)
		{
			var result = this.titleAuthorService.GetTitleAuthorByRoyalty(royalty);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

		[HttpGet("GetTitlesAuthorByTitleID")]
		public IActionResult GetTitlesAuthorByTitle(int title)
		{
            var existsInTitlesResult = this.titleAuthorService.ExistInTitles(title);
            if (!existsInTitlesResult.Success)
            {
                return BadRequest(existsInTitlesResult.Message);
            }
            var result = this.titleAuthorService.GetTitleAuthorByTitle(title);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

		[HttpPost("SaveTitleAuthor")]
		public IActionResult Post([FromBody] TitleAuthorDtoAdd titleAuthorDtoAdd)
		{
            var existsInTitlesResult = this.titleAuthorService.ExistInTitles(titleAuthorDtoAdd.Title_ID);
            var existsInAuthorResult = this.titleAuthorService.ExistInAuthor(titleAuthorDtoAdd.Au_ID);

            if (!existsInTitlesResult.Success)
            {
                return BadRequest(existsInTitlesResult.Message);
            }
            if (!existsInAuthorResult.Success)
            {
                return BadRequest(existsInAuthorResult.Message);
            }

            var result = this.titleAuthorService.Save(titleAuthorDtoAdd);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Created("Object Created", result);
		}

		[HttpPost("UpdateTitleAuthor")]
		public IActionResult Put([FromBody] TitleAuthorDtoUpdate titleAuthorDtoUpdate)
		{
            var existsInTitlesResult = this.titleAuthorService.ExistInTitles(titleAuthorDtoUpdate.Title_ID);
            var existsInAuthorResult = this.titleAuthorService.ExistInAuthor(titleAuthorDtoUpdate.Au_ID);

            if (!existsInTitlesResult.Success)
            {
                return BadRequest(existsInTitlesResult.Message);
            }
            if (!existsInAuthorResult.Success)
            {
                return BadRequest(existsInAuthorResult.Message);
            }
            var result = this.titleAuthorService.Update(titleAuthorDtoUpdate);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
		}

        [HttpPost("RemoveTitleAuthor")]
        public IActionResult Remove([FromBody] TitleAuthorDtoRemove titleAuthorDtoRemove)
        {
            var result = this.titleAuthorService.Remove(titleAuthorDtoRemove);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
