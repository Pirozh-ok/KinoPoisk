﻿namespace KinoPoisk.DomainLayer.Intarfaces {
    public interface IBaseEntityService<TKey, TEntityDto> {
        public Task<ServiceResult> CreateAsync(TEntityDto createDto);
        public Task<ServiceResult> DeleteAsync(TKey id);
        public Task<ServiceResult> UpdateAsync(TEntityDto updateDto);
        public ServiceResult Get<TGetDto>();
        public ServiceResult GetById<TGetDto>(TKey id);
    }
}