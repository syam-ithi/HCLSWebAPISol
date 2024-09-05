using HCLSWebAPI.DataAccess.IRepository;
using HCLSWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using HCLSWebAPI.DataBaseContext;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HCLSWebAPI.DataAccess.Repository
{
    public class AdminTypeRepository : IAdminTypeRepository
    {
        public DBContextt AdmRep;
        public AdminTypeRepository(DBContextt _AdmRep)
        {
            AdmRep = _AdmRep;
        }
        public async Task<List<AdminType>> AllAdminType()
        {
            return await AdmRep.AdminTypes.ToListAsync();
        }


        public  async Task<AdminType> GetAdminTypeById(int AdminTypeId)
        {
           return await AdmRep.AdminTypes.FindAsync(AdminTypeId);
        }

        public async Task<int> InsertAdminType(AdminType Admty)
        {
            await AdmRep.AdminTypes.AddAsync(Admty);
            return await AdmRep.SaveChangesAsync();

        }

        public async Task<int> UpdateAdminType(AdminType Admty)
        {
            AdmRep.AdminTypes.Update(Admty);
            return await AdmRep.SaveChangesAsync();
        }
        public async Task<int> DeleteAdminType(int AdminTypeId)
        {
            var adm=AdmRep.AdminTypes.Find(AdminTypeId);
            AdmRep.AdminTypes.Remove(adm);
            return await AdmRep.SaveChangesAsync();
        }

        public async  Task<List<AdminType>> GetAdminTypeByName(string AdminTypeName)
        {
          return  await  AdmRep.AdminTypes.Where(x=>x.AdminTypeName==AdminTypeName).ToListAsync();
        }
    }
}
    

