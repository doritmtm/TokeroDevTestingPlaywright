namespace TokeroDevTestingPlaywright
{
    public static class StaticSettings
    {
        public static string MainWebsiteUrl { get; } = "https://tokero.dev";
        public static string Company { get; } = "TOKERO";

        public static List<string> SupportedLanguages { get; } =
        [
            "en",
            "ro",
            "de"
        ];
    }
}
