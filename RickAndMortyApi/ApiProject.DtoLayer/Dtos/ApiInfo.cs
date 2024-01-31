using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.DtoLayer.Dtos
{
    public class ApiInfo
    {
        public int Count { get; set; }
        public int Pages { get; set; }
        public string Next { get; set; }
        public string Prev { get; set; }
    }

    public class ApiResult<T>
    {
        public ApiInfo Info { get; set; }
        public IEnumerable<T> Results { get; set; }
    }

}
