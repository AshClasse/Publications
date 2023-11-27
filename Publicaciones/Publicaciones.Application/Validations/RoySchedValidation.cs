using Microsoft.Extensions.Configuration;
using Publicaciones.Application.Dtos.RoySched;
using Publicaciones.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Application.Validations
{
	public static class RoySchedValidation
	{
		private static void CommonValidation(int changeUser, int titleId, int? loRange, int? HiRange, int? royalty, IConfiguration configuration)
		{
			if (changeUser <= 0)
			{
				string errorMessage = $"{configuration["ValidationMessage:changeUserIsPositiveInt"]}";
				throw new RoySchedServiceException(errorMessage);
			}

			if (titleId == 0)
			{
				string errorMessage = $"{configuration["ValidationMessage:roySchedTitleIDRequired"]}";
				throw new RoySchedServiceException(errorMessage);
			}

			if (titleId < 0)
			{
				string errorMessage = $"{configuration["ValidationMessage:roySchedTitleIdIsPositiveInt"]}";
				throw new RoySchedServiceException(errorMessage);
			}

			if (titleId.GetType() != typeof(int))
			{
				string errorMessage = $"{configuration["ValidationMessage:roySchedTitleIDIsInt"]}";
				throw new RoySchedServiceException(errorMessage);
			}

			if (loRange.GetType() != typeof(int))
			{
				string errorMessage = $"{configuration["ValidationMessage:roySchedloRangeIsInt"]}";
				throw new RoySchedServiceException(errorMessage);
			}

			if (HiRange.GetType() != typeof(int))
			{
				string errorMessage = $"{configuration["ValidationMessage:roySchedHiRangeIsInt"]}";
				throw new RoySchedServiceException(errorMessage);
			}

			if (royalty.GetType() != typeof(int))
			{
				string errorMessage = $"{configuration["ValidationMessage:roySchedRoyaltyIsInt"]}";
				throw new RoySchedServiceException(errorMessage);
			}
		}

		public static void Validation(RoySchedDtoAdd RoySchedDtoAdd, IConfiguration configuration)
		{
			CommonValidation(RoySchedDtoAdd.ChangeUser, RoySchedDtoAdd.Title_ID, RoySchedDtoAdd.LoRange, RoySchedDtoAdd.HiRange, RoySchedDtoAdd.Royalty, configuration);
		}

		public static void Validation(RoySchedDtoUpdate RoySchedDtoUpdate, IConfiguration configuration)
		{
			CommonValidation(RoySchedDtoUpdate.ChangeUser, RoySchedDtoUpdate.Title_ID, RoySchedDtoUpdate.LoRange, RoySchedDtoUpdate.HiRange, RoySchedDtoUpdate.Royalty, configuration);
		}

	}

}
