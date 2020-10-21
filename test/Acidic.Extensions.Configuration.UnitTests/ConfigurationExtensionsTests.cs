using Acidic.Extensions.Configuration.TestAssets;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Acidic.Extensions.Configuration.UnitTests
{
    [TestClass]
    public class ConfigurationExtensionsTests
    {
        [TestMethod]
        public void WHEN_GettingConfigurations_WHILE_ConfigurationIsNull_THEN_ThrowException()
        {
            // Arrange
            IConfiguration configuration = null;

            // Act
            ExceptionHelpers.ExpectArgumentNullException("configuration", () => configuration.GetConfigurations<TestConfigurations>());
        }

        [TestMethod]
        public void WHEN_GettingConfigurations_ExplicitSectionKey_WHILE_ConfigurationIsNull_THEN_ThrowException()
        {
            // Arrange
            IConfiguration configuration = null;

            // Act
            ExceptionHelpers.ExpectArgumentNullException("configuration", () => configuration.GetConfigurations<TestConfigurations>("SectionKey"));
        }
    }
}