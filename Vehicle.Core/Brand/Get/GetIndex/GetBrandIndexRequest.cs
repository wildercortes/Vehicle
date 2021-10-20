using MediatR;
using System.Collections.Generic;
using Vehicle.Core.Brand.Get.GetIndex.Models;

namespace Vehicle.Core.Brand.Get.GetIndex
{
    public class GetBrandIndexRequest : IRequest<IList<GetBrandIndexModel>>
    {
    }
}
