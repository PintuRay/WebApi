using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Model.Devloper
{
    public class FinancialYearModel
    {
        public string Financial_Year { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class FinancialYearViewModel: FinancialYearModel
    {
        public Guid FinancialYearId { get; set; }
    }
}
