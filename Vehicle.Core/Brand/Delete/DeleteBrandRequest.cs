using MediatR;

namespace Vehicle.Core.Brand.Delete
{
    public class DeleteBrandRequest : IRequest
    {
        public int Id { get; set; }
    }
}
