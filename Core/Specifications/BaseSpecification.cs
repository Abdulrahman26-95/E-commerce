using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {

        }
        public BaseSpecification(Expression<Func<T, bool>> crietria)
        {
            Crietria = crietria;
        }
        public Expression<Func<T, bool>> Crietria { get; }

        // MAke an Empty List To Include Expression into it 
        public List<Expression<Func<T, object>>> Includes { get; } =
        new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        // For Api Sorting 
        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        protected void AddORderByDesc(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }

        // For API Pagination
        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool ISPagingEnabled { get; private set; }
        protected void applyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            ISPagingEnabled = true;
        }
    }
}