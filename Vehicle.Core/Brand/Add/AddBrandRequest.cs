using MediatR;

namespace Vehicle.Core.Brand.Add
{
    public class AddBrandRequest : IRequest
    {
        public string Description { get; set; }
    }
}
