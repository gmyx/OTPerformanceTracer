using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT_Performance_Tracer
{
    internal class LogFilters
    {
        public static string[] Excludes = [];

        private const string rootKey = "Software\\OTPerfTrace";
        private const string filtersKey = "Filters";

        public static string[] getRegistrySettings()
        {
            //read from HKCU/Software/OTPerfTrace/Filters
            RegistryKey? lKey = Registry.CurrentUser!.OpenSubKey(rootKey, false);

            if (lKey == null) return [];

            RegistryKey? lSubKey = lKey.OpenSubKey(filtersKey, false);

            if (lSubKey == null) return [];

            //both keys exists, so read it
            String[] lOut = [];
            lSubKey.GetValueNames().ToList().ForEach(name =>
            {
                lOut = [.. lOut, lSubKey.GetValue(name)!.ToString()!];
            });

            return lOut;
        }

        public static void setRegistrySettings(string[] filters) {
            //read from HKCU/Software/OTPerfTrace/Filters
            RegistryKey? lKey = Registry.CurrentUser!.CreateSubKey(rootKey, true);
            lKey.DeleteSubKey(filtersKey, false); //purge old values

            RegistryKey? lSubKey = lKey.CreateSubKey(filtersKey, true);

            for (int i = 0; i < filters.Length; i++)
            {
                lSubKey.SetValue(i.ToString(), filters[i]);
            };
        }
    }
}
