using Microsoft.AspNetCore.Identity;

namespace FlowerShop.WebAPI
{
    public class SeedIdentityData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string adminEmail = "admin@mail.ua";
            string password = "Admin12345!";

            // Перевірка наявності ролі адміністратора
            if (await roleManager.FindByNameAsync("Admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // Перевірка наявності користувача з роллю адміністратора
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                var user = new IdentityUser { UserName = adminEmail, Email = adminEmail };
                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    // Додавання ролі адміністратора до користувача
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
