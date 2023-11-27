using Microsoft.Extensions.Configuration;
using Publicaciones.Application.Dtos.Pub_Info;
using Publicaciones.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Application.Validations
{
	public static class Pub_InfoValidation
	{ 
		private static void CommonValidation(int changeUser, int pubId, byte[]? logo, string? pr_Info, IConfiguration configuration)
		{
			if (changeUser <= 0)
			{
				string errorMessage = $"{configuration["ValidationMessage:changeUserIsPositiveInt"]}";
				throw new Pub_InfoServiceException(errorMessage);
			}

			if (pubId <= 0)
			{
				string errorMessage = $"{configuration["ValidationMessage:pubInfoPubIDIsPositiveInt"]}";
				throw new Pub_InfoServiceException(errorMessage);
			}

			if(pubId.GetType() != typeof(int)) 
			{
				string errorMessage = $"{configuration["ValidationMessage:pubInfoPubIDIsInt"]}";
				throw new Pub_InfoServiceException(errorMessage);
			}

			if(logo.GetType() != typeof(byte))
			{
				string errorMessage = $"{configuration["ValidationMessage:pubInfoLogoIsByte"]}";
				throw new Pub_InfoServiceException(errorMessage);
			}

			if(pr_Info.GetType() != typeof(string))
			{
				string errorMessage = $"{configuration["ValidationMessage:pubInfoContainsOnlyLetters"]}";
				throw new Pub_InfoServiceException(errorMessage);
			}
		}

		public static void Validation(Pub_InfoDtoAdd pub_InfoDtoAdd, IConfiguration configuration)
		{
			CommonValidation(pub_InfoDtoAdd.ChangeUser, pub_InfoDtoAdd.PubId, pub_InfoDtoAdd.Logo, pub_InfoDtoAdd.Pr_Info, configuration);
		}

		public static void Validation(Pub_InfoDtoUpdate pub_InfoDtoUpdate, IConfiguration configuration)
		{
			CommonValidation(pub_InfoDtoUpdate.ChangeUser, pub_InfoDtoUpdate.PubId, pub_InfoDtoUpdate.Logo, pub_InfoDtoUpdate.Pr_Info, configuration);
		}
	}
}
