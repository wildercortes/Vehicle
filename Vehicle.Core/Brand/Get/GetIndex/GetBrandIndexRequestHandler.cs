using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vehicle.Core.Brand.Get.GetIndex.Models;
using Vehicle.Core.Data.EF.Interfaces;

namespace Vehicle.Core.Brand.Get.GetIndex
{
    public class GetBrandIndexRequestHandler : IRequestHandler<GetBrandIndexRequest, IList<GetBrandIndexModel>>
    {
        private readonly IBrandRepository brandRepository;

        public GetBrandIndexRequestHandler(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
        }

        public async Task<IList<GetBrandIndexModel>> Handle(GetBrandIndexRequest request, CancellationToken cancellationToken)
        {
            var brands = (await brandRepository.GetAll())
                .Select(x => new GetBrandIndexModel { Id = x.Id, Description = x.Description });

            var indexBrand = new List<GetBrandIndexModel>();

            indexBrand.AddRange(brands);

            return indexBrand;

        }
    }
}
