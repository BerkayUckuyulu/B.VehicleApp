using Alphasteller.VehicleApplication.DataAccess.Contexts;
using Alphasteller.VehicleApplication.DataAccess.Interfaces;
using Alphasteller.VehicleApplication.Entities.Concrete;
using Common.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.DataAccess.Repositories
{
    //Sadece Vehicle'dan türeyen classlar için.
    public class VehicleRepository<T> : IVehicleRepository<T> where T:Vehicle
    {
        private readonly VehicleContext _context;

        public VehicleRepository(VehicleContext context)
        {
            _context = context;
        }

        public List<T> GetAllByColorId(int id)
        {
            var items = _context.Set<T>();
            var list = new List<T>();
            foreach (var item in items)
            {
                if (item.ColorId == id)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        public List<T> GetAllByColorName(string colorName) 
        {
           var colors= _context.Set<Color>();
            var color=colors.FirstOrDefault(x => x.ColorName == colorName);
            var items = _context.Set<T>();
            var list = new List<T>();
            foreach (var item in items)
            {               
                if (item.ColorId==color?.ColorId)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var data =await _context.Set<T>().FindAsync(id);
            return data;
        }

        public Car HeadlightsById(int Id)
        {
            //Burada Headlight propertysi Vehicle base classında tanımlanabilirdi. Bu sayede metot tüm Vehicle türdeki classlar için kullanılabilirdi.

            var data = _context.Set<Car>().SingleOrDefault(x => x.Id == Id);
            if (data!=null && data.Headlight==false)
            {
                data.Headlight = true;
                return data;
            }
            if (data!=null && data.Headlight==true)
            {
                data.Headlight = false;
                return data;
            }
            else
            {              
                return data ;
            }
        }
    }
}
