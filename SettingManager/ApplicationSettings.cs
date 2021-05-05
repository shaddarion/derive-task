namespace SettingManager
{
    public class ApplicationSettings
    {
        public static string Url { get; set; }
        public static string Browser { get; set; }
        public static bool Headless { get; set; }
        public static int PageLoadTime { get; set; }
        public static int DefaultWaitTime { get; set; }
        public static string ReportDirectoryPath { get; set; }
    }
}
