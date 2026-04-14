using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Presentation.Login
{
    /// <summary>
    /// This class is responsible for logging application events to the Windows Event Log.
    /// </summary>
    public class clsAppLogger
    {
        static string _SourceName = "DVLD";
        static string _LogName = "Application";

        public clsAppLogger()
        {
            if(!EventLog.SourceExists(_SourceName))
            {
                EventLog.CreateEventSource(_SourceName, _LogName);
            }
        }

        /// <summary>
        /// This method logs an informational message to the Windows Event Log.
        /// </summary>
        /// <param name="message">The message text to be recorded in the event log.</param>
        public static void LogInfo(string message)
        {
            EventLog.WriteEntry(_SourceName, message, EventLogEntryType.Information);
        }

        /// <summary>
        /// This method logs a warning message to the Windows Event Log.
        /// </summary>
        /// <param name="message">The message text to be recorded in the event log.</param>
        public static void LogWarning(string message)
        {
            EventLog.WriteEntry(_SourceName, message, EventLogEntryType.Warning);
        }

        /// <summary>
        /// This method logs an error message to the Windows Event Log.
        /// </summary>
        /// <param name="message">The message text to be recorded in the event log.</param>
        public static void LogError(string message)
        {
            EventLog.WriteEntry(_SourceName, message, EventLogEntryType.Error);
        }
    }
}
