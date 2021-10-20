using FluentValidation;

namespace Vehicle.Core.Brand.Add
{
    public class AddBrandRequestValidator : AbstractValidator<AddBrandRequest>
    {
        public AddBrandRequestValidator()
        {
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
