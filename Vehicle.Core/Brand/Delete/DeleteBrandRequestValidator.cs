using FluentValidation;

namespace Vehicle.Core.Brand.Delete
{
    public class DeleteBrandRequestValidator : AbstractValidator<DeleteBrandRequest>
    {
        public DeleteBrandRequestValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotNull()
                .WithMessage("Debe ingresar un Id")
                .GreaterThan(0)
                .WithMessage("Id debe ser mayor a 0");
        }
    }
}
