using Microsoft.Win32;

namespace OT_Performance_Tracer.classes
{
    internal class LogFilters
    {
        public enum FilterTypes
        {
            Logfilter,
            ThreadFilter
        }

        private const string rootKey = "Software\\OTPerfTrace";
        private const string filtersKey = "Filters";

        public static string[] getRegistrySettings(FilterTypes filter)
        {
            //read from HKCU/Software/OTPerfTrace/Filters
            RegistryKey? lKey = Registry.CurrentUser!.OpenSubKey(rootKey, false);

            if (lKey == null) return [];

            RegistryKey? lSubKey = lKey.OpenSubKey(filtersKey, false);

            if (lSubKey == null) return [];

            //now there is an additional sub key for filter type
            RegistryKey? lFilterKey = lSubKey.OpenSubKey(filter.ToString(), false);

            if (lFilterKey == null) return [];

            //both keys exists, so read it
            string[] lOut = [];
            lFilterKey.GetValueNames().ToList().ForEach(name =>
            {
                lOut = [.. lOut, lFilterKey.GetValue(name)!.ToString()!];
            });

            return lOut;
        }

        public static void setRegistrySettings(string[] filters, FilterTypes filter)
        {
            //read from HKCU/Software/OTPerfTrace/Filters
            RegistryKey? lKey = Registry.CurrentUser!.CreateSubKey(rootKey, true);
            lKey.DeleteSubKeyTree(filtersKey, false); //purge old values

            RegistryKey? lSubKey = lKey.CreateSubKey(filtersKey, true);

            RegistryKey? lFilterKey = lSubKey.CreateSubKey(filter.ToString(), true);

            for (int i = 0; i < filters.Length; i++)
            {
                lFilterKey.SetValue(i.ToString(), filters[i]);
            }
            ;
        }

        public static void addFilter(string singleFilter, FilterTypes filter)
        {
            //load the filters
            string[] filters = getRegistrySettings(filter);

            //append
            filters = [.. filters, singleFilter];

            //save
            setRegistrySettings(filters, filter);
        }
    }
}