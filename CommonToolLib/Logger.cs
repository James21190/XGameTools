using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CommonToolLib
{
    public sealed class Logger
    {
        public enum MessageSeverity
        {
            Debug,
            Warning,
            Error,
            Exception,
            Message,
        }
        private struct LogMessage
        {
            public DateTime Time;
            public MessageSeverity Severity;
            public string Message;

            public override string ToString()
            {
                return string.Format("[{0}] {1}: {2}", Time.ToString(), Severity.ToString(), Message);
            }
        }

        private List<LogMessage> m_log = new List<LogMessage>();

        public void Log(MessageSeverity Severity, string Message)
        {
            m_log.Add(new LogMessage() { Message = Message, Severity = Severity, Time = DateTime.Now });
        }

        public string[] GetMessages()
        {
            var items = m_log.ToArray();
            var result = new string[items.Length];

            for (int i = 0; i < items.Length; i++)
            {
                result[i] = items[i].ToString();
            }

            return result;
        }

        public void Clear()
        {
            m_log.Clear();
        }

        #region IO
        private string _OutputPath;
        /// <summary>
        /// Set the destination file for writing logs.
        /// The file is overwritten.
        /// </summary>
        /// <param name="path"></param>
        public void SetOutputFile(string path)
        {
            _OutputPath = path;
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// Append current logs to the output file.
        /// The log is then cleared.
        /// </summary>
        public void DumpLog()
        {
            var sb = new StringBuilder();
            var items = m_log.ToArray();
            m_log.Clear();
            foreach (var item in items)
            {
                sb.AppendLine(item.ToString());
            }

            File.WriteAllText(_OutputPath, sb.ToString());
        }
        #endregion
    }
}
