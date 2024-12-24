using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Model
{
    public class PaginationParams
    {
        public int? PageNumber { get; set; } = null;
        public int? PageSize { get; set; } = null;
    }
}
