using System;

namespace Vehicle.Entities
{
    public class VehiclePhoto
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public Guid ImageId { get; set; }
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://vehiclessalazar.azurewebsites.net/images/noimage.png"
            : $"https://vehiclessalazar.blob.core.windows.net/vehiclephotos/{ImageId}";
        public virtual Vehicle Vehicle { get; set; }
    }
}
