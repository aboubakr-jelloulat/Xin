using Ordering.Domain.Abstractions;
using Ordering.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.Events;

public record OrderUpdatedEvent(Order order) : IDomainEvent;