using Microsoft.Win32;
using OT_Performance_Tracer.forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace OT_Performance_Tracer.classes
{
    internal class Settings
    {
        public const string rootKey = "Software\\OTPerfTrace";
        private const string recentsKey = "Recents";
        private const string filtersKey = "Filters";
        private const string highlightsKey = "Highligths";

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

        public struct Highlight
        {
            public string filterText;
            public Color color;

            public Highlight(string _filterText, Color _color)
            {
                filterText = _filterText;
                color = _color;
            }
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

        private static string[] loadSubKey(string subKey)
        {
            //generic loader function
            //read from HKCU/Software/OTPerfTrace
            RegistryKey? lKey = Registry.CurrentUser!.OpenSubKey(Settings.rootKey, false);

            if (lKey == null) return [];

            RegistryKey? lSubKey = lKey.OpenSubKey(subKey, false);

            if (lSubKey == null) return [];

            //both keys exists, so read it
            string[] lOut = [];
            lSubKey.GetValueNames().ToList().ForEach(name =>
            {
                lOut = [.. lOut, lSubKey.GetValue(name)!.ToString()!];
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
        }

        public static void saveSubKey(string subKey, string[] data)
        {
            //read from HKCU/Software/OTPerfTrace/Filters
            RegistryKey? lKey = Registry.CurrentUser!.CreateSubKey(Settings.rootKey, true);

            lKey.DeleteSubKeyTree(subKey, false); //purge old values
            RegistryKey? lSubKey = lKey.CreateSubKey(subKey, true);

            for (int i = 0; i < data.Length; i++)
            {
                lSubKey.SetValue(i.ToString(), data[i]);
            }
        }

        #endregion "Generic Load/Save"

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

        #endregion "Recents Load/Save"

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

        #endregion "Filters Load/Save"

        #region "Highligths Load/Save"

        public static Highlight[] LoadHighLights()
        {
            string[] data = loadSubKey(highlightsKey);

            //now convert this string data into output data
            Highlight[] output = [];
            foreach (string item in data) //probably a better way to do this
            {
                output = [.. output, Newtonsoft.Json.JsonConvert.DeserializeObject<Highlight>(item)];
            }

            return output;
        }

        public static void SaveHighlights(Highlight[] data)
        {
            //convert input into simple array of string
            string[] simpleData = [];

            foreach (Highlight item in data) //probably a better way to do this
            {
                simpleData = [.. simpleData, Newtonsoft.Json.JsonConvert.SerializeObject(item)];
            }

            //now ssave to registry
            saveSubKey(highlightsKey, simpleData);
        }

        #endregion "Highligths Load/Save"
    }
}