using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Vehicle.Core.Data.EF.Interfaces;
using Vehicle.Core.Exceptions;

namespace Vehicle.Core.Brand.Delete
{
    public class DeleteBrandRequestHandler : IRequestHandler<DeleteBrandRequest>
    {
        private readonly IBrandRepository brandRepository;
        public DeleteBrandRequestHandler(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
        }
        public async Task<Unit> Handle(DeleteBrandRequest request, CancellationToken cancellationToken)
        {
            var brand = await brandRepository.GetById(request.Id);
            if (brand == null)
                throw new BusinessException("Marca no existe");

            brandRepository.Delete(request.Id);

            return Unit.Value;
        }
    }
}
