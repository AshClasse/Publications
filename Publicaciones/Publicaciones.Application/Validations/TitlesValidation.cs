using Microsoft.Extensions.Configuration;
using Publicaciones.Application.Dtos.RoySched;
using Publicaciones.Application.Dtos.Titles;
using Publicaciones.Application.Exceptions;
using Publicaciones.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Publicaciones.Application.Validations
{
	public static class TitlesValidation
	{
		private static void CommonValidation(int changeUser, string title, string type, int pubId, decimal? price, decimal? advance, int? royalty, int? ytd_sales, string? notes, DateTime? pubDate, IConfiguration configuration)
		{
			if (changeUser <= 0)
			{
				string errorMessage = configuration["ValidationMessage:changeUserIsPositiveInt"];
				throw new TitlesServiceException(errorMessage);
			}

			if (string.IsNullOrEmpty(title))
			{
				string errorMessage = configuration["ValidationMessage:titleNameRequired"];
				throw new TitlesServiceException(errorMessage);
			}

			if (!Regex.IsMatch(title, "^[a-zA-Z ]+$"))
			{
				string errorMessage = configuration["ValidationMessage:titleContainsOnlyLetters"];
				throw new TitlesServiceException(errorMessage);
			}

			if (string.IsNullOrEmpty(type))
			{
				string errorMessage = configuration["ValidationMessage:titleTypeRequired"];
				throw new TitlesServiceException(errorMessage);
			}

			if (!Regex.IsMatch(type, "^[a-zA-Z]+$"))
			{
				string errorMessage = configuration["ValidationMessage:titleTypeContainsOnlyLetters"];
				throw new TitlesServiceException(errorMessage);
			}

			if (title.Length > 80)
			{
				string errorMessage = configuration["ValidationMessage:titleLength"];
				throw new TitlesServiceException(errorMessage);
			}

			if (type.Length > 12)
			{
				string errorMessage = configuration["ValidationMessage:titleTypeLength"];
				throw new TitlesServiceException(errorMessage);
			}

			if (pubId <= 0)
			{
				string errorMessage = configuration["ValidationMessage:titlePubIdIsPositiveInt"];
				throw new TitlesServiceException(errorMessage);
			}

			if (notes != null && !Regex.IsMatch(notes, "^[a-zA-Z ]+$"))
			{
				string errorMessage = configuration["ValidationMessage:titleNotesContainsOnlyLetters"];
				throw new TitlesServiceException(errorMessage);
			}

			if (notes != null && notes.Length > 200)
			{
				string errorMessage = configuration["ValidationMessage:titleNotesLength"];
				throw new TitlesServiceException(errorMessage);
			}

			if (price.HasValue && !decimal.TryParse(price.ToString(), out _))
			{
				string errorMessage = configuration["ValidationMessage:titlePriceIsDecimal"];
				throw new TitlesServiceException(errorMessage);
			}

			if (advance.HasValue && !decimal.TryParse(advance.ToString(), out _))
			{
				string errorMessage = configuration["ValidationMessage:titleAdvanceIsDecimal"];
				throw new TitlesServiceException(errorMessage);
			}

			if (royalty.HasValue && royalty <= 0)
			{
				string errorMessage = configuration["ValidationMessage:titleRoyaltyIsPositiveInt"];
				throw new TitlesServiceException(errorMessage);
			}

			if (ytd_sales.HasValue && ytd_sales <= 0)
			{
				string errorMessage = configuration["ValidationMessage:titleYtdSalesIsPositiveInt"];
				throw new TitlesServiceException(errorMessage);
			}

			if (pubDate != null && !Regex.IsMatch(pubDate.ToString(), @"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}\.\d{3}$"))
			{
				string errorMessage = configuration["ValidationMessage:titlePubDateFormat"];
				throw new TitlesServiceException(errorMessage);
			}
		}

		public static void Validation(TitlesDtoAdd TitlesDtoAdd, IConfiguration configuration)
		{
			CommonValidation(
				TitlesDtoAdd.ChangeUser,
				TitlesDtoAdd.Title,
				TitlesDtoAdd.Type,
				TitlesDtoAdd.PubID,
				TitlesDtoAdd.Price,
				TitlesDtoAdd.Advance,
				TitlesDtoAdd.Royalty,
				TitlesDtoAdd.Ytd_Sales,
				TitlesDtoAdd.Notes,
				TitlesDtoAdd.PubDate,
				configuration
			);
		}

		public static void Validation(TitlesDtoUpdate TitlesDtoUpdate, IConfiguration configuration)
		{
			CommonValidation(
				TitlesDtoUpdate.ChangeUser,
				TitlesDtoUpdate.Title,
				TitlesDtoUpdate.Type,
				TitlesDtoUpdate.PubID,
				TitlesDtoUpdate.Price,
				TitlesDtoUpdate.Advance,
				TitlesDtoUpdate.Royalty,
				TitlesDtoUpdate.Ytd_Sales,
				TitlesDtoUpdate.Notes,
				TitlesDtoUpdate.PubDate,
				configuration
			);
		}


	}
}
