﻿using GiveFreely.EMS.Core.EmployeeAggregate.Events;
using GiveFreely.EMS.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GiveFreely.EMS.Core.EmployeeAggregate.Handlers;

/// <summary>
/// NOTE: Internal because EmployeeDeleted is also marked as internal.
/// </summary>
internal class EmployeeDeletedHandler(ILogger<EmployeeDeletedHandler> logger,
  IEmailSender emailSender) : INotificationHandler<EmployeeDeletedEvent>
{
  public async Task Handle(EmployeeDeletedEvent domainEvent, CancellationToken cancellationToken)
  {
    logger.LogInformation("Handling Contributed Deleted event for {EmployeeId}", domainEvent.EmployeeId);

    await emailSender.SendEmailAsync("to@test.com",
                                     "from@test.com",
                                     "Employee Deleted",
                                     $"Employee with id {domainEvent.EmployeeId} was deleted.");
  }
}
