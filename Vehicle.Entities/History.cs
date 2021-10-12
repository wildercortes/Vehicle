using System;

namespace Vehicle.Entities
{
    public class History
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateLocal => Date.ToLocalTime();
        public int Mileage { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        // public int DetailsCount => Details == null ? 0 : Details.Count;

        //public int TotalLabor => Details == null ? 0 : Details.Sum(x => x.LaborPrice);

        //public int TotalSpareParts => Details == null ? 0 : Details.Sum(x => x.SparePartsPrice);

        //public int Total => Details == null ? 0 : Details.Sum(x => x.TotalPrice);
    }
}
