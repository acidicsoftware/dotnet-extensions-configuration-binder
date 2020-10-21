namespace Acidic.Extensions.Configuration
{
    /// <summary>
    /// Base class for classes representing configuraiton sub-sections.
    /// </summary>
    public abstract class Configurations
    {
        /// <summary>
        /// The default sub-section key of the configuration section.
        /// </summary>
        public string SectionKey { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Configurations"/> class.
        /// </summary>
        /// <param name="sectionKey">The default sub-section key of the configuration section.</param>
        protected Configurations(string sectionKey)
        {
            SectionKey = sectionKey;
        }
    }
}