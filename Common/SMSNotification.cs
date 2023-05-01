namespace AlifTask.Common
{
	internal class SMSNotification
	{
		public void Send(string message, string phoneNumber)
		{
			Console.WriteLine($"Message sent to {phoneNumber}:\n{message}");
		}
	}
}
