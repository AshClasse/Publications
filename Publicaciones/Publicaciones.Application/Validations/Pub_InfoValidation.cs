using Microsoft.Extensions.Configuration;
using Publicaciones.Application.Dtos.Pub_Info;
using Publicaciones.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Application.Validations
{
	public class Pub_InfoValidation
	{
		private readonly IConfiguration configuration;

		public Pub_InfoValidation (IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		private void CommonValidation(int changeUser, int pubId, byte[] logo, string pr_Info)
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

		public void ValidateAddPub_Info(Pub_InfoDtoAdd pub_InfoDtoAdd)
		{
			CommonValidation(pub_InfoDtoAdd.ChangeUser, pub_InfoDtoAdd.PubId, pub_InfoDtoAdd.Logo, pub_InfoDtoAdd.Pr_Info);
		}

		public void ValidateUpdatePub_Info(Pub_InfoDtoUpdate pub_InfoDtoUpdate)
		{
			CommonValidation(pub_InfoDtoUpdate.ChangeUser, pub_InfoDtoUpdate.PubId, pub_InfoDtoUpdate.Logo, pub_InfoDtoUpdate.Pr_Info);
			
			if (pub_InfoDtoUpdate.PubInfoID <= 0)
			{
				string errorMessage = $"{configuration["ValidationMessage:pubInfoIDIsPositiveInt"]}";
				throw new Pub_InfoServiceException(errorMessage);
			}

			if (pub_InfoDtoUpdate.PubInfoID.GetType() != typeof(int))
			{
				string errorMessage = $"{configuration["ValidationMessage:pubInfoIDIsInt"]}";
				throw new Pub_InfoServiceException(errorMessage);
			}
		}

		public void ValidateRemovePub_Info(Pub_InfoDtoRemove pub_InfoDtoRemove)
		{
			if (pub_InfoDtoRemove.Id <= 0)
			{
				string errorMessage = $"{configuration["ValidationMessage:pubInfoIDIsPositiveInt"]}";
				throw new Pub_InfoServiceException(errorMessage);
			}

			if (pub_InfoDtoRemove.Id.GetType() != typeof(int))
			{
				string errorMessage = $"{configuration["ValidationMessage:pubInfoIDIsInt"]}";
				throw new Pub_InfoServiceException(errorMessage);
			}

			if (!pub_InfoDtoRemove.Deleted)
			{
				string errorMessage = $"{configuration["PubInfoErrorMessage:removeErrorMessage"]}";
				throw new Pub_InfoServiceException(errorMessage);
			}
		}

	}
}
