using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService
    {


        public static List<ProductDTO> GetAllProducts()
        {
           var data = DataAccessFactory.ProductData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Product, ProductDTO>();
            });


            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ProductDTO>>(data);
            return mapped;
        }
        public static ProductDTO GetProduct(int id)
        {
            var data = DataAccessFactory.ProductData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Product, ProductDTO>();
            });


            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ProductDTO>(data);
            return mapped;
        }
        public static bool Create(ProductDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Product, ProductDTO>();
                c.CreateMap<ProductDTO, Product>();

            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Product>(obj);
            var result = DataAccessFactory.ProductData().Create(data);
            
            return result;
        }
        public static bool Delete(int id)
        {
          
            var result = DataAccessFactory.ProductData().Delete(id);

            return result;
        }
    }
}
