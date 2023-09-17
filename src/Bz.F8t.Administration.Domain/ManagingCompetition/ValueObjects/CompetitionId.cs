using Bz.F8t.Administration.Domain.Common;

namespace Bz.F8t.Administration.Domain.ManagingCompetition;

public record CompetitionId : EntityId<Guid>
{
    public CompetitionId(Guid value) : base(value) { }

    public static CompetitionId From(Guid value)
    {
        return new CompetitionId(value);
    }
}
