namespace FMS.Utility
{
    public sealed class Mapping
    {
        private Mapping() { }
        private static Mapping _instance;
        private static readonly object _lock = new object();
        public static Mapping GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Mapping();
                    }
                }
            }
            return _instance;
        }
        public Dictionary<string, string> GetGender()
        {
            var gender = new Dictionary<string, string>
            {
                { "male", "Male" },
                { "female", "Female" },
                 { "other", "Other" },
            };
            return gender;
        }
        public Dictionary<string, string> MaratialStatus()
        {
            var maratialStatus = new Dictionary<string, string>
            {
                { "married", "Married" },
                { "unmarred", "Unmarried" },
                 { "other", "Other" },
            };
            return maratialStatus;
        }
        public Dictionary<string, string> GetSalesType()
        {
            var salesType = new Dictionary<string, string>
            {
                { "cash", "Cash" },
                { "credit", "Credit" },
            };
            return salesType;
        }
        public Dictionary<string, string> GetRateType()
        {
            var rateType = new Dictionary<string, string>
            {
                { "wholesalerate", "Wholesale Rate" },
                { "normalrate", "Normal Rate" },
            };
            return rateType;
        }
    }
}
