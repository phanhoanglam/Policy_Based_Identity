using Data.Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Service
{
    public interface IBusinessService
    {
        Product GetProductById(long productId);
        List<Product> GetAllProduct();
        Product AddProduct(Product product);
        Product UpdateProduct(Product product);
        Product DeleteProductById(long productId);
    }
    public class BusinessService : IBusinessService
    {
        public Product AddProduct(Product product)
        {
            long id = 1;
            if (DataTest.Products.Count > 0)
            {
                id = DataTest.Products.Max(x => x.Id) + 1;
            }
            product.Id = id;
            DataTest.Products.Add(product);
            return product;
        }

        public Product DeleteProductById(long productId)
        {
            var productDelete = GetProductById(productId);
            DataTest.Products.Remove(productDelete);
            return productDelete;
        }

        public List<Product> GetAllProduct()
        {
            var listProduct = DataTest.Products;
            return listProduct;
        }

        public Product GetProductById(long productId)
        {
            var product = DataTest.Products.FirstOrDefault(x => x.Id == productId);
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            var productUpdate = DataTest.Products.FirstOrDefault(x => x.Id == product.Id);
            if (productUpdate != null)
            {
                productUpdate.Name = product.Name;
                return productUpdate;
            }
            return null;
        }
    }
}
