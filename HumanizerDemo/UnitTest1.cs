using System;
using FluentAssertions;
using Humanizer;
using Xunit;

namespace HumanizerDemo
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            DateTime.UtcNow.AddHours(-30).Humanize().Should().Be("yesterday");
            DateTime.UtcNow.AddHours(-2).Humanize().Should().Be("2 hours ago");

            DateTime.UtcNow.AddHours(30).Humanize().Should().Be("tomorrow");
            DateTime.UtcNow.AddHours(2).Humanize().Should().Be("an hour from now");

            DateTimeOffset.UtcNow.AddHours(1).Humanize().Should().Be("59 minutes from now");
        }
    }
}
