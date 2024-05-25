namespace FlowerShop.UI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddHttpClient("FlowerShopApiClient", client =>
            {
                client.BaseAddress = new Uri("http://localhost:5264/");
            });

            return services;
        }
    }

}
