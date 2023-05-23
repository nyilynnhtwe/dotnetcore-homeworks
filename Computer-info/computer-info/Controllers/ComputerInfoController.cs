using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using computer_info.Models.DAO;
using computer_info.Models;
using computer_info.Models.ViewModel;


namespace SFMS.Controllers
{
    public class ComputerInfoController : Controller
    {
        private readonly ApplicationDBContext _applicationDbcontent;
        //Constructore injection
        public ComputerInfoController(ApplicationDBContext applicationDbContext)
        {
            _applicationDbcontent = applicationDbContext;
        }


        public IActionResult List()
        {
            IList<ComputerInfoViewModel> computerinfos = _applicationDbcontent.ComputerInfos.Select
                      (c => new ComputerInfoViewModel
                      {
                          Id = c.Id,
                          LevelName = c.LevelName,
                          Type = c.Type,
                          Brand = c.Brand,
                          CPU = c.CPU,
                          RAM = c.RAM,
                          StorageSize = c.StorageSize,
                          isActive = c.isActive,
                          isSSD = c.isSSD,
                          CreatedAt = c.CreatedAt,
                          CreatedUserId = c.CreatedUserId,
                          UpdatedAt = c.UpdatedAt,
                          UpdatedUserId = c.UpdatedUserId
                      }).ToList();
            return View(computerinfos);
        }

        [HttpPost]
        public  IActionResult Entry(ComputerInfoViewModel computerInfoViewModel)
        {
            bool isSuccess = false;
            try
            {
               
                //creating the student record 
                ComputerInfo computerinfo = new ComputerInfo();
                //audit columns
                computerinfo.Id = Guid.NewGuid().ToString();
                computerinfo.LevelName = computerInfoViewModel.LevelName;

                computerinfo.Type = computerInfoViewModel.Type ;

                computerinfo.Brand = computerInfoViewModel.Brand;

                computerinfo.CPU = computerInfoViewModel.CPU;


                computerinfo.RAM = computerInfoViewModel.RAM;

                computerinfo.StorageSize = computerInfoViewModel.StorageSize;

                computerinfo.isActive = Convert.ToBoolean(computerInfoViewModel.isActive);

                computerinfo.isSSD = Convert.ToBoolean(computerInfoViewModel.isSSD);

                computerinfo.CreatedAt = DateTime.Now;
                computerinfo.UpdatedAt = DateTime.Now;

                computerinfo.CreatedUserId = Guid.NewGuid().ToString();

                computerinfo.UpdatedUserId = Guid.NewGuid().ToString();
                _applicationDbcontent.ComputerInfos.Add(computerinfo);//Adding the record Students DBSet
                _applicationDbcontent.SaveChanges();//saving the record to the database
                TempData["msg"] = "Saving success for " + computerInfoViewModel.Id + ".";
            }
            catch (Exception ex)
            {

            }
            if (isSuccess)
            {
                ViewBag.msg = "Success";
            }
            else
            {
                ViewBag.msg = "Failed";
            }
            return RedirectToAction("List");
        }


        public IActionResult Entry()
        {
            return View();
        }

        // ko pine yay
        //public IActionResult List()
        //{
        //    // Ask Ko Kyaing why i cant use Where method instead of select method
        //   










        //IList<StudentViewModel> students = _applicationDbcontent.Students.Where(s => s.FatherName == "U Ba").sel; new StudentViewModel
        //{
        //    Address = s.Address,
        //    Name = s.Name
        //}).ToList();
        //    return View(students);



        public IActionResult Delete(string id)
        {
            ComputerInfo computerInfo = _applicationDbcontent.ComputerInfos.Find(id);
            if (computerInfo != null)
            {
                _applicationDbcontent.ComputerInfos.Remove(computerInfo);//remove the  student record from DBSET
                _applicationDbcontent.SaveChanges();//remove effect to the database.
            }
            return RedirectToAction("List");
        }

        public IActionResult Edit(string id)
        {
            ComputerInfoViewModel computerInfoViewModel = _applicationDbcontent.ComputerInfos
                .Where(w => w.Id == id)
                .Select(s => new ComputerInfoViewModel
                {
                    Id = s.Id,
                    LevelName = s.LevelName,
                    Type = s.Type,
                    Brand = s.Brand,
                    CPU = s.CPU,
                    RAM = s.RAM,
                    StorageSize = s.StorageSize,
                    isSSD = s.isSSD,
                    isActive = s.isActive,
                    CreatedUserId = s.CreatedUserId,
                    CreatedAt = s.CreatedAt,
                    UpdatedUserId = s.UpdatedUserId,
                    UpdatedAt = s.UpdatedAt
                }).SingleOrDefault();

         
            return View(computerInfoViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ComputerInfoViewModel computerInfoViewModel)
        {
            bool isSuccess = false;
            try
            {
                ComputerInfo computerinfo = new ComputerInfo();
                //audit columns
                computerinfo.Id = computerInfoViewModel.Id;
                computerinfo.UpdatedAt = DateTime.Now;
                computerinfo.UpdatedUserId = Guid.NewGuid().ToString();
                computerinfo.StorageSize = computerInfoViewModel.StorageSize;
                computerinfo.Type = computerInfoViewModel.Type;
                computerinfo.LevelName = computerInfoViewModel.LevelName;
                computerinfo.Brand = computerInfoViewModel.Brand;
                computerinfo.CPU = computerInfoViewModel.CPU;
                computerinfo.RAM = computerInfoViewModel.RAM;
                computerinfo.isActive = computerInfoViewModel.isActive;
                computerinfo.isSSD = computerInfoViewModel.isSSD;


                _applicationDbcontent.Entry(computerinfo).State = EntityState.Modified;//Updating the existing records in DBSet
                _applicationDbcontent.SaveChanges();//Updating the records to the database
                isSuccess = true;
            }
            catch (Exception ex)
            {

            }
            if (isSuccess)
            {
                TempData["msg"] = "Update Success";
            }
            else
            {
                TempData["msg"] = "Error occur while updating";
            }
            return RedirectToAction("List");
        }

        //finding 
    }
}
