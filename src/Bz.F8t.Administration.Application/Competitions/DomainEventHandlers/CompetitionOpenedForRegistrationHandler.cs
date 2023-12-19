using AutoMapper;
using Bz.F8t.Administration.Messaging;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Bz.F8t.Administration.Domain.ManagingCompetition;

namespace Bz.F8t.Administration.Application.Competitions;

public class CompetitionOpenedForRegistrationHandler(
    ILogger<CompetitionOpenedForRegistrationHandler> logger,
    IPublishEndpoint publishEndpoint,
    IMapper mapper) : INotificationHandler<CompetitionOpenedForRegistration>
{
    private readonly ILogger<CompetitionOpenedForRegistrationHandler> _logger = logger;
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;
    private readonly IMapper _mapper = mapper;

    public async Task Handle(CompetitionOpenedForRegistration domainEvent, CancellationToken cancellationToken)
    {
        _logger.LogInformation("<Application Layer> Competition opened to registration by competitors!");

        await _publishEndpoint.Publish(new CompetitionOpenedForRegistrationIntegrationEvent(
            domainEvent.Id.Value,
            new(domainEvent.Place.City, domainEvent.Place.Localization.Latitude, domainEvent.Place.Localization.Longitude),
            new(domainEvent.Distance.Amount, domainEvent.Distance.Unit.ToString()),
            domainEvent.StartAt,
            domainEvent.MaxCompetitors,
            domainEvent.Checkpoints.Select(c => new Messaging.CheckpointDto(c.Id.Value, c.TrackPoint.Amount, c.TrackPoint.Unit.ToString())))
        );
    }
}
