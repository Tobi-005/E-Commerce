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

        protected void AddInlude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}