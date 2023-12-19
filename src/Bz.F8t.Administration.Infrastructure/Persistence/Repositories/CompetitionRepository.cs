using Bz.F8t.Administration.Domain.ManagingCompetition;
using Bz.F8t.Administration.Infrastructure.Persistence.Common;

namespace Bz.F8t.Administration.Infrastructure.Persistence.Repositories;

internal class CompetitionRepository(ApplicationDbContext dbContext) : Repository<Competition, CompetitionId, ApplicationDbContext>(dbContext), ICompetitionRepository
{
}
