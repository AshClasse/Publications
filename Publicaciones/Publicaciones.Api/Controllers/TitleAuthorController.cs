using Microsoft.AspNetCore.Mvc;
using Publicaciones.Api.Models.Modules.TitleAuthor;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interfaces;

namespace Publicaciones.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TitleAuthorController : ControllerBase
	{
		private readonly ITitleAuthorRepository _titleAuthorRepository;
		public TitleAuthorController(ITitleAuthorRepository titleAuthorRepository)
		{
			this._titleAuthorRepository = titleAuthorRepository;
		}

		[HttpGet("GetTitlesAuthors")]
		public IActionResult GetTitleAuthors()
		{
			var titleAuthors = this._titleAuthorRepository.GetEntities().Select(ta => new TitleAuthorGetModel()
			{
				Au_ID = ta.Au_ID,
				Title_ID = ta.Title_ID,
				Au_Ord = ta.Au_Ord,
				RoyaltyPer = ta.RoyaltyPer,
				ChangeDate = ta.CreationDate,
				ChangeUser = ta.IDCreationUser
			}).ToList();

			return Ok(titleAuthors);
		}

		[HttpGet("GetTitlesAuthorByID")]
		public IActionResult GetTitlesAuthorByID(int title_ID, int author_ID)
		{
			var titleAuthors = this._titleAuthorRepository.GetEntityByID(title_ID, author_ID);
			return Ok(titleAuthors);
		}

		[HttpGet("GetTitlesAuthorByAuthor")]
		public IActionResult GetTitlesAuthorByAuthor(int authorID)
		{
			var titleAuthors = this._titleAuthorRepository.GetTitleAuthorByAuthor(authorID);
			return Ok(titleAuthors);
		}

		[HttpGet("GetTitlesAuthorByAuthorOrder")]
		public IActionResult GetTitlesAuthorByAuthorOrder(int authorOrd)
		{
			var titleAuthors = this._titleAuthorRepository.GetTitleAuthorByAuthorOrder(authorOrd);
			return Ok(titleAuthors);
		}

		[HttpGet("GetTitlesAuthorByRoyalty")]
		public IActionResult GetTitlesAuthorByRoyalty(int royalty)
		{
			var titleAuthors = this._titleAuthorRepository.GetTitleAuthorByRoyalty(royalty);
			return Ok(titleAuthors);
		}

		[HttpGet("GetTitlesAuthorByTitle")]
		public IActionResult GetTitlesAuthorByTitle(int title)
		{
			var titleAuthors = this._titleAuthorRepository.GetTitleAuthorByTitle(title);
			return Ok(titleAuthors);
		}

		[HttpPost("SaveTitleAuthor")]
		public IActionResult Post([FromBody] TitleAuthorAddModel titleAuthorAdd)
		{
			if (!_titleAuthorRepository.ExistsInAuthors(titleAuthorAdd.Au_ID))
			{
				return BadRequest("Non-Existent Author.");
			}

			TitleAuthor titleAuthor = new TitleAuthor()
			{
				Title_ID = titleAuthorAdd.Title_ID,
				Au_ID = titleAuthorAdd.Au_ID,
				Au_Ord = titleAuthorAdd.Au_Ord,
				RoyaltyPer= titleAuthorAdd.RoyaltyPer,			
				CreationDate = titleAuthorAdd.ChangeDate,
				IDCreationUser = titleAuthorAdd.ChangeUser,
			};

			this._titleAuthorRepository.Save(titleAuthor);
			return Created("Object Created", titleAuthor);
		}

		[HttpPut("UpdateTitleAuthor")]
		public IActionResult Put([FromBody] TitleAuthorUpdateModel titleAuthorUpdate)
		{
			TitleAuthor titleAuthor = new TitleAuthor()
			{
				Title_ID = titleAuthorUpdate.Title_ID,
				Au_ID = titleAuthorUpdate.Au_ID,
				Au_Ord = titleAuthorUpdate.Au_Ord,
				RoyaltyPer = titleAuthorUpdate.RoyaltyPer,
				ModifiedDate = titleAuthorUpdate.ChangeDate,
				IDModifiedUser = titleAuthorUpdate.ChangeUser
			};
			this._titleAuthorRepository.Update(titleAuthor);
			return Ok();
		}

	}
}
