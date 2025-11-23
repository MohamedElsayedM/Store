using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Store.G05.Domain.Contracts;
using Store.G05.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G05.Presistence
{
    public static class SpecificationsEvaluator
    {
        public static IQueryable<TEntity> GetQuery<Tkey,TEntity>(IQueryable<TEntity> inputQuery,ISpecifications<Tkey,TEntity> spec) where TEntity : BaseEntity<Tkey>
        {
            var query = inputQuery;
            if( spec.Criteria is not null) {
                query = query.Where(spec.Criteria);
            }

            if(spec.OrderBy is not null)
            {
                query = query.OrderBy(spec.OrderBy);
            }else if(spec.OrderByDesc is not null)
            {
                query= query.OrderByDescending(spec.OrderByDesc);
            }

            if (spec.IsPagination)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

                query = spec.Includes.Aggregate(query, (query, includeExpression) => query.Include(includeExpression));

            return query;
        }
    }
}
