﻿using Bz.F8t.Administration.Domain.ManagingCompetition;
using Bz.F8t.Administration.Messaging;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bz.F8t.Administration.Application.Competitions;

internal class CompetitionCheckpointRemovedHandler(
    ILogger<CompetitionCheckpointRemovedHandler> logger,
    IPublishEndpoint publishEndpoint) : INotificationHandler<CompetitionCheckpointRemoved>
{
    private readonly ILogger<CompetitionCheckpointRemovedHandler> _logger = logger;
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    public async Task Handle(CompetitionCheckpointRemoved domainEvent, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"<Application Layer> checkpoint {domainEvent.CheckpointId} from competition {domainEvent.CompetitionId} removed!");

        await _publishEndpoint.Publish(
            new CompetitionCheckpointRemovedIntegrationEvent(
                domainEvent.CompetitionId.Value,
                domainEvent.CheckpointId.Value,
                domainEvent.TrackPoint.Amount,
                domainEvent.TrackPoint.Unit.ToString()));
    }
}
