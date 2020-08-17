using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Business.Utils
{
    public static class PermissionRegister
    {
        public const string GetProduct = "GetProduct";
        public const string CreateProduct = "CreateProduct";
        public const string EditProduct = "EditProduct";
        public const string DeleteProduct = "DeleteProduct";

        public static List<string> GetListPermission()
        {
            Type registerType = typeof(PermissionRegister);
            List<string> listConst = registerType
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy) // Get những thuộc tính public hoặc static hoặc FlattenHierarchy
                .Where(fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(string))
                .Select(x => (string)x.GetRawConstantValue()) // Get từng raw của field
                .ToList();

            return listConst;
        }
    }

    public class RoleFullPermission
    {
        public const string Admin = "Admin";
    }
}
