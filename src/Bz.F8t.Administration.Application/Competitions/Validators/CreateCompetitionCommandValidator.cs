using Bz.F8t.Administration.Application.Competitions.Commands;
using FluentValidation;

namespace Bz.F8t.Administration.Application.Competitions;

public class CreateCompetitionCommandValidator : AbstractValidator<CreateCompetitionCommand>
{
    public CreateCompetitionCommandValidator(
        IValidator<DistanceDto> distanceValidator,
        IValidator<CompetitionPlaceDto> placeValidator)
    {
        RuleFor(x => x.StartAt)
          .GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("Cannot be in the past");

        RuleFor(x => x.MaxCompetitors)
            .GreaterThan(0).WithMessage("Greater than 0");

        RuleFor(x => x.Distance)
            .NotNull().WithMessage("Field is required")
            .SetValidator(distanceValidator);

        RuleFor(x => x.Place)
            .NotNull().WithMessage("Field is required")
            .SetValidator(placeValidator);
    }
}
