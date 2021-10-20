using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Vehicle.Core.Data.EF.Interfaces;
using Vehicle.Core.Exceptions;

namespace Vehicle.Core.Brand.Add
{
    public class AddBrandRequestHandler : IRequestHandler<AddBrandRequest>
    {
        private readonly IBrandRepository brandRepository;
        public AddBrandRequestHandler(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
        }

        public async Task<Unit> Handle(AddBrandRequest request, CancellationToken cancellationToken)
        {
            if (await brandRepository.ExistBrandWithName(request.Description))
                throw new BusinessException("Ya existe una Marca ncon ese nombre");

            var brand = new Entities.Brand()
            {
                Description = request.Description
            };

            brandRepository.Add(brand);

            return Unit.Value;
        }
    }
}
