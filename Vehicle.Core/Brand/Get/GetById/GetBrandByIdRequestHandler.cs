using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Vehicle.Core.Brand.Get.GetIndex.Models;
using Vehicle.Core.Data.EF.Interfaces;
using Vehicle.Core.Exceptions;

namespace Vehicle.Core.Brand.Get.GetById
{
    public class GetBrandByIdRequestHandler : IRequestHandler<GetBrandByIdRequest, GetBrandIndexModel>
    {
        private readonly IBrandRepository brandRepository;

        public GetBrandByIdRequestHandler(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
        }

        public async Task<GetBrandIndexModel> Handle(GetBrandByIdRequest request, CancellationToken cancellationToken)
        {
            var brand = await brandRepository.GetById(request.Id);

            if (brand == null)
                throw new BusinessException("Marca no existe");

            return new GetBrandIndexModel
            {
                Id = brand.Id,
                Description = brand.Description           
            };
        }
    }
}
