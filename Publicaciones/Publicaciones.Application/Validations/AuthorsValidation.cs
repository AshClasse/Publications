using Microsoft.Extensions.Configuration;
using Publicaciones.Application.Dtos.Authors;
using Publicaciones.Application.Dtos.TitleAuthor;
using Publicaciones.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Application.Validations
{
    public static class AuthorsValidation
    {
        private static void CommonValidation(string? Au_FName, string? Au_LName, string? Phone, IConfiguration configuration)
        {
            if (string.IsNullOrEmpty(Au_FName))
            {
                string errorMessage = $"{configuration["ValidationMessage:authorNameRequired"]}";
                throw new AuthorServiceException(errorMessage);
            }
            if (string.IsNullOrEmpty(Au_LName))
            {
                string errorMessage = configuration["ValidationMessage:authorLNameRequired"];
                throw new AuthorServiceException(errorMessage);
            }

            if (Au_FName.Length > 20)
            {
                string errorMessage = $"{configuration["ValidationMessage:authorLengthName"]}";
                throw new AuthorServiceException(errorMessage);
            }
            if (Au_LName.Length > 40)
            {
                string errorMessage = configuration["ValidationMessage:authorLengthLName"];
                throw new AuthorServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(Phone))
            {
                string errorMessage = configuration["ValidationMessage:authorPhoneRequired"];
                throw new AuthorServiceException(errorMessage);
            }
        }

        public static void Validation(AuthorsDtoAdd authorsDtoAdd, IConfiguration configuration)
        {
            CommonValidation(authorsDtoAdd.Au_FName, authorsDtoAdd.Au_LName, authorsDtoAdd.Phone, configuration);
        }
        public static void Validation(AuthorsDtoUpdate authorsDtoUpdate, IConfiguration configuration)
        {
            CommonValidation(authorsDtoUpdate.Au_FName, authorsDtoUpdate.Au_LName, authorsDtoUpdate.Phone, configuration);
        }
    }
}
