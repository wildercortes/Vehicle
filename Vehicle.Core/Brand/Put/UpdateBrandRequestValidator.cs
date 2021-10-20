using FluentValidation;

namespace Vehicle.Core.Brand.Put
{
    public class UpdateBrandRequestValidator : AbstractValidator<UpdateBrandRequest>
    {
        public UpdateBrandRequestValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotNull()
                .WithMessage("Debe ingresar un Id")
                .GreaterThan(0)
                .WithMessage("Id debe ser mayor a 0");

            RuleFor(x => x.Description)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotNull()
                .WithMessage("Debe ingresar una descripcion para la marca")
                .MaximumLength(255)
                .WithMessage("El largo maximo permitido es 255 caracteres");
        }
    }
}
