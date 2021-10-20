using MediatR;
using Vehicle.Core.Brand.Get.GetIndex.Models;

namespace Vehicle.Core.Brand.Get.GetById
{
    public class GetBrandByIdRequest : IRequest<GetBrandIndexModel>
    {
        public int Id { get; set; }
    }
}
