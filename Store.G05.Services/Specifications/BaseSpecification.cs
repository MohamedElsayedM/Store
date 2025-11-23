using Store.G05.Domain.Contracts;
using Store.G05.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.G05.Services.Specifications
{
    public class BaseSpecification<Tkey, TEntity> : ISpecifications<Tkey, TEntity> where TEntity : BaseEntity<Tkey>
    {
        public List<Expression<Func<TEntity, object>>> Includes { get; set; } = new List<Expression<Func<TEntity,object>>>();
        public Expression<Func<TEntity, bool>>? Criteria { get; set; }
        public Expression<Func<TEntity, object>>? OrderBy { get; set; }
        public Expression<Func<TEntity, object>>? OrderByDesc { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPagination { get; set; }

        public void ApplyPagination(int pageIndex, int pageSize) { 
        IsPagination= true;
            Skip = (pageIndex - 1) * pageSize;
            Take = pageSize ;
        }

        public BaseSpecification(Expression<Func<TEntity,bool>>? expression)
        { 
            Criteria = expression;
        }
        public void ApplyOrderBy(Expression<Func<TEntity, object>>? expression) {
            OrderBy = expression;
        }
        public void ApplyOrderByDesc(Expression<Func<TEntity, object>>? expression) {
            OrderByDesc = expression;
        }
    }
}
