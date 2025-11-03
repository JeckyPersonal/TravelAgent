using System.Globalization;

namespace Invoice.Model
{
    public class ItemInterval
    {
        public int Id { get; set; }
        public int Interval { get; set; }
        public string IntervalName { get; set; }

        public List<ItemMaster> Items { get; set; }
    }
}
