namespace FlowerShop.UI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddHttpClient("FlowerShopApiClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:44383/");
            });

            return services;
        }
    }

}
