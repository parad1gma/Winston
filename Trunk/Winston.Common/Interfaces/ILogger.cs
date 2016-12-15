using System;

namespace Winston.Common.Interfaces
{
    public interface ILogger
    {
        void DebugMessage(string messageText, params object[] args);
        void Error(string errorMessage, params object[] args);
        void ErrorWithException(Exception e);
        void ErrorWithException(Exception ex, string errorMessage);
        void ErrorWithException(Exception ex, params object[] args);
        void Message(string messageText, params object[] args);
    }
}
