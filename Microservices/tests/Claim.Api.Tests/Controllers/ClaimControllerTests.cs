using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AutoFixture;
using Moq;
using FluentAssertions;
using Claim.Services;
using Claim.Controllers;
using Claim.Models;

namespace Claim.Api.Tests.Controllers
{
    public class ClaimControllerTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IClaimService> _serviceMock;
        private readonly ClaimController _sut;
        public ClaimControllerTests()
        {
            _fixture = new Fixture();
            _serviceMock = _fixture.Freeze<Mock<IClaimService>>();
            _sut = new ClaimController(_serviceMock.Object);
        }
        [Fact]
        public void AddClaim_ValidObjectPassed_ReturnsCreatedResponse()
        {
            //Arrangr

            var ClaimtblsMock = _fixture.Create<Claimtbl>();
            var rtnstr= _fixture.Create<string>();
            _serviceMock.Setup(x => x.ClaimAdd(ClaimtblsMock)).Returns(rtnstr);
            

            //Act
            var result = _sut.ClaimAdd(ClaimtblsMock);
    

            // Assert
            //Assert.IsType<OkObjectResult>(result as OkObjectResult);
            result.Should().NotBeNull();
           // result.Should().BeAssignableTo<Action>();
            //result.Should().BeAssignableTo<OkObjectResult>();

        }
    }
}
