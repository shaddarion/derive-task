using System;
using FluentAssertions;

namespace AutomationFramework.CustomExceptions
{
    public class NullWebDriverException : Exception
    {
        public NullWebDriverException(string message) : base(message)
        {
            message.Should().BeNullOrEmpty("lalala");
        }
    }
}
