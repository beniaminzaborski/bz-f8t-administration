using Bz.F8t.Administration.Domain.ManagingCompetition;
using Bz.F8t.Administration.Messaging;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bz.F8t.Administration.Application.Competitions;

public class CompetitionRegistrationCompletedHandler : INotificationHandler<CompetitionRegistrationCompleted>
{
    private readonly ILogger<CompetitionRegistrationCompletedHandler> _logger;
    private readonly IPublishEndpoint _publishEndpoint;

    public CompetitionRegistrationCompletedHandler(
        ILogger<CompetitionRegistrationCompletedHandler> logger,
        IPublishEndpoint publishEndpoint)
    {
        _logger = logger;
        _publishEndpoint = publishEndpoint;
    }

    public async Task Handle(CompetitionRegistrationCompleted domainEvent, CancellationToken cancellationToken)
    {
        _logger.LogInformation("<Application Layer> Competition registration completed!");

        await _publishEndpoint.Publish(new CompetitionRegistrationCompletedIntegrationEvent(domainEvent.Id.Value));
    }
}
