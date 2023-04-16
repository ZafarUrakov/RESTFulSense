﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using FluentAssertions;
using Moq;
using RESTFulSense.Models.Attributes;
using System.Reflection;
using Xunit;

namespace RESTFulSense.Tests.Services.Foundations.StreamContents
{
    public partial class StreamContentServiceTests
    {
        [Fact]
        public void ShouldRetrieveStreamContent()
        {
            // given
            PropertyInfo somePropertyInfo = new Mock<PropertyInfo>().Object;

            RESTFulFileContentStreamAttribute randomStreamContent = CreateRandomStreamContent();
            RESTFulFileContentStreamAttribute expectedStreamContent = randomStreamContent;

            this.reflectionBrokerMock.Setup(reflectionBroker =>
                reflectionBroker.GetFileContentStreamAttribute(It.IsAny<PropertyInfo>()))
                    .Returns(expectedStreamContent);

            // when
            var actualStreamContent =
                this.streamContentService.RetrieveStreamContent(somePropertyInfo);

            // then
            this.reflectionBrokerMock.Verify(reflectionBroker =>
                reflectionBroker.GetFileContentStreamAttribute(It.IsAny<PropertyInfo>()), Times.Once);

            actualStreamContent.Should().BeSameAs(expectedStreamContent);

            this.reflectionBrokerMock.VerifyNoOtherCalls();
        }
    }
}