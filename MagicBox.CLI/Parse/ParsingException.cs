
using System;
using System.Runtime.Serialization;

namespace MagicBox.CLI.Parse
{
	/// <summary>
	/// Exception thrown during parsing of command-line arguments.
	/// </summary>
	[Serializable]
	public class ParsingException : Exception
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		public ParsingException()
			: base()
		{
		}

		/// <summary>
		/// Constructor specifying error message.
		/// </summary>
		/// <param name="message">
		/// String representing error message.
		/// </param>
		public ParsingException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Constructor specifying error message and inner exception.
		/// </summary>
		/// <param name="message">
		/// String representing error message.
		/// </param>
		/// <param name="innerException">
		/// Exception representing inner exception.
		/// </param>
		public ParsingException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		/// Constructor specifying serialization data.
		/// </summary>
		/// <param name="info">
		/// SerializationInfo representing serialized exception data.
		/// </param>
		/// <param name="context">
		/// StreamingContext representing contextual data about exception
		/// source/destination.
		/// </param>
		protected ParsingException(SerializationInfo info,
			StreamingContext context)
			: base(info, context)
		{
		}
	}
}
