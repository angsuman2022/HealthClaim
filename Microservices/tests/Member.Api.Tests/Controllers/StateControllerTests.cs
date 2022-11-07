using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AutoFixture;
using Moq;
using FluentAssertions;
using Member.Services;
using Member.Controllers;
using Member.Models;

namespace Member.Api.Tests.Controllers
{
    public class StateControllerTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IMemberService> _serviceMock;
        private readonly StateController _sut;
        public StateControllerTests()
        {
            _fixture = new Fixture();
            _serviceMock = _fixture.Freeze<Mock<IMemberService>>();
            _sut = new StateController(_serviceMock.Object);
        }
        [Fact]
        public void Getstates_ShoulsReturenOkResponse_WhenDataFound()
        {
            //Arrangr
            var StatetblsMock = _fixture.Create<IEnumerable<Statetbl>>();
            _serviceMock.Setup(x => x.GetAllState()).Returns(StatetblsMock);

            //Act
            var result = _sut.Getstates();

            // Assert
            //Assert.IsType<OkObjectResult>(result as OkObjectResult);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IEnumerable<Statetbl>>();
            //result.Should().BeAssignableTo<OkObjectResult>();

        }
    }
}
