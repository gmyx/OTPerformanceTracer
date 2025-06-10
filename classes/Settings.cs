using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT_Performance_Tracer.classes
{
    internal class Settings
    {
        public const string rootKey = "Software\\OTPerfTrace";
        private const string recentsKey = "Recents";
        private const string filtersKey = "Filters";

        public enum RecentTypes
        {
            Folder,
            SingleFile
        }

        public enum FilterTypes
        {
            Logfilter,
            ThreadFilter
        }

        #region "Generic Load/Save"
        private static string[] loadSubKey(string subKey, string typeName)
        {
            //generic loader function
            //read from HKCU/Software/OTPerfTrace 
            RegistryKey? lKey = Registry.CurrentUser!.OpenSubKey(Settings.rootKey, false);

            if (lKey == null) return [];

            RegistryKey? lSubKey = lKey.OpenSubKey(subKey, false);

            if (lSubKey == null) return [];

            //now there is an additional sub key for filter type
            RegistryKey? lTypeNameKey = lSubKey.OpenSubKey(typeName, false);

            if (lTypeNameKey == null) return [];

            //both keys exists, so read it
            string[] lOut = [];
            lTypeNameKey.GetValueNames().ToList().ForEach(name =>
            {
                lOut = [.. lOut, lTypeNameKey.GetValue(name)!.ToString()!];
            });

            return lOut;
        }

        public static void saveSubKey(string subKey, string typeName, string[] data)
        {
            //read from HKCU/Software/OTPerfTrace/Filters
            RegistryKey? lKey = Registry.CurrentUser!.CreateSubKey(Settings.rootKey, true);            

            RegistryKey? lSubKey = lKey.CreateSubKey(subKey, true);

            lSubKey.DeleteSubKeyTree(typeName, false); //purge old values

            RegistryKey? lFilterKey = lSubKey.CreateSubKey(typeName, true);

            for (int i = 0; i < data.Length; i++)
            {
                lFilterKey.SetValue(i.ToString(), data[i]);
            }
    ;
        }
        #endregion

        #region "Recents Load/Save"
        public static string[] LoadRecents(RecentTypes recent)
        {
            //load from registy a list of recent items
            return loadSubKey(recentsKey, recent.ToString());
        }

        public static void SaveRecents(string[] recents, RecentTypes recent)
        {
            saveSubKey(recentsKey, recent.ToString(), recents);
        }
        #endregion

        #region "Filters Load/Save"
        public static string[] LoadFilters(FilterTypes filter)
        {
           return loadSubKey(filtersKey, filter.ToString());
        }

        public static void SaveFilters(string[] filters, FilterTypes filter)
        {
            saveSubKey(filtersKey, filter.ToString(), filters);
        }

        public static void addFilter(string singleFilter, FilterTypes filter)
        {
            //load the filters
            string[] filters = LoadFilters(filter);

            //append
            filters = [.. filters, singleFilter];

            //save
            SaveFilters(filters, filter);
        }
        #endregion
    }
}
