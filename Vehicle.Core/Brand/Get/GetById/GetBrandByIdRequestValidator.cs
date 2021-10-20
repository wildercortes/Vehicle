using FluentValidation;

namespace Vehicle.Core.Brand.Get.GetById
{
    public class GetBrandByIdRequestValidator : AbstractValidator<GetBrandByIdRequest>
    {
        public GetBrandByIdRequestValidator()
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
