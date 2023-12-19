﻿using Bz.F8t.Administration.Domain.ManagingCompetition;
using Bz.F8t.Administration.Messaging;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bz.F8t.Administration.Application.Competitions;

public class CompetitionMaxCompetitorsIncreasedHandler(
    ILogger<CompetitionMaxCompetitorsIncreasedHandler> logger,
    IPublishEndpoint publishEndpoint) : INotificationHandler<CompetitionMaxCompetitorsIncreased>
{
    private readonly ILogger<CompetitionMaxCompetitorsIncreasedHandler> _logger = logger;
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    public async Task Handle(CompetitionMaxCompetitorsIncreased domainEvent, CancellationToken cancellationToken)
    {
        _logger.LogInformation("<Application Layer> Maximum numbers of competitors has been increased!");

        await _publishEndpoint.Publish(new CompetitionMaxCompetitorsIncreasedIntegrationEvent(domainEvent.Id.Value, domainEvent.MaxCompetitors));
    }
}
