using Bz.F8t.Administration.Application.Common;

namespace Bz.F8t.Administration.Application.Competitions;

public interface ICompetitionService : IApplicationService
{
    //Task<Guid> CreateCompetitionAsync(CreateCompetitionDto dto);

    //Task<CompetitionDto> GetCompetitionAsync(Guid id);

    //Task OpenRegistrationAsync(Guid id);

    //Task CompleteRegistrationAsync(Guid id);

    //Task ChangeMaxCompetitors(Guid id, int maxCompetitors);

    Task AddCheckpoint(Guid competitionId, AddCheckpointRequestDto checkpointDto);

    Task RemoveCheckpoint(Guid competitionId, Guid checkpointId);
}
