using PingYourPackage.Domain.Data;
using PingYourPackage.Domain.Data.Contracts;
using Model = PingYourPackage.Domain.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PingYourPackage.Domain.Data.Repositories
{
    public class ShipmentRepository : IRepository<Model.Shipment>, IShipmentRepository<Model.Shipment>
    {
        private PingYourPackageEntities Repository;// = new PingYourPackageEntities();

        public ShipmentRepository(PingYourPackageEntities repo)
        {
            this.Repository = repo;
        }

        public IEnumerable<Model.Shipment> GetAll()
        {
            try
            {
                var shipments = this.Repository.Shipments.ToList();
                if(shipments != null && shipments.Count > 0)
                    return shipments;    

            }
            catch (Exception)
            {                
                throw;
            }
            return null;
        }

        public Model.Shipment GetSingle(int id)
        {
            try
            {
                //using (this.Repository = new PingYourPackageEntities())
                {
                    return this.Repository.Shipments.SingleOrDefault(shipment => shipment.Id == id);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public IEnumerable<Model.Shipment> FindBy(Expression<Func<Model.Shipment, bool>> predicate)
        {
            try
            {
                //using (this.Repository = new PingYourPackageEntities())
                {
                    return this.Repository.Shipments.Where(predicate).ToList();
                }
            }
            catch (Exception)
            {                
                throw;
            }
        }

        public int Add(Model.Shipment item)        
        {
            try
            {
                //using (this.Repository = new PingYourPackageEntities())
                {
                    this.Repository.Shipments.Add(item);
                    return this.Repository.SaveChanges();                     
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int Edit(int id, Model.Shipment item)
        {
            try
            {
                //using (this.Repository = new PingYourPackageEntities())
                {
                    var itemToUpdate = this.Repository.Shipments.SingleOrDefault(shipment => shipment.Id == id);

                    if (itemToUpdate != null)
                    {
                        //itemToUpdate = item;
                        item.Id = itemToUpdate.Id;
                        //this.Repository.Entry(itemToUpdate.PackageReceiver).State = System.Data.EntityState.Modified;
                        this.Repository.Entry(itemToUpdate).CurrentValues.SetValues(item);
                        this.Repository.Entry(itemToUpdate.PackageReceiver).CurrentValues.SetValues(item.PackageReceiver);
                        this.Repository.SaveChanges();
                    }

                    return this.Repository.SaveChanges();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int Delete(int id)
        {
            try
            {
                //using (this.Repository = new PingYourPackageEntities())
                {
                    var itemToRemove = this.Repository.Shipments.SingleOrDefault(shipment => shipment.Id == id);
                    if (itemToRemove != null)
                    { 
                        this.Repository.Shipments.Remove(itemToRemove);                        
                    }
                    return this.Repository.SaveChanges();
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Delete(Model.Shipment item)
        {
            try
            {
                //using (this.Repository = new PingYourPackageEntities())
                {
                    this.Repository.Shipments.Remove(item);
                }
                int rowsAffected = this.Repository.SaveChanges();
                return rowsAffected;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int Count()
        {
            return this.Repository.Shipments.Count();
        }

        public IEnumerable<Model.Shipment> GetShipmentsByAffiliateId(int id)
        {
            try
            {
                //using (this.Repository = new PingYourPackageEntities())
                {
                    return this.Repository.Shipments.Where(affiliate => affiliate.AffiliateReferenceNbr == id).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            } 
        }

        public Model.Shipment GetShipmentByTrackingNumber(string number)
        {
            try
            {
                int trackingNumber = Convert.ToInt32(number);
                //using (this.Repository = new PingYourPackageEntities())
                {
                    return this.Repository.Shipments.SingleOrDefault(shipment => shipment.TrackingNbr == trackingNumber);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }

}
