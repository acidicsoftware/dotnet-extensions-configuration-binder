using Acidic.Extensions.Configuration.Binder.TestAssets;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Acidic.Extensions.Configuration.UnitTests
{
    [TestClass]
    public class ConfigurationBinderTests
    {
        [TestMethod]
        public void WHEN_BindingConfigurations_DefaultSectionKey_WHILE_ConfigurationIsNull_THEN_ThrowException()
        {
            // Arrange
            IConfiguration configuration = null;

            // Act
            ExceptionHelpers.ExpectArgumentNullException("configuration", () => configuration.Bind<TestConfigurations>());
        }

        [TestMethod]
        public void WHEN_BindingConfigurations_ExplicitSectionKey_WHILE_ConfigurationIsNull_THEN_ThrowException()
        {
            // Arrange
            IConfiguration configuration = null;

            // Act
            ExceptionHelpers.ExpectArgumentNullException("configuration", () => configuration.Bind<TestConfigurations>("SectionKey"));
        }

        [TestMethod]
        public void WHEN_BindingConfigurations_WHILE_NotProvidingExplicitSectionKey_THEN_UseSectionKeyOnConfigurationClassToGetSection()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var configurationSectionMock = new Mock<IConfigurationSection>();

            configurationMock
                .Setup(configuration => configuration.GetSection(It.Is<string>(sectionKey => sectionKey.Equals(TestConfigurations.TestSectionKey))))
                .Returns(configurationSectionMock.Object);

            var configuration = configurationMock.Object;

            // Act
            configuration.Bind<TestConfigurations>();

            // Assert
            configurationMock.Verify(
                configuration => configuration.GetSection(It.Is<string>(sectionKey => sectionKey.Equals(TestConfigurations.TestSectionKey))),
                Times.Once
            );
        }

        [TestMethod]
        public void WHEN_BindingConfigurations_WHILE_ProvidingExplicitSectionKey_THEN_UseProvidedSectionKeyToGetSection()
        {
            // Arrange
            const string expectedSectionKey = "SomeRandomSectionKey";

            var configurationMock = new Mock<IConfiguration>();
            var configurationSectionMock = new Mock<IConfigurationSection>();

            configurationMock
                .Setup(configuration => configuration.GetSection(It.Is<string>(sectionKey => sectionKey.Equals(expectedSectionKey))))
                .Returns(configurationSectionMock.Object);

            var configuration = configurationMock.Object;

            // Act
            configuration.Bind<TestConfigurations>(expectedSectionKey);

            // Assert
            configurationMock.Verify(
                configuration => configuration.GetSection(It.Is<string>(sectionKey => sectionKey.Equals(expectedSectionKey))),
                Times.Once
            );
        }
    }
}