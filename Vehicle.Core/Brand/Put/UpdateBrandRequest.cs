using MediatR;

namespace Vehicle.Core.Brand.Put
{
    public class UpdateBrandRequest : IRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
