using PingYourPackage.Domain.Data.Contracts;
using Model = PingYourPackage.Domain.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PingYourPackage.Domain.Data.Repositories
{
    public class AffiliateRepository : IRepository<Model.Affiliate>, IAffiliateRepository<Model.Affiliate>
    {
        private PingYourPackageEntities Repository;

        public AffiliateRepository(PingYourPackageEntities repo)
        {
            this.Repository = repo;
        }

        public IEnumerable<Model.Affiliate> GetAll() 
        {
            try
            {
                //using (this.Repository = new PingYourPackageEntities())
                {
                    return this.Repository.Affiliates.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Model.Affiliate GetSingle(int id)
        {
            try
            {
                //using (this.Repository = new PingYourPackageEntities())
                {
                    return this.Repository.Affiliates.SingleOrDefault(affiliate => affiliate.Id == id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Model.Affiliate> FindBy(Expression<Func<Model.Affiliate, bool>> predicate)
        {
            try
            {
                //using (this.Repository = new PingYourPackageEntities())
                {
                    return this.Repository.Affiliates.Where(predicate).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Add(Model.Affiliate item)
        {
            try
            {
                //using (this.Repository = new PingYourPackageEntities())
                {
                    this.Repository.Affiliates.Add(item);
                    return this.Repository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Edit(int id, Model.Affiliate item)
        {
            try
            {
                //using (this.Repository = new PingYourPackageEntities())
                {
                    var itemToUpdate = this.Repository.Affiliates.SingleOrDefault(affiliate => affiliate.Id == id);

                    if (itemToUpdate != null)
                    {
                        //itemToUpdate = item;
                        item.Id = itemToUpdate.Id;
                        //this.Repository.Entry(itemToUpdate).State = System.Data.EntityState.Modified;
                        this.Repository.Entry(itemToUpdate).CurrentValues.SetValues(item);
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
                    var itemToRemove = this.Repository.Affiliates.SingleOrDefault(affiliate => affiliate.Id == id);
                    if (itemToRemove != null)
                    {
                        this.Repository.Affiliates.Remove(itemToRemove);
                    }
                    return this.Repository.SaveChanges();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Delete(Model.Affiliate item)
        {
            try
            {
                //using (this.Repository = new PingYourPackageEntities())
                {
                    this.Repository.Affiliates.Remove(item);
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
            return this.Repository.Affiliates.Count();
        }

        public Model.Affiliate GetAffiliateByReferenceNumber(string number)
        {
            try
            {
                int referenceNumber = Convert.ToInt32(number);
                //using (this.Repository = new PingYourPackageEntities())
                {
                    return this.Repository.Affiliates.SingleOrDefault(affilate => affilate.ReferenceNbr == referenceNumber);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
