using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using XTricks.Shared.Models;

namespace XTricks.Shared.Tests.Models
{
    [TestFixture]
    public class DistanceTests
    {
        [TestCase(-1, -1609.344)]
        [TestCase(0, 0)]
        [TestCase(1, 1609.344)]
        [TestCase(1.5, 2414.016)]
        [TestCase(99, 159325.056)]
        public void MetersToMilesConversion(double miles, double meters)
        {
            var distance = Distance.FromMiles(miles);

            distance.Meters.Should().Be(meters);
        }

        [TestCase(-1, -1000)]
        [TestCase(0, 0)]
        [TestCase(1, 1000)]
        [TestCase(1.5, 1500)]
        [TestCase(99, 99000)]
        public void MetersToKilometersConversion(double miles, double meters)
        {
            var distance = Distance.FromKilometers(miles);

            distance.Meters.Should().Be(meters);
        }
    }
}
