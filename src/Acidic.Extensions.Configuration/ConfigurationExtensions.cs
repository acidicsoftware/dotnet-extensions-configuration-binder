using Microsoft.Extensions.Configuration;
using System;

namespace Acidic.Extensions.Configuration
{
    /// <summary>
    /// Extension methods for <see cref="IConfiguration"/> classes.
    /// </summary>
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Get the configurations from the sub-section with the default section key specified in the property <see cref="Configurations.SectionKey"/> in the type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of returned configuration object.</typeparam>
        /// <param name="configuration">The configuration to read configurations from.</param>
        /// <returns>The configurations.</returns>
        /// <remarks>This method will never return null. If no matching sub-section is found with the specified key, an empty configuration object of type <see cref="T"/> will be returned.</remarks>
        public static T GetConfigurations<T>(this IConfiguration configuration) where T : Configurations, new()
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            var settings = new T();
            configuration.GetSection(settings.SectionKey).Bind(settings);

            return settings;
        }

        /// <summary>
        /// Get the configurations from the sub-section with the specified section key.
        /// </summary>
        /// <typeparam name="T">The type of returned configuration object.</typeparam>
        /// <param name="configuration">The configuration to read configurations from.</param>
        /// <param name="sectionKey">The key of the configuration sub-section.</param>
        /// <returns>The configurations.</returns>
        /// <remarks>This method will never return null. If no matching sub-section is found with the specified key, an empty configuration object of type <see cref="T"/> will be returned.</remarks>
        public static T GetConfigurations<T>(this IConfiguration configuration, string sectionKey) where T : Configurations, new()
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            var settings = new T();
            configuration.GetSection(sectionKey).Bind(settings);

            return settings;
        }
    }
}