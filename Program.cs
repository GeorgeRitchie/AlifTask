using AlifTask.Common;
using AlifTask.Model;

namespace AlifTask
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Server server = new Server();

			Product phone = new Product()
			{
				Name = "phone",
				Category = ProductCategory.Phone,
				Description = "..."
			};

			var totalPayment = server.GetTotalPrice(phone, 1000, 18);
            Console.WriteLine($"Your total payment: {totalPayment} TJS");

			server.PayPayment($"Payment: {totalPayment} TJS", "Name: George, Phone number: +992925861485");
        }
	}
}