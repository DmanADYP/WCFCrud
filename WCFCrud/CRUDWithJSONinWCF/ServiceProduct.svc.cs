using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CRUDWithJSONinWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceProduct" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceProduct.svc or ServiceProduct.svc.cs at the Solution Explorer and start debugging.
    public class ServiceProduct : IServiceProduct
    {
        public List<Product> findAll()
        {
            using (MyDemoEntities mde = new MyDemoEntities())
            {
                return mde.CityStates.Select(pe => new Product
                {
                    ID = pe.ID.ToString(),
                    City = pe.City,
                    State = pe.State
                }).ToList();
            }
        }
        public Product find(string id)
        {

            using (MyDemoEntities mde = new MyDemoEntities())
            {
                int nid = Convert.ToInt32(id);
                return mde.CityStates.Where(pe => pe.ID == nid).Select(pe => new Product
                {
                    ID = pe.ID.ToString(),
                    City = pe.City,
                    State = pe.State
                }).First();
            }
        }
        public bool create(Product product)
        {
            using (MyDemoEntities mde = new MyDemoEntities())
            {


                try
                {
                    CityState pe = new CityState();

                    pe.City = product.City;
                    pe.State = product.State;
                    mde.CityStates.Add(pe);
                    mde.SaveChanges();
                    return true;

                }
                catch (Exception)
                {

                    return false;
                }
            }
        }
        public bool edit(Product product)
        {
            using (MyDemoEntities mde = new MyDemoEntities())
            {
                try
                {
                    int nid = Convert.ToInt32(product.ID);
                    CityState pe = mde.CityStates.Single(p => p.ID ==
                   nid );
                    pe.City = product.City;
                    pe.State = product.State;
                    mde.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public bool delete(Product product)
        {
            using (MyDemoEntities mde = new MyDemoEntities())
            {
                try
                {
                    int nid = Convert.ToInt32(product.ID);
                    CityState pe = mde.CityStates.Single(p => p.ID == nid);
                    mde.CityStates.Remove(pe);
                    mde.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }


    }
}
