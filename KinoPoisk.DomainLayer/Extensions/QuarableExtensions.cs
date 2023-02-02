using KinoPoisk.DomainLayer.RequestParameterModels;
using Microsoft.EntityFrameworkCore;

namespace KinoPoisk.DomainLayer.Extensions {
    public static class QuarableExtensions {
        public static async Task<PagedList<T>> ToPagedFilteredSortedListAsync<T>(
            this IQueryable<T> source, 
            BaseRequestParameters parameters) {

            var items = await source
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .ToListAsync();

            // ToDo filtering and sorting + parameters generic where T: BaseRequestParameters

            return new PagedList<T>(items, source.Count(), parameters.PageNumber, parameters.PageSize);
        }
    }
}
