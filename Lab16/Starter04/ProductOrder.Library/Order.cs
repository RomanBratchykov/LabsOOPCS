using System.Net;
using System.Text.Json;

namespace ProductOrder.Library;

public class Order
{
    public int Id { get; set; }
    public DateTime DateOrdered { get; set; }
    public DateTime DateFulfilled { get; set; }
    public Customer? Customer { get; set; }
    public List<Product>? Products { get; set; }
}

public class OrderReader : DataReader
{
    private IExceptionLogger logger;
    private CustomerReader customerReader;
    private ProductReader productReader;

    public OrderReader(IExceptionLogger logger)
    {
        this.logger = logger;
        customerReader = new CustomerReader();
        productReader = new ProductReader();
    }

    public async Task<Order> GetOrderAsync(int orderId)
    {
        var order = new Order();
        try
        {
            Task<Order> orderDetails = GetOrderDetailsAsync(orderId);

            Task<Customer> customerDetails = customerReader.GetCustomerForOrderAsync(orderId);

            Task<List<Product>> productsDetails = productReader.GetProductsForOrderAsync(orderId);

            await Task.WhenAll(orderDetails, customerDetails, productsDetails)
                .ContinueWith
                (
                    task =>
                    {
                        logger.LogException(task.Exception);
                    }
                ).ConfigureAwait(false);

            if (orderDetails.IsCompletedSuccessfully && customerDetails.IsCompletedSuccessfully && productsDetails.IsCompletedSuccessfully)
            {

                order = orderDetails.Result;

                order.Customer = customerDetails.Result;

                order.Products = productsDetails.Result;
            }
        }
        catch (Exception ex)
        {
            logger.LogException(ex);
        }

        return order;
    }

    private async Task<Order> GetOrderDetailsAsync(int orderId)
    {
        HttpResponseMessage response =
            await client.GetAsync($"order/{orderId}").ConfigureAwait(false);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            var stringResult =
                await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<Order>(stringResult, options)!;
        }
        return null!;
    }
}
