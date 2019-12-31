using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Logger
    {
        public enum MessageSeverity
        {
            Exception,
            Error,
            Warning,
            Message,
            Debug
        }
        public struct LogMessage
        {
            public string Message;
            public MessageSeverity Severity;
        }

        private List<LogMessage> m_log = new List<LogMessage>();

        public void AppendMessage(string Message, MessageSeverity Severity)
        {
            m_log.Add(new LogMessage() { Message = Message, Severity = Severity });
        }

        public string[] GetMessages(MessageSeverity MinimumSeverity)
        {
            List<string> messages = new List<string>();
            var log = m_log.ToArray();
            foreach(var message in log)
            {
                if((int)message.Severity <= (int)MinimumSeverity)
                    messages.Add(string.Format("[{0}] {1}",message.Severity.ToString(),message.Message));
            }
            return messages.ToArray();
        }

        public void Clear()
        {
            m_log.Clear();
        }
    }
}
