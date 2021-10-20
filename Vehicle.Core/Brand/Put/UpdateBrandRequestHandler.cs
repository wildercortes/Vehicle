using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Vehicle.Core.Data.EF.Interfaces;
using Vehicle.Core.Exceptions;

namespace Vehicle.Core.Brand.Put
{
    public class UpdateBrandRequestHandler : IRequestHandler<UpdateBrandRequest>
    {
        private readonly IBrandRepository brandRepository;
        public UpdateBrandRequestHandler(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
        }

        public async Task<Unit> Handle(UpdateBrandRequest request, CancellationToken cancellationToken)
        {
            var brand = await brandRepository.GetById(request.Id);
            if (brand == null)
                throw new BusinessException("Marca no existe");

            if (await brandRepository.ExistBrandWithName(request.Description))
                throw new BusinessException("Ya existe una Marca ncon ese nombre");

            brand.Description = request.Description;

            brandRepository.Update(brand);

            return Unit.Value;
        }
    }
}
