namespace TokeroDevTestingPlaywright
{
    public static class StaticSettings
    {
        public static bool ShowBrowsers { get; } = false;
        public static int Width { get; } = 1920;
        public static int Height { get; } = 1080;

        public static string MainWebsiteUrl { get; } = "https://tokero.dev";
        public static string Company { get; } = "TOKERO";
        public static long MaxTimeToLoadPage { get; } = 6000;

        public static List<string> SupportedLanguages { get; } =
        [
            "en",
            "ro",
            "de"
        ];
    }
}
