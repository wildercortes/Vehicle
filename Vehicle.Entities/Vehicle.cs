namespace Vehicle.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }

        public int VehicleTypeId { get; set; }

        public int BrandId { get; set; }

        public int HistoryId { get; set; }
        
        public int Model { get; set; }

        public string Plaque { get; set; }

        public string Line { get; set; }

        public string Color { get; set; }

        public string UserId { get; set; }

        public string Remarks { get; set; }

        public virtual User User { get; set; }

        public virtual VehicleType VehicleType { get; set; }

        public virtual Brand Brand { get; set; }

        
        //public int VehiclePhotosCount => VehiclePhotos == null ? 0 : VehiclePhotos.Count;


        //public string ImageFullPath => VehiclePhotos == null || VehiclePhotos.Count == 0
        //    ? $"https://localhost:44345/images/noimage.png"
        //    : VehiclePhotos.FirstOrDefault().ImageFullPath;

        //public int HistoriesCount => Histories == null ? 0 : Histories.Count;
    }
}
