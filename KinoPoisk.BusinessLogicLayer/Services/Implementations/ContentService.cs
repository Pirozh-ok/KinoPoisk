using AutoMapper;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.ContentDTOs;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.DomainLayer.Resources;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class ContentService : GenericService<Content, ContentDTO, Guid> {
        public ContentService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) {
        }

        protected override List<string> Validate(ContentDTO dto) {
            var errors = new List<string>(); 

            if(dto is null) {
                errors.Add(ContentResource.NullArgument);
                return errors; 
            }

            if(string.IsNullOrEmpty(dto.Name) || dto.Name.Length < Constants.MinLenOfName) {
                errors.Add(ContentResource.NameLessMinLen);
            }

            if(dto.Name.Length > Constants.MaxLenOfName) {
                errors.Add(ContentResource.NameExceedsMaxLen); 
            }

            if (string.IsNullOrEmpty(dto.Path) || dto.Path.Length < Constants.MinLenOfName){
                errors.Add(ContentResource.PathLessMinLen);
            }

            if(dto.Path.Length > Constants.MaxLenOfPath) {
                errors.Add(ContentResource.PathExceedsMaxLen); 
            }

            if((int)dto.Type < (int)ContentType.Poster || (int)dto.Type > (int)ContentType.Movie) {
                errors.Add(ContentResource.IncorrectContentType); 
            }

            if(_unitOfWork.GetRepository<Movie>().GetById(dto.MovieId) is null) {
                errors.Add(ContentResource.MovieNotFound); 
            }

            return errors; 
        }
    }
}
