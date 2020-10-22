using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Acidic.Extensions.Configuration.UnitTests
{
    [TestClass]
    public class ConfigurationsTests
    {
        [DataTestMethod]
        [DataRow("Hello, World!")]
        [DataRow("  ")]
        [DataRow("")]
        [DataRow(null)]
        public void WHEN_InitializingConfigurations_WHILE_AnySectionKeyIsSet_THEN_CreateInstance(string expectedSectionKey)
        {
            // Act
            var configurations = new Mock<Configurations>(expectedSectionKey).Object;

            // Assert
            Assert.AreEqual(expectedSectionKey, configurations.SectionKey);
        }
    }
}