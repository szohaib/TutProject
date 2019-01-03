using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ApplicationUtility
{
    public class Utility
    {
        private static string _connectionString;
        private static string _dateFormat;
        private static string _calendarImage;
        private static bool _showHijri;
        private static DataSet _resourceDataset;

        public static DataSet ResourceDataset
        {
            get { return Utility._resourceDataset; }
            set { Utility._resourceDataset = value; }
        }

        public static string IFIIEntities
        {
            get { return Utility._connectionString; }
            set { Utility._connectionString = value; }
        }

        public static string ConnectionString
        {
            get { return Utility._connectionString; }
            set { Utility._connectionString = value; }
        }

        public static string DateFormat
        {
            get { return Utility._dateFormat; }
            set { Utility._dateFormat = value; }
        }

        public static string CalendarImage
        {
            get { return Utility._calendarImage; }
            set { Utility._calendarImage = value; }
        }
        

        public static bool ShowHijri
        {
            get { return Utility._showHijri; }
            set { Utility._showHijri = value; }
        }
    }
}
