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
    public class MemberControllerTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IMemberService> _serviceMock;
        private readonly MemberController _sut;
        public MemberControllerTests()
        {
            _fixture = new Fixture();
            _serviceMock = _fixture.Freeze<Mock<IMemberService>>();
            _sut = new MemberController(_serviceMock.Object);
        }
            [Fact]
            public void GetMemberClaims_ShoulsReturenOkResponse_WhenDataFound()
            {
                //Arrangr
                var MemberListsMock = _fixture.Create<IEnumerable<MemberList>>();
                _serviceMock.Setup(x => x.GetMemberClaim()).Returns(MemberListsMock);

                //Act
                var result = _sut.GetMemberClaim();

                // Assert
                //Assert.IsType<OkObjectResult>(result as OkObjectResult);
                result.Should().NotBeNull();
                result.Should().BeAssignableTo<IEnumerable<MemberList>>();
                //result.Should().BeAssignableTo<OkObjectResult>();

            }
     }
 }

