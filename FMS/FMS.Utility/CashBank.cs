using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Utility
{
    public static class CashBank
    {
        static CashBank()
        {
            CashAccount = Guid.Parse("701C663E-DAC3-4A39-8D2A-36EB68426B54");
            BankAccount = Guid.Parse("9BFA6931-977F-4A3D-A582-DA5F1F4AB773");
        }
        public static Guid CashAccount { get; set; }
        public static Guid BankAccount { get; set; }
    }
}
