using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Data
{
    public class DataTest
    {
        public static List<User> Users { get; set; } = new List<User>()
        {
           new User { Id = 1, Username = "admin", Password = "123" },
           new User { Id = 2, Username = "user", Password = "123" },
           new User { Id = 3, Username = "customer", Password = "123" },
        };

        public static List<Role> Roles { get; set; } = new List<Role>()
        {
            new Role { Id = 1, Name = "Admin"},
            new Role { Id = 2, Name = "Staff"},
            new Role { Id = 3, Name = "Customer"},
        };

        public static List<UserRole> UserRoles { get; set; } = new List<UserRole>()
        {
            new UserRole { Id = 1, UserId = 1, RoleId = 1},
            new UserRole { Id = 2, UserId = 2, RoleId = 2},
            new UserRole { Id = 3, UserId = 3, RoleId = 3},
            new UserRole { Id = 4, UserId = 2, RoleId = 3},
        };

        public static List<Permission> Permissions { get; set; } = new List<Permission>()
        {
            new Permission { Id = 1, Name = "Get Product", Function = PermissionRegister.GetProduct},
            new Permission { Id = 2, Name = "Create Product", Function = PermissionRegister.CreateProduct},
            new Permission { Id = 3, Name = "Edit Product", Function = PermissionRegister.EditProduct},
            new Permission { Id = 4, Name = "Delete Product", Function = PermissionRegister.DeleteProduct},
        };

        public static List<RolePermission> RolePermissions { get; set; } = new List<RolePermission>()
        {
            new RolePermission { Id = 1, RoleId = 2, PermissionId = 1},
            new RolePermission { Id = 2, RoleId = 2, PermissionId = 2},
            new RolePermission { Id = 3, RoleId = 2, PermissionId = 3},
            new RolePermission { Id = 4, RoleId = 2, PermissionId = 4},
            new RolePermission { Id = 5, RoleId = 3, PermissionId = 1},
            new RolePermission { Id = 6, RoleId = 3, PermissionId = 2},
        };

        private static class PermissionRegister
        {
            public const string GetProduct = "GetProduct";
            public const string CreateProduct = "CreateProduct";
            public const string EditProduct = "EditProduct";
            public const string DeleteProduct = "DeleteProduct";
        }

        public static List<Product> Products { get; set; } = new List<Product>()
        {
            new Product{Id = 1, Name="Iphone X"},
            new Product{Id = 2, Name="Iphone Xsmax"},
            new Product{Id = 3, Name="Iphone 11"},
            new Product{Id = 4, Name="Iphone 11 Pro"},
            new Product{Id = 5, Name="Iphone 11 Promax"},
            new Product{Id = 6, Name="Iphone 12"},
        };
    }
}
