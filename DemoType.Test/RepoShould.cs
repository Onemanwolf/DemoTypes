using AutoFixture;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DemoTypes.Test
{
    public class RepoShould
    {

       
        Fixture _fixture { get; set; }

        Repo<Person> _sut { get; set; }


        public RepoShould()
        {
            _sut = new Repo<Person>();
            _fixture = new Fixture();
        }


        [Fact]
        public async void Save()
        {
            //Arrange
                var person = _fixture.Build<Person>()
               .With(x => x.Id, _fixture.Create<string>("Id"))
               .With(x => x.firstName, _fixture.Create<string>("firstName"))
               .With(x => x.lastName, _fixture.Create<string>("lastName"))
               .Create();
            //Act
                await _sut.Save(person);
            //Assert
                _sut._reposistory.Should().Contain(person);
        }

        [Fact]
        public async void Delete()
        {
            //Arrange
                var person = _fixture.Build<Person>()
                .With(x => x.Id, _fixture.Create<string>("Id"))
                .With(x => x.firstName, _fixture.Create<string>("firstName"))
                .With(x => x.lastName, _fixture.Create<string>("lastName"))
                .Create();
            //Act
                await _sut.Save(person);

                await _sut.Delete(person);
            //Assert
                _sut._reposistory.Should().BeEmpty();

        }

       


    }
}
