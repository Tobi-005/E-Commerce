using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {

        }

        public BaseSpecification(Expression<Func<T,bool>> criteria)
        {
            Citeria = criteria;
        }

        public Expression<Func<T, bool>> Citeria {get;}

        public List<Expression<Func<T, object>>> Includes {get;}= new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy {get;private set;}

        public Expression<Func<T, object>> OrderByDescending {get;private set;}

        public int Take {get;private set;}

        public int Skip {get;private set;}

        public bool isPagingEnabled {get;private set;}

        protected void AddInlude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void AddOrderBy(Expression<Func<T,object>> orderByExpression)
        {
            OrderBy=orderByExpression;
        }

        protected void AddOrderByDesc(Expression<Func<T,object>> orderByExpressionDesc)
        {
            OrderByDescending=orderByExpressionDesc;
        }

        protected void AddPagination(int skip,int take)
        {
            Skip=skip;
            Take=take;
            isPagingEnabled=true;
        }
    }
}