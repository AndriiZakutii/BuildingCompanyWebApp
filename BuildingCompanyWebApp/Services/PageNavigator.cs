using System;

namespace BuildingCompanyWebApp.Services
{
    public static class PageNavigator
    {
        public static string CurrentPageName { get; private set; } = "/Index";

        public static string PreviousPageName { get; private set; } = "/Index";

        public static int CurrentId { get; private set; }

        public static int PreviousId { get; private set; }

        public static int NextId { get; set; }

        public static void ChangeCurrentPage(string pageName)
        {
            if (string.IsNullOrEmpty(pageName))
                throw new ArgumentException($"{nameof(pageName)} cannot be empty or null");

            PreviousPageName = CurrentPageName;
            CurrentPageName = pageName;
        }

        public static void ChangeCurrentPage(string pageName, int id)
        {
            ChangeCurrentPage(pageName);

            PreviousId = CurrentId;
            CurrentId = id;
        }
    }
}
