using Acidic.Extensions.Configuration.Binder.TestAssets;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace Acidic.Extensions.Configuration.Binder.IntegrationTests
{
    [TestClass]
    public class ConfigurationBinderTests
    {
        private static string SubSectionName = "SubSection";

        private static string RootSectionTestValue = nameof(RootSectionTestValue);
        private static string SubSectionTestValue = nameof(SubSectionTestValue);

        [TestMethod]
        public void WHEN_BindingConfigurations_WHILE_NotProvidingExplicitSectionKey_THEN_BindConfigurations()
        {
            // Arrange
            var expectedTestValue = RootSectionTestValue;

            var jsonStream = CreateJsonMemoryStream();
            var configuration = new ConfigurationBuilder().AddJsonStream(jsonStream).Build();

            // Act
            var configurations = configuration.Bind<TestConfigurations>();

            // Assert
            Assert.AreEqual(expectedTestValue, configurations.TestValue);
        }

        [TestMethod]
        public void WHEN_BindingConfigurations_WHILE_ProvidingExplicitSectionKey_THEN_BindConfigurations()
        {
            // Arrange
            var expectedTestValue = SubSectionTestValue;

            var jsonStream = CreateJsonMemoryStream();
            var configuration = new ConfigurationBuilder().AddJsonStream(jsonStream).Build();

            var sectionKey = $"{SubSectionName}:{TestConfigurations.TestSectionKey}";

            // Act
            var configurations = configuration.Bind<TestConfigurations>(sectionKey);

            // Assert
            Assert.AreEqual(expectedTestValue, configurations.TestValue);
        }

        private static MemoryStream CreateJsonMemoryStream()
        {
            var jsonStringBuilder = new StringBuilder();

            jsonStringBuilder.AppendLine($"{{");
            jsonStringBuilder.AppendLine($"  \"{ TestConfigurations.TestSectionKey }\": {{");
            jsonStringBuilder.AppendLine($"    \"{ nameof(TestConfigurations.TestValue) }\": \"{ RootSectionTestValue }\"");
            jsonStringBuilder.AppendLine($"  }},");
            jsonStringBuilder.AppendLine($"  \"{ SubSectionName }\": {{");
            jsonStringBuilder.AppendLine($"     \"{ TestConfigurations.TestSectionKey }\": {{");
            jsonStringBuilder.AppendLine($"       \"{ nameof(TestConfigurations.TestValue) }\": \"{ SubSectionTestValue }\"");
            jsonStringBuilder.AppendLine($"      }}");
            jsonStringBuilder.AppendLine($"   }}");
            jsonStringBuilder.AppendLine($"}}");

            var json = jsonStringBuilder.ToString();

            var configurationJsonStream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            return configurationJsonStream;
        } 
    }
}