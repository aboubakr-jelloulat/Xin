using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.Exceptions;

public class DomainException : Exception
{
    public DomainException(string message)
        : base($"Domain Exception: \"{message}\" throws from Domain Layer.")
    {
    }
}