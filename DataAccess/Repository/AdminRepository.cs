using HCLSWebAPI.DataAccess.IRepository;
using HCLSWebAPI.DataBaseContext;
using HCLSWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCLSWebAPI.DataAccess.Repository
{
    public class AdminRepository : IAdminRepository
    {

        public DBContextt Adm;
        public AdminRepository(DBContextt _Adm) 
        {
            Adm = _Adm;
        }

        public async  Task<List<Admin>> AllAdmins()
        {
           return await  Adm.Admins.ToListAsync();
        } 

        public async Task<Admin> GetAdminByEmail(string Email)
        {
            return await Adm.Admins.Where(x => x.Email == Email).SingleOrDefaultAsync();
        }

        public async Task<Admin> GetAdminById(int AdminId)
        {
            return await  Adm.Admins.FindAsync(AdminId);
        }

        public async Task<List<Admin>> GetAdminByName(string AdminName)
        {
            return await Adm.Admins.Where(x => x.AdminName == AdminName).ToListAsync();
           
        }
        public async  Task<int> AdminRegistration(Admin admin)
        {
           await  Adm.Admins.AddAsync(admin);
            return  await Adm.SaveChangesAsync();
        }

        public async Task<int> UpdateAdmins(Admin admin)
        {
            Adm.Admins.Update(admin);
             return await Adm.SaveChangesAsync();
        }
        public async Task<int> DeleteAdmins(int AdminId)
        {
            var ad = Adm.Admins.Find(AdminId);
            Adm.Admins.Remove(ad);
            return await Adm.SaveChangesAsync();
        }
    }
}
