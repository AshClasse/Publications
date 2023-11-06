using Microsoft.Extensions.Logging;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Authors;
using Publicaciones.Infrastructure.Interfaces;
using Publicaciones.Infrastructure.Repository;
using System;
using System.Linq;

namespace Publicaciones.Application.Service
{
    public class AuthorsService : IAuthorsService
    {
        private readonly IAuthorsRepository _authorsRepository;
        private readonly ILogger<AuthorsService> logger;
        public AuthorsService(IAuthorsRepository authorsRepository, 
                              ILogger<AuthorsService> logger)
        {
            this._authorsRepository = authorsRepository;
            this.logger = logger;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var authors = this._authorsRepository.GetEntities().Select(a => new AuthorsDtoGetAll()
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
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error obteniento los autores.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var authors = this._authorsRepository.GetEntityByID(Id);
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error obteniento el autor.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult Remove(AuthorsDtoRemove dtoRemove)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult Save(AuthorsDtoAdd dtoAdd)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult Update(AuthorsDtoUpdate dtoUpdate)
        {
            throw new System.NotImplementedException();
        }
    }
}
