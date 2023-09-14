using Bz.Fott.Administration.Application.Competitions.Dtos;
using FluentValidation;

namespace Bz.Fott.Administration.Application.Competitions.Validators;

public class AddCheckpointRequestDtoValidator : AbstractValidator<AddCheckpointRequestDto>
{
    public AddCheckpointRequestDtoValidator()
    {
        RuleFor(x => x.TrackPointAmount)
            .GreaterThanOrEqualTo(0).WithMessage("Must be greater than or equal to 0");

        RuleFor(x => x.TrackPointUnit)
            .NotEmpty().WithMessage("Must be not empty");
    }
}
