using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Utility
{
    public static class PartyType
    {
        static PartyType()
        {
            SundryCreditors = Guid.Parse("d982b189-3326-430d-acde-13c12bba7992");
            SundryDebtors = Guid.Parse("fbf4a6c7-c33d-4ad0-b7a5-abb319cc1b93");
        }
        public static Guid SundryCreditors { get; set; }
        public static Guid SundryDebtors { get; set; }
    }
}
