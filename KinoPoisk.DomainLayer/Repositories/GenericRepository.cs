using KinoPoisk.DomainLayer.DTOs;
using KinoPoisk.DomainLayer.Interfaces;
using KinoPoisk.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace KinoPoisk.DomainLayer.Repositories {
    public class GenericRepository<TTypeId, TCreateDTO, TUpdateDTO, TGetDTO, TEntity, TResult>
        : IRepository<TTypeId, TCreateDTO, TUpdateDTO, TGetDTO, TResult>
        where TCreateDTO : ICreateDTO
        where TUpdateDTO : IUpdateDTO<TTypeId>
        where TEntity : class
        where TResult : class{
        private ApplicationDbContext _context;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(ApplicationDbContext context) {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<Result> Create(TCreateDTO dto) {
            var errors = dto.ValidateData();

            if (errors?.Count() > 0) {
                return new ErrorResult(errors);
            }

            //await _dbSet.AddAsync(new TEntity()); 
            await _context.SaveChangesAsync();
            return new SuccessResult<string?>(null);
        }

        public async Task<Result> Delete(TTypeId id) {
            throw new NotImplementedException();
        }

        public async Task<Result> GetAll() {
            throw new NotImplementedException();
        }

        public async Task<Result> GetById(TTypeId id) {
            throw new NotImplementedException();
        }

        public async Task<Result> Update(TUpdateDTO dto) {
            throw new NotImplementedException();
        }
    }
}
