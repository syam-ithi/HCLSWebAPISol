using HCLSWebAPI.DataAccess.IRepository;
using HCLSWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HCLSWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminTypeController : ControllerBase
    {
        public IAdminTypeRepository AdmRef;
        public AdminTypeController(IAdminTypeRepository _AdmRef)
        {
            AdmRef = _AdmRef;
        }

        [HttpGet]
        [Route("AllAdminType")]

        public async Task<IActionResult> AllAdminType()
        {
            try
            {
                var AdmList = await AdmRef.AllAdminType();
                if (AdmList.Count > 0)
                {
                    return Ok(AdmList);
                }
                else
                {
                    return NotFound("The all admintypes not register");
                }
            }
            catch (Exception ex) 
            {
                return BadRequest("Something went wrong...!\n" + "Issue:" + ex.Message + "\n we will solve this issue soon");
            }
            

        }
        [HttpGet]
        [Route("GetAdminTypeById")]

        public async Task<IActionResult> GetAdminTypeById(int AdminTypeId)
        {
            try
            {
               var adm=await AdmRef.GetAdminTypeById(AdminTypeId);
                if (adm != null)
                {
                    return Ok(adm);
                }
                else
                {
                    return NotFound("The AdminType was not found");
                }
            }
            catch (Exception ex) 
            {
                return BadRequest("Something went wrong...!\n" + "Issue:" + ex.Message + "\n we will solve this issue soon");
            }
        }
        [HttpGet]
        [Route("GetAdminTypeByName")]
        public async Task<IActionResult> GetAdminTypeByName(string AdminTypeName)
        {
            try
            {
                var AdmList=await AdmRef.GetAdminTypeByName(AdminTypeName);
                if (AdmList.Count > 0)
                {
                    return Ok(AdmList);
                }
                else
                {
                    return NotFound("The name was not found");
                }
            }
            catch (Exception ex) 
            {
                return BadRequest("Something went wrong...!\n" + "Issue:" + ex.Message + "\n we will solve this issue soon");
            }
        }

        [HttpPost]
        [Route("InsertAdminType")]

        public async Task<IActionResult> InsertAdminType(AdminType Admty)
        {
            try
            {
                var count = await AdmRef.InsertAdminType(Admty);
                if (count > 0)
                {
                    return Ok(count);
                }
                else
                {
                    return NotFound("Record was not inserted");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong...!\n" + "Issue:" + ex.Message + "\n we will solve this issue soon");
            }
        }
        [HttpPut]
        [Route("UpdateAdminType")]
        public async Task<IActionResult> UpdateAdminType(AdminType Admty)
        {
            try
            {
                var count=await AdmRef.UpdateAdminType(Admty);
                if (count > 0)
                {
                    return Ok(count);
                }
                else
                {
                    return NotFound("The record was not updated");
                }

            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong...!\n" + "Issue:" + ex.Message + "\n we will solve this issue soon");
            }
        }

        [HttpDelete]
        [Route("DeleteAdminType")]
        public async Task<IActionResult> DeleteAdminType(int AdminTypeId)
        {
            try
            {
                var count = await AdmRef.DeleteAdminType(AdminTypeId);
                if (count > 0)
                {
                    return Ok(count);
                }
                else
                {
                    return NotFound("The record was not updated");
                }

            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong...!\n" + "Issue:" + ex.Message + "\n we will solve this issue soon");
            }
        }
    }
}

