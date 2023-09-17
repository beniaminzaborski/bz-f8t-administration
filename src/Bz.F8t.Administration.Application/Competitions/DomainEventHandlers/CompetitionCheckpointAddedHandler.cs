using Bz.F8t.Administration.Domain.ManagingCompetition;
using Bz.F8t.Administration.Messaging;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bz.F8t.Administration.Application.Competitions;

public class CompetitionCheckpointAddedHandler : INotificationHandler<CompetitionCheckpointAdded>
{
    private readonly ILogger<CompetitionCheckpointAddedHandler> _logger;
    private readonly IPublishEndpoint _publishEndpoint;

    public CompetitionCheckpointAddedHandler(
        ILogger<CompetitionCheckpointAddedHandler> logger,
        IPublishEndpoint publishEndpoint)
    {
        _logger = logger;
        _publishEndpoint = publishEndpoint;
    }

    public async Task Handle(CompetitionCheckpointAdded domainEvent, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"<Application Layer> new checkpoint {domainEvent.CheckpointId} to competition {domainEvent.CompetitionId} added!");

        await _publishEndpoint.Publish(
            new CompetitionCheckpointAddedIntegrationEvent(
                domainEvent.CompetitionId.Value,
                domainEvent.CheckpointId.Value,
                domainEvent.TrackPoint.Amount,
                domainEvent.TrackPoint.Unit.ToString()));
    }
}
