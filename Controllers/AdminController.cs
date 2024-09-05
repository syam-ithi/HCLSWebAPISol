using HCLSWebAPI.DataAccess.IRepository;
using HCLSWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace HCLSWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public IAdminRepository AdRef;
        public AdminController(IAdminRepository _adRef)
        {
            AdRef = _adRef;
        }
        [HttpGet]
        [Route("AllAdmins")]
        public async Task<IActionResult> AllAdmins()
        {
            try
            {
                var AdmList = await AdRef.AllAdmins();
                if (AdmList.Count > 0)
                {
                    return Ok(AdmList);
                }
                else
                {
                    return NotFound("The admins was not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong...!\n" + "Issue:" + ex.Message + "\n we will solve this issue soon");

            }
        }
        [HttpGet]
        [Route("GetAdminById")]
        public async Task<IActionResult> GetAdminById(int AdminId)
        {
            try
            {
                var Adm = await AdRef.GetAdminById(AdminId);
                if (Adm != null)
                {
                    return Ok(Adm);
                }
                else
                {
                    return NotFound("AdminId was not Found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong...!\n" + "Issue:" + ex.Message + "\n we will solve this issue soon");
            }

        }
        [HttpGet]
        [Route("GetAdminByName")]
    
        public async Task<IActionResult> GetAdminByName(string Name)
        {
            try
            {
                var AdmList = await AdRef.GetAdminByName(Name);
                if(AdmList.Count>0)
                {
                    return Ok(AdmList);
                }
                else
                {
                    return NotFound("The AdminName was not Found");
                }
            }
            catch(Exception ex)
            {
                return BadRequest("Something went wrong...!\n" + "Issue:" + ex.Message + "\n we will solve this issue soon");
            }

        }
        [HttpGet]
        [Route("GetAdminByEmail")]
        public async Task<IActionResult>GetAdminByEmail(string Email)
        {
            try
            {
                var adm = await AdRef.GetAdminByEmail(Email);
                if (adm != null)
                {
                    return Ok(adm);
                }
                else
                {
                    return NotFound("The record was not found");

                }

            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong...!\n" + "Issue:" + ex.Message + "\n we will solve this issue soon");
            }
        }

        
        [HttpPost]
        [Route("AdminRegistration")]
       
        public async Task<IActionResult> AdminRegistration(Admin admin)
        {
            try
            {
                var count = await AdRef.AdminRegistration(admin);
                if (count > 0)
                {

                    return Ok(count);
                }
                else
                {
                    return NotFound("record was not insert");
                }
            }

            catch (Exception ex)
            {
                return BadRequest("Something went wrong...!\n" + "Issue:" + ex.Message + "\n we will solve this issue soon");
            }
        }
        [HttpPut]
        [Route("UpdateAdmins")]
        public async Task<IActionResult> UpdateAdmins(Admin admin)
        {
            try

            {
                var Count = await AdRef.UpdateAdmins(admin);
                if (Count > 0)
                {
                    return Ok(Count);
                }
                else
                {
                    return NotFound("Record was not update");
                }

            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong...!\n" + "Issue:" + ex.Message + "\n we will solve this issue soon");
            }
        }
        [HttpDelete] 
        [Route("DeleteAdmins")]
        public async  Task<IActionResult> DeleteAdmins(int AdminId)
        {
            try
            {
                var Count = await AdRef.DeleteAdmins(AdminId);
                if (Count > 0)
                {
                    return Ok(Count);
                }
                else
                {
                    return NotFound("Response was deleted");

                }
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong...!\n" + "Issue:" + ex.Message + "\n we will solve this issue soon");
            }
        }

            

    }
}
