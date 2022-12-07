using System;
using System.Runtime.Serialization;

namespace IdokladSdk.UnitTests.Tests.Validation.Exceptions;

public class CustomTestException : Exception
{
    public CustomTestException()
    {
    }

    public CustomTestException(string message)
        : base(message)
    {
    }

    public CustomTestException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    protected CustomTestException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
