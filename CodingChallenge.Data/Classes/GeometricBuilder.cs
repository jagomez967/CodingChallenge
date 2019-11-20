using CodingChallenge.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class GeometricBuilder
    {
        private GeometricCounterList GeoList;
        public GeometricBuilder()
        {
            GeoList = new GeometricCounterList();
        }

        public IGeometricForm CreateObject(IGeometricForm IGeo)
        {
            GeoList.AddElement(IGeo);
            return IGeo;
        }

        public List<string> GetLines()
        {
            return GeoList.GetLines();
        }
    }

    public class GeometricCounterList
    {
        private List<GeometricCounter> list;
        public GeometricCounterList()
        {
            list = new List<GeometricCounter>();
        }
        public void AddElement(IGeometricForm geoForm)
        {
            GeometricCounter counter = list.FirstOrDefault(g => g.type == geoForm.GetType());
            if (counter != null)
            {
                list.Add(new GeometricCounter()
                {
                    qty = 1,
                    area = geoForm.GetArea(),
                    perimeter = geoForm.GetPerimeter()
                });
            }
            else
            {
                counter.qty++;
                counter.area += geoForm.GetArea();
                counter.perimeter += geoForm.GetPerimeter();
            }
        }
        public List<string> GetLines()
        {
            return new List<string>();
        }
    }

    public class GeometricCounter
    {
        public GeometricCounter()
        {

        }
        public int qty;
        public Type type;
        public Decimal area;
        public Decimal perimeter;
    }

}
