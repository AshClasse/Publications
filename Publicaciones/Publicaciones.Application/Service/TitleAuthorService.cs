using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.TitleAuthor;
using Publicaciones.Application.Response;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Publicaciones.Application.Service
{
    public class TitleAuthorService : ITitleAuthorService
    {
        private readonly ITitleAuthorRepository titleAuthorRepository;
        private readonly ILogger<TitleAuthorService> logger;
        private readonly IConfiguration configuration;

        public TitleAuthorService(ITitleAuthorRepository titleAuthorRepository, 
                                    ILogger<TitleAuthorService> logger,
                                    IConfiguration configuration) 
        {
            this.titleAuthorRepository = titleAuthorRepository;
            this.logger = logger;
            this.configuration = configuration;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var titleAuthors = this.titleAuthorRepository.GetEntities().Select(titleAuthorDtoGetAll => new TitleAuthorDtoGetAll()
                {
                    Au_ID = titleAuthorDtoGetAll.Au_ID,
                    Title_ID = titleAuthorDtoGetAll.Title_ID,
                    Au_Ord = titleAuthorDtoGetAll.Au_Ord,
                    RoyaltyPer = titleAuthorDtoGetAll.RoyaltyPer,
                    ChangeUser = titleAuthorDtoGetAll.IDCreationUser,
                    ChangeDate = titleAuthorDtoGetAll.CreationDate
                });
                result.Data = titleAuthors;
                result.Message = this.configuration["TitleAuthorSuccessMessages:GetAllSuccess"];
            }
            catch(Exception ex) 
            {
                result.Success = false;
                result.Message = this.configuration["TitleAuthorErrorMessages:GetAllError"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetTitleAuthorById(int title_ID, int author_ID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (!ExistInAuthor(author_ID).Success)
                {
                    result.Success = false;
                    result.Message = this.configuration["ValidationMessage:authorIsInexistent"];
                    return result;
                }
                if (!ExistInTitles(title_ID).Success)
                {
                    result.Success = false;
                    result.Message = this.configuration["ValidationMessage:titleIsInexistent"];
                    return result;
                }
                var titleAuthors = this.titleAuthorRepository.GetEntityByID(title_ID, author_ID);
                result.Data = titleAuthors;
                result.Message = this.configuration["TitleAuthorSuccessMessages:GetTitleAuthorByIDSuccess"];
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["TitleAuthorErrorMessages:GetTitleAuthorByIDError"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult Remove(TitleAuthorDtoRemove dtoRemove)
        {
            ServiceResult result = new ServiceResult();
            
            try
            {
                if (!ExistInAuthor(dtoRemove.Au_ID).Success)
                {
                    result.Success = false;
                    result.Message = this.configuration["ValidationMessage:authorIsInexistent"];
                    return result;
                }
                if (!ExistInTitles(dtoRemove.Title_ID).Success)
                {
                    result.Success = false;
                    result.Message = this.configuration["ValidationMessage:titleIsInexistent"];
                    return result;
                }
                TitleAuthor titleAuthors = new TitleAuthor()
                {
                    Au_ID = dtoRemove.Au_ID,
                    Title_ID = dtoRemove.Title_ID,
                    Deleted = dtoRemove.Deleted,
                    DeletedDate = dtoRemove.ChangeDate,
                    IDDeletedUser = dtoRemove.ChangeUser
                };
                
                this.titleAuthorRepository.Remove(titleAuthors);
                result.Message = this.configuration["TitleAuthorSuccessMessages:RemoveSuccess"];
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["TitleAuthorErrorMessages:RemoveError"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
            
        

        public ServiceResult Save(TitleAuthorDtoAdd dtoAdd)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (!ExistInAuthor(dtoAdd.Au_ID).Success)
                {
                    result.Success = false;
                    result.Message = this.configuration["ValidationMessage:authorIsInexistent"];
                    return result;
                }
                if (!ExistInTitles(dtoAdd.Title_ID).Success)
                {
                    result.Success = false;
                    result.Message = this.configuration["ValidationMessage:titleIsInexistent"];
                    return result;
                }
                TitleAuthor titleAuthors = new TitleAuthor()
                {
                    Au_ID = dtoAdd.Au_ID,
                    Title_ID = dtoAdd.Title_ID,
                    Au_Ord = dtoAdd.Au_Ord,
                    RoyaltyPer = dtoAdd.RoyaltyPer,
                    CreationDate = dtoAdd.ChangeDate,
                    IDCreationUser = dtoAdd.ChangeUser
                };
                this.titleAuthorRepository.Save(titleAuthors);
                result.Data = new { AuthorId = titleAuthors.Au_ID, TitleId = titleAuthors.Title_ID };
                result.Message = this.configuration["TitleAuthorSuccessMessages:SaveSuccess"];
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["TitleAuthorErrorMessages:SaveSuccess"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult Update(TitleAuthorDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (!ExistInAuthor(dtoUpdate.Au_ID).Success)
                {
                    result.Success = false;
                    result.Message = this.configuration["ValidationMessage:authorIsInexistent"];
                    return result;
                }
                if (!ExistInTitles(dtoUpdate.Title_ID).Success)
                {
                    result.Success = false;
                    result.Message = this.configuration["ValidationMessage:titleIsInexistent"];
                    return result;
                }
                TitleAuthor titleAuthors = new TitleAuthor()
                {
                    Au_ID = dtoUpdate.Au_ID,
                    Title_ID = dtoUpdate.Title_ID,
                    Au_Ord = dtoUpdate.Au_Ord,
                    RoyaltyPer = dtoUpdate.RoyaltyPer,
                    ModifiedDate = dtoUpdate.ChangeDate,
                    IDModifiedUser = dtoUpdate.ChangeUser
                };
                this.titleAuthorRepository.Update(titleAuthors);
                result.Data = titleAuthors;
                result.Message = this.configuration["TitleAuthorSuccessMessages:UpdateSuccess"];
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["TitleAuthorErrorMessages:UpdateError"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult ExistInAuthor(int authorID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var exists = this.titleAuthorRepository.ExistsInAuthors(authorID);
                result.Data = exists;
                if (!exists)
                {
                    result.Success = false;
                    result.Message = $"{configuration["ValidationMessage:authorIsInexistent"]}";
                }
            }
            catch(Exception ex)
            {
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult ExistInTitles(int titleID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var exists = this.titleAuthorRepository.ExistsInTitles(titleID);
                result.Data = exists;
                if (!exists)
                {
                    result.Success = false;
                    result.Message = $"{configuration["ValidationMessage:titleIsInexistent"]}";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }


        public ServiceResult GetTitleAuthorByAuthorOrder(int authorOrd)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var titleAuthors = this.titleAuthorRepository.GetTitleAuthorByAuthorOrder(authorOrd);
                result.Data = titleAuthors;
                result.Message = this.configuration["TitleAuthorSuccessMessages:GetTitlesAuthorByAuthorOrderSuccess"];

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["TitleAuthorErrorMessages:GetTitlesAuthorByAuthorOrderError"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetTitleAuthorByRoyalty(int royalty)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var titleAuthors = this.titleAuthorRepository.GetTitleAuthorByRoyalty(royalty);
                result.Data = titleAuthors;
                result.Message = this.configuration["TitleAuthorSuccessMessages:GetTitlesAuthorByRoyaltySuccess"];
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["TitleAuthorErrorMessages:GetTitlesAuthorByRoyaltyError"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetTitleAuthorByTitle(int title)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var titleAuthors = this.titleAuthorRepository.GetTitleAuthorByTitle(title);
                result.Data = titleAuthors;
                result.Message = this.configuration["TitleAuthorSuccessMessages:GetTitlesAuthorByTitleSuccess"];
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["TitleAuthorErrorMessages:GetTitlesAuthorByTitleError"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetTitleByAu_ID(int au_ID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var titleAuthors = this.titleAuthorRepository.GetTitlesByAu_ID(au_ID);
                result.Data = titleAuthors;
                result.Message = this.configuration["TitleAuthorSuccessMessages:GetTitlesByAu_IDSuccess"];
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["TitleAuthorErrorMessages:GetTitlesByAu_IDËrror"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
