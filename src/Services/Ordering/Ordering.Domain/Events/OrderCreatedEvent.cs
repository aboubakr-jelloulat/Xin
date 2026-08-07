using Ordering.Domain.Abstractions;
using Ordering.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.Events;

public record OrderCreatedEvent(Order order) : IDomainEvent;