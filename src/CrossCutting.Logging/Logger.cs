using System;
using System.Collections.Generic;

namespace CrossCutting.Logging
{
    public class Logger
    {
        public Logger()
        {

        }

        /// <summary>
        /// Logs an event type error.
        /// </summary>
        /// <param name="message">Message to be recorded.</param>
        /// <param name="source">Source to be recorded.</param>
        /// <param name="messageException">Detail Message to be recorded.</param>
        /// <param name="userName">User generating the event.</param>
        /// <returns></returns>
        public LoggerResult Error(string message, string source = "", string messageException = "", string userName = "")
        {
            LoggerResult result = null;
            IEnumerable<string> errors = null;

            try
            {
                bool success = true;//_repository.RegisterEvent(EventLogTypes.Error, message, source, messageException, userName);

                if (success)
                {
                    result = new LoggerResult(true);
                }
                else
                {
                    errors = new List<string>() { "an error while trying to register the event has occurred." };
                    result = new LoggerResult(errors);
                }
            }
            catch (Exception ex)
            {
                errors = new List<string>() { ex.Message, ex.StackTrace };
                result = new LoggerResult(errors);
            }

            return result;
        }
    }
}
