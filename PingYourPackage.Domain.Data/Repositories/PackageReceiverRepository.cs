using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PingYourPackage.Domain.Data.Contracts;
using Model = PingYourPackage.Domain.Data.Models;

namespace PingYourPackage.Domain.Data.Repositories
{
    public class PackageReceiverRepository : IRepository<Model.PackageReceiver>
    {
        private PingYourPackageEntities Repository;

        public PackageReceiverRepository(PingYourPackageEntities repo)
        {
            this.Repository = repo;
        }

        public IEnumerable<Model.PackageReceiver> GetAll() 
        {
            try
            {
                return this.Repository.PackageReceivers.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public Model.PackageReceiver GetSingle(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.PackageReceiver> FindBy(System.Linq.Expressions.Expression<Func<Model.PackageReceiver, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Add(Model.PackageReceiver entity)
        {
            throw new NotImplementedException();
        }

        public int Edit(int id, Model.PackageReceiver entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(Model.PackageReceiver entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }
    }
}
