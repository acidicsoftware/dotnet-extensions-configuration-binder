namespace Acidic.Extensions.Configuration.Binder.TestAssets
{
    public class TestConfigurations : Configurations
    {
        public static string TestSectionKey = "TestSection";

        public string TestValue { get; set; }

        public TestConfigurations() : base(TestSectionKey)
        {
        }
    }
}