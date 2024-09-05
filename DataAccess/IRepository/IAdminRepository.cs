using HCLSWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HCLSWebAPI.DataAccess.IRepository
{
    public interface IAdminRepository
    {
        public Task< List<Admin>> AllAdmins();
        public Task<Admin> GetAdminById(int AdminId);
        public Task<List<Admin>> GetAdminByName(string AdminName);
        public Task<Admin> GetAdminByEmail(string Email);
        public Task<int> AdminRegistration(Admin admin);
        public Task<int> UpdateAdmins(Admin admin);
        public Task<int> DeleteAdmins(int AdminId);
    }
}
