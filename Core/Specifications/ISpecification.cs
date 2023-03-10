using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Crietria { get; }
        List<Expression<Func<T, object>>> Includes { get; }

        // For API Sorting 
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }

        // For API Pagination
        int Take { get; }
        int Skip { get; }
        bool ISPagingEnabled { get; }
    }
}