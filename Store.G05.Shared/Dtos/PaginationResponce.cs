using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G05.Shared.Dtos
{
    public class PaginationResponce<TEntity>
    {
        public PaginationResponce(int pageINdex, int pageSize, int totalcount, IEnumerable<TEntity> result)
        {
            PageINdex = pageINdex;
            PageSize = pageSize;
            Totalcount = totalcount;
            Result = result;
        }

        public int PageINdex { get; set; }
        public int PageSize { get; set; }
        public int Totalcount { get; set; }
        public IEnumerable<TEntity> Result { get; set; }
    }
}
