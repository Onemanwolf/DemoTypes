using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AutoFixture;
using FluentAssertions;
using DemoTypes;

namespace DemoTypes.Test
{
    public class BufferShould
    {

        [Fact]
        public void WriteToBuffer()
        {
            var sut = new Buffer<string>();
            var fixture = new Fixture();
            var value = fixture.Create<string>();

            sut.Write(value);

            sut.IsEmpty.Should().Be(false);

        }

        [Fact]
        public void ReadFromBuffer()
        {
            var sut = new Buffer<string>();
            var fixture = new Fixture();
            var value = fixture.Create<string>();
            sut.Write(value);
            var result = sut.Read();
            result.Should().Be(value);
        }

    }
}
