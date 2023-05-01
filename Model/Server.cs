using AlifTask.Common;

namespace AlifTask.Model
{
	internal class Server
	{
		private Dictionary<ProductCategory, double> ProductAdditionalPercents = new();
		private Dictionary<ProductCategory, InstallmentRange> ProductInstalmentRange = new();

		private PayPurchase payPurchaseStubMethod = new();
		private SMSNotification smsNotificationStubMethod = new();

		public Server()
		{
			ProductAdditionalPercents.Add(ProductCategory.Phone, 0.03);
			ProductAdditionalPercents.Add(ProductCategory.LapTop, 0.04);
			ProductAdditionalPercents.Add(ProductCategory.TV, 0.05);

			ProductInstalmentRange.Add(ProductCategory.Phone, InstallmentRange.From3To9);
			ProductInstalmentRange.Add(ProductCategory.LapTop, InstallmentRange.From3To12);
			ProductInstalmentRange.Add(ProductCategory.TV, InstallmentRange.From3To18);
		}

		// In task it said "Write a function/method where an e-shop sends four parameters to GET THE TOTAL PAYMENT AMOUNT for a product"
		// not "... TO PAY THE TOTAL PAYMENT AMOUNT ..."
		public double GetTotalPrice(Product product, double productPrice, int installmentMonths)
		{
			var additionalPaymentPercent = ProductAdditionalPercents[product.Category];
			var maxProductInstallmentMonths = (int)ProductInstalmentRange[product.Category];

			double totalPrice = productPrice;

			var totalAdditionalPaymentPercent = Math.Ceiling((double)installmentMonths / maxProductInstallmentMonths) * additionalPaymentPercent;

			totalPrice = totalPrice * (1 + totalAdditionalPaymentPercent);

			return totalPrice;
		}

		// so I made another method for paying process
		public void PayPayment(string paymentData, Customer customerData)
		{
            Console.WriteLine();

            payPurchaseStubMethod.Pay(customerData.Name, paymentData);

			var message = $"Some info about purchase\n{paymentData}";
			var userPhoneData = customerData.PhoneNumber;
			smsNotificationStubMethod.Send(message, userPhoneData);
		}
	}
}
