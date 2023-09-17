using AutoMapper;
using Bz.Fott.Administration.Messaging;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Bz.Fott.Administration.Domain.ManagingCompetition;

namespace Bz.Fott.Administration.Application.Competitions;

public class CompetitionOpenedForRegistrationHandler : INotificationHandler<CompetitionOpenedForRegistration>
{
    private readonly ILogger<CompetitionOpenedForRegistrationHandler> _logger;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IMapper _mapper;

    public CompetitionOpenedForRegistrationHandler(
        ILogger<CompetitionOpenedForRegistrationHandler> logger,
        IPublishEndpoint publishEndpoint,
        IMapper mapper)
    {
        _logger = logger;
        _publishEndpoint = publishEndpoint;
        _mapper = mapper;
    }

    public async Task Handle(CompetitionOpenedForRegistration domainEvent, CancellationToken cancellationToken)
    {
        _logger.LogInformation("<Application Layer> Competition opened to registration by competitors!");

        await _publishEndpoint.Publish(new CompetitionOpenedForRegistrationIntegrationEvent(
            domainEvent.Id.Value,
            _mapper.Map<Messaging.CompetitionPlaceDto>(domainEvent.Place),
            _mapper.Map<Messaging.DistanceDto>(domainEvent.Distance),
            domainEvent.StartAt,
            domainEvent.MaxCompetitors,
            _mapper.Map<IEnumerable<Checkpoint>, IEnumerable<Messaging.CheckpointDto>>(domainEvent.Checkpoints)));
    }
}
