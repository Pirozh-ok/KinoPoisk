using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.RequestParameterModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace KinoPoisk.DomainLayer.Extensions {
    public static class IQueryableExtensions {
        public static async Task<PagedList<Movie>> ToPagedFilteredSortedListAsync(
            this IQueryable<Movie> movies, 
            MovieRequestParameters parameters) {
            //filtering
            var filters = parameters?.Filters?.ToLower().Split(",") ?? null;
            if(filters is not null) {
                foreach(var filter in filters) {
                    var values = filter.Split("=");

                    switch(values[0]) {
                        case "min-duration": {
                                movies = movies.Where(x => x.DurationInMinutes > uint.Parse(values[1]));
                                break;
                            }
                        case "max-duration": {
                                movies = movies.Where(x => x.DurationInMinutes < uint.Parse(values[1]));
                                break;
                            }
                        case "country": {
                                movies = movies.Where(x => x.Countries.Any(x => x.Name.ToLower() == values[1]));
                                break;
                            }
                        case "min-rating": {
                                movies = movies.Where(x => x.Ratings.Sum(x => x.MovieRating) / x.Ratings.Count > double.Parse(values[1]));
                                break;
                            }
                        case "min-world-fees": {
                                movies = movies.Where(x => x.WorldFeesInDollars > uint.Parse(values[1]));
                                break;
                            }
                        case "max-world-fees": {
                                movies = movies.Where(x => x.WorldFeesInDollars < uint.Parse(values[1]));
                                break;
                            }
                        case "ganre": {
                                movies = movies.Where(x => x.Genres.Any(x => x.Name.ToLower() == values[1]));
                                break;
                            }
                        case "age-category": {
                                movies = movies.Where(x => x.AgeCategories.Any(x => x.MinAge >= uint.Parse(values[1])));
                                break;
                            }
                        case "max-year": {
                                movies = movies.Where(x => x.PremiereDate.Year < int.Parse(values[1]));
                                break;
                            }
                        case "min-year": {
                                movies = movies.Where(x => x.PremiereDate.Year > int.Parse(values[1]));
                                break;
                            }
                        default: {
                                break;
                            }
                    }
                }
            }

            //sorting
            var sortings = parameters?.Sorting?.ToLower().Split(",") ?? null;

            if (sortings is not null) {
                foreach (var sorting in sortings) {
                    switch (sorting) {
                        case "-name": {
                                movies = ((IOrderedQueryable<Movie>)movies).ThenByDescending(x => x.Title);
                                break;
                            }
                        case "+rating": {
                                movies = ((IOrderedQueryable<Movie>)movies).ThenBy(x => x.Ratings.Sum(x => x.MovieRating) / x.Ratings.Count);
                                break;
                            }
                        case "-rating": {
                                movies = ((IOrderedQueryable<Movie>)movies).ThenByDescending(x => x.Ratings.Sum(x => x.MovieRating) / x.Ratings.Count);
                                break;
                            }
                        case "+world-fees": {
                                movies = ((IOrderedQueryable<Movie>)movies).ThenBy(x => x.WorldFeesInDollars);
                                break;
                            }
                        case "-world-fees": {
                                movies = ((IOrderedQueryable<Movie>)movies).ThenByDescending(x => x.WorldFeesInDollars);
                                break;
                            }
                        case "+count-creators": {
                                movies = ((IOrderedQueryable<Movie>)movies).ThenBy(x => x.CreatorsMovies.Count());
                                break;
                            }
                        case "-count-creators": {
                                movies = ((IOrderedQueryable<Movie>)movies).ThenByDescending(x => x.CreatorsMovies.Count());
                                break;
                            }
                        case "+duration": {
                                movies = ((IOrderedQueryable<Movie>)movies).ThenBy(x => x.DurationInMinutes);
                                break;
                            }
                        case "-duration": {
                                movies = ((IOrderedQueryable<Movie>)movies).ThenByDescending(x => x.DurationInMinutes);
                                break;
                            }
                        default: {
                                //+name
                                movies = movies.OrderBy(x => x.Title);
                                break;
                            }
                    }
                }
            }

            //paging
            var result = await movies
                .Skip((int)((parameters.PageNumber - 1) * parameters.PageSize))
                .Take((int)parameters.PageSize)
                .ToListAsync();

            return new PagedList<Movie>(result, (uint)movies.Count(), parameters.PageNumber, parameters.PageSize);
        }

        public static IQueryable<TEntity> ThenBy<TEntity>(this IQueryable<TEntity> source, string thenByProperty, bool desc) {
            string command = desc ? "ThenByDescending" : "ThenBy";
            var type = typeof(TEntity);
            var property = type.GetProperty(thenByProperty);
            var parameter = Expression.Parameter(type, property.ToString());
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] {
                type, property.PropertyType }, source.Expression, Expression.Quote(orderByExpression));

            return source.Provider.CreateQuery<TEntity>(resultExpression);
        } 
    }
}
