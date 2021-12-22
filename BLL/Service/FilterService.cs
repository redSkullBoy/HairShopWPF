using BLL.Interfaces;
using DAL.Interfaces;
using HairShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class FilterService : IFilterService
    {
        IDbRepository dataBase;
        public FilterService(IDbRepository dbRepository)
        {
            dataBase = dbRepository;
        }
        public List<ProductModel> GetFilltredProducts( int typeID)
        {
            return (List<ProductModel>)dataBase.Services.GetFilltredProducts( typeID).Select(i => new ProductModel { Product_Name = i.Название, unit_price = (decimal)i.Стоимость, volume = i.Объём });
        }
    }
}
