using System.Collections.Generic;

namespace Core.Common
{
    public class OperationResult<T>
    {
        public T Value { get; set; }

        public List<string> MessageList { get; private set; }

        public OperationResult()
        {
            MessageList = new List<string>();
        }

        public OperationResult(T value, string message) : this()
        {
            this.Value = value;
            if (!string.IsNullOrWhiteSpace(message))
            {
                this.AddMessage(message);
            }
        }

        public void AddMessage(string message)
        {
            MessageList.Add(message);
        }
    }
}
