using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Entities;

namespace WebStore.Data
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)

        {
            // создать БД, если она еще не создана
            context.Database.EnsureCreated();
            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль admin

                await roleManager.CreateAsync(roleAdmin);
            }
            // проверка наличия пользователей
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }

            //проверка наличия групп объектов
            if (!context.ProductCategory.Any())
            {
                context.ProductCategory.AddRange(
                    new List<ProductCategory>
                    {
                        new ProductCategory {ProductCategoryId=1, CategoryName="Женское"},
                        new ProductCategory {ProductCategoryId=2, CategoryName="Мужское"},
                        new ProductCategory {ProductCategoryId=3, CategoryName="Детское"},
                        new ProductCategory {ProductCategoryId=4, CategoryName="Бижутерия"}
                    });
                await context.SaveChangesAsync();

            }

            if (!context.ProductBrand.Any())
            {
                context.ProductBrand.AddRange(
                    new List<ProductBrand>
                    {
                        new ProductBrand { ProductBrandId=1, BrandName="Gucci"},
                        new ProductBrand { ProductBrandId=2, BrandName="Pandora"},
                        new ProductBrand { ProductBrandId=3, BrandName="Chanel"},
                        new ProductBrand { ProductBrandId=4, BrandName="alice + olivia"},
                        new ProductBrand { ProductBrandId=5, BrandName="Aquatalia"},
                        new ProductBrand { ProductBrandId=6, BrandName="Giuseppe Zanotti"},
                        new ProductBrand { ProductBrandId=7, BrandName="Louis Vuitton"}
                    });
                await context.SaveChangesAsync();

            }

            // проверка наличия объектов
            if (!context.Product.Any())
            {
                context.Product.AddRange(
                new List<Product>
                {
                    new Product {ProductName = "Твидовое платье Gardenia", ProductBrandId=1, ProductCategoryId=1,
                    Price=1250, Image="1411150896_RLLDTH_1.jpg", Description="Размер 26. Цвет: кремовый, красный, синий."},
                    new Product {ProductName = "Платье-фонарь с вышивкой Флоренсии", ProductBrandId=4, ProductCategoryId=1,
                    Price=1250, Image="1411297610_RLLDTH_1.jpg", Description="52% нейлон, 48% полиэстер"},
                    new Product {ProductName = "Замшевые мокасины Fausto, защищенные от непогоды", ProductBrandId=5, ProductCategoryId=2,
                    Price=1250, Image="1312073064_RLLDTH_1.jpg", Description="Размер 7.5."},
                    new Product {ProductName = "Твидовое платье Gardenia2", ProductBrandId=1, ProductCategoryId=1,
                    Price=1250, Image="1411150896_RLLDTH_1.jpg", Description="Размер 26. Цвет: кремовый, красный, синий."},
                    new Product {ProductName = "Твидовое платье Gardenia3", ProductBrandId=1, ProductCategoryId=1,
                    Price=1250, Image="1411150896_RLLDTH_1.jpg", Description="Размер 26. Цвет: кремовый, красный, синий."},
                    new Product {ProductName = "Твидовое платье Gardenia", ProductBrandId=1, ProductCategoryId=1,
                    Price=1250, Image="1411150896_RLLDTH_1.jpg", Description="Размер 26. Цвет: кремовый, красный, синий."},
                    new Product {ProductName = "Платье-фонарь с вышивкой Флоренсии", ProductBrandId=4, ProductCategoryId=1,
                    Price=1250, Image="1411297610_RLLDTH_1.jpg", Description="52% нейлон, 48% полиэстер"},
                    new Product {ProductName = "Замшевые мокасины Fausto, защищенные от непогоды", ProductBrandId=5, ProductCategoryId=2,
                    Price=1250, Image="1312073064_RLLDTH_1.jpg", Description="Размер 7.5."},
                    new Product {ProductName = "Твидовое платье Gardenia2", ProductBrandId=1, ProductCategoryId=1,
                    Price=1250, Image="1411150896_RLLDTH_1.jpg", Description="Размер 26. Цвет: кремовый, красный, синий."},
                    new Product {ProductName = "Твидовое платье Gardenia3", ProductBrandId=1, ProductCategoryId=1,
                    Price=1250, Image="1411150896_RLLDTH_1.jpg", Description="Размер 26. Цвет: кремовый, красный, синий."}
                });
                await context.SaveChangesAsync();
            }
        }
    }
}
