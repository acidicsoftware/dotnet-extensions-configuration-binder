using Microsoft.Extensions.Configuration;
using System;

namespace Acidic.Extensions.Configuration
{
    /// <summary>
    /// Extension methods for <see cref="IConfiguration"/> classes.
    /// </summary>
    public static class ConfigurationBinder
    {
        /// <summary>
        /// Attempts to bind the configurations from a sub-section to an instance of <typeparamref name="T"/>. The configuration sub-section is identified by the section key specified in the property <see cref="Configurations.SectionKey"/> in <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of returned configuration object.</typeparam>
        /// <param name="configuration">The configuration to read configurations from.</param>
        /// <returns>The configurations.</returns>
        /// <remarks>This method will never return null. If no matching sub-section is found with the specified key, an empty configuration object of type <see cref="T"/> will be returned.</remarks>
        public static T Bind<T>(this IConfiguration configuration) where T : Configurations, new()
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            var configurations = new T();
            configuration.GetSection(configurations.SectionKey).Bind(configurations);

            return configurations;
        }

        /// <summary>
        /// Attempts to bind the configurations from a sub-section to an instance of <typeparamref name="T"/>. The configuration sub-section is identified by the supplied section key.
        /// </summary>
        /// <typeparam name="T">The type of returned configuration object.</typeparam>
        /// <param name="configuration">The configuration to read configurations from.</param>
        /// <param name="sectionKey">The key of the configuration sub-section.</param>
        /// <returns>The configurations.</returns>
        /// <remarks>This method will never return null. If no matching sub-section is found with the specified key, an empty configuration object of type <see cref="T"/> will be returned.</remarks>
        public static T Bind<T>(this IConfiguration configuration, string sectionKey) where T : Configurations, new()
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            var configurations = new T();
            configuration.GetSection(sectionKey).Bind(configurations);

            return configurations;
        }
    }
}