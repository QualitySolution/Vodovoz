using System;
using System.Runtime.Serialization;

namespace EmailSendingWorkerService
{
	class ResponseNotSuccededException : Exception
	{
		public ResponseNotSuccededException()
		{
		}

		public ResponseNotSuccededException(string message) : base(message)
		{
		}

		public ResponseNotSuccededException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected ResponseNotSuccededException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
