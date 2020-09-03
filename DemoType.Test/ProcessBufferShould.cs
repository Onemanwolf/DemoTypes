using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AutoFixture;
using FluentAssertions;
using Moq;

namespace DemoTypes.Test
{
    public class ProcessBufferShould
    {
        IBuffer<double> _buffer { get; set;}
        Fixture _fixture { get; set;}

        ProcessBuffer<double> _sut { get; set;}


        public ProcessBufferShould()
        {
            _sut = new ProcessBuffer<double>();
            _fixture = new Fixture();
            _buffer = _fixture.Create<Buffer<double>>();
        }


        [Fact]
        public void Process()
        {
            //arrange
           
            
            IBuffer<double> buffer = _fixture.Create<Buffer<double>>();
            var value1 = _fixture.Create<double>();
            var value2 = _fixture.Create<double>();
            var mstring = _fixture.Create("Name");
            var expected = value1 + value2;

            //act
            buffer.Write(value1);
            buffer.Write(value2);
           

            _sut.Process(buffer);
            //assert
            _sut.Result.Should().Be(expected);
           
        }

        [Fact]
        public void ProcessStrings()
        {
             var strings = _fixture.CreateMany<string>();

             var list = new List<string>();
             _fixture.AddManyTo(list);

            _sut.ProcessStrings(list);

            _sut.Strings.Should().Contain(list);
        }


        [Fact]
        public void ProcessClass()
        {
            var list = new List<string>();
            _fixture.AddManyTo(list);

            var sut = _fixture.Build<ProcessBuffer<double>>()
                .With(x => x.MyString, "Ploeh")
                .With(x => x.Strings, list )
                .Create();
              
       
            sut.MyString.Should().Be("Ploeh");
            sut.Strings.Should().Contain(list);
        }

    }
}
