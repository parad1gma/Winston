using log4net;
using Newtonsoft.Json;
using System;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Winston.Common
{
    public static class Logger //: ILogger
    {
        private static ILog _log = LogManager.GetLogger("Logger");

        //DI ready... => should be implement soon
        //public static Logger(ILog log)
        //{
        //    _log = log;
        //}

        public static void Message(string messageText, params object[] args)
        {
            string message = string.IsNullOrWhiteSpace(messageText) ? string.Empty : messageText;
            _log.InfoFormat(message, args);
        }

        public static void ErrorWithException(Exception ex, string errorMessage)
        {
            string message = string.IsNullOrWhiteSpace(errorMessage) ? string.Empty : errorMessage;
            _log.Error(errorMessage, ex);
        }

        public static void ErrorWithException(Exception e)
        {
            _log.Error(string.Empty, e);
        }

        public static void ErrorWithException(Exception ex, params object[] args)
        {
            var parameters = "";
            foreach (var item in args)
            {
                if (item != null)
                {
                    parameters += String.Format("{0}| ", JsonConvert.SerializeObject(item));
                }
            }

            _log.Error(parameters, ex);
        }

        public static void Error(string errorMessage, params object[] args)
        {
            string message = string.IsNullOrWhiteSpace(errorMessage) ? string.Empty : errorMessage;
            _log.ErrorFormat(message, args);
        }

        public static void DebugMessage(string messageText, params object[] args)
        {
            var message = string.IsNullOrWhiteSpace(messageText) ? string.Empty : messageText;
            _log.DebugFormat(message, args);
        }

    }
}
