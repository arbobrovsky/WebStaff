using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using Data.Entityes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.XWPF.UserModel;
using Presentation;
using Presentation.Model;
using Presentation.Models;
using WebStaff.Helpers;
using WebStaff.Models;

namespace WebStaff.Controllers
{
    public class HomeController : Controller
    {
        private readonly ServicesManager _serviceManager;
        private readonly DataManager _dataManager;
        private readonly IHostingEnvironment _hostEnvironment;
        public HomeController(IHostingEnvironment hostEnvironment, DataManager dataManager)
        {
            _hostEnvironment = hostEnvironment;
            _dataManager = dataManager;
            _serviceManager = new ServicesManager(_dataManager);
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateDecree() => View();

        [HttpPost]
        public async Task<IActionResult> CreateDecree(DecreeViewModel model)
        {
            await _serviceManager.DecreeService.SaveDecree(model);
            return RedirectToAction("GetDecree");
        }

        [HttpGet]
        public async Task<IActionResult> GetDecree()
        {
            var model = await _serviceManager.DecreeService.GetDecreeToList();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateStaff()
        {
            var model = await _serviceManager.Staff.CreateStaff();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStaff(StaffCreateViewModel create)
        {
            if (ModelState.IsValid)
            {
                await _serviceManager.Staff.SaveToDbStaff(create);
            }
            var model = await _serviceManager.Staff.CreateStaff();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> StaffList()
        {
            var model = await _serviceManager.Staff.StaffsList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetStaff(int staffId)
        {
            var model = await _serviceManager.Staff.GetStaffByIdForViewModel(staffId);

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> EditStaff(int staffId)
        {
            var model = await _serviceManager.Staff.GetStaffByIdForViewModel(staffId);

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> EditStaff(StaffViewModel model)
        {
            var staff = await _serviceManager.Staff.GetStaffById(model.StaffId);
            staff.PositionId = model.PositionId;
            staff.SubDepartmenId = model.SubDepartmenId;
            await _serviceManager.Staff.SaveStaffEditToDb(staff);
            return View();
        }

        public bool GetOutStaff(StaffViewModel model)
        {


            return true;
        }

        [HttpGet]
        public IActionResult CreateDepartment()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateSubDepartment()
        {
            var model = await _serviceManager.SubDepartment.CreateSubDepartmentViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSubDepartment(SubDepartmentViewModel model)
        {
            var modelFromDb = await _serviceManager.SubDepartment.CreateSubDepartmentViewModel();
            if (ModelState.IsValid)
            {
                await _serviceManager.SubDepartment.SaveToDbSubDepartment(model);
                return RedirectToAction("GetSubDepartments");
            }
            return View(model);
        }

        [Route("Home/SubDepartmens/{departmentId?}")]
        public async Task<JsonResult> SubDepartmens(int departmentId)
        {
            var result = await _serviceManager.SubDepartment.GetSubDepartmentsLists(departmentId);

            return Json(result);
        }

        [Route("Home/AppointAndTransfer/{StaffId}/{PositionId}/{SubDepartmenId}")]
        [HttpPost]
        public async Task<bool> AppointAndTransfer(string StaffId, string PositionId, string SubDepartmenId)
        {
            var staff = await _serviceManager.Staff.GetStaffById(int.Parse(StaffId));
            staff.PositionId = int.Parse(PositionId);
            staff.SubDepartmenId = int.Parse(SubDepartmenId);
            await _serviceManager.Staff.SaveStaffEditToDb(staff);

            return true;
            // return RedirectToAction("GetStaff", "Home", new { model.StaffId });
        }

        [Route("Home/AppointAndTransferDoc/{StaffId}/{PositionId}/{SubDepartmenId}")]
        [HttpGet]
        public async Task<IActionResult> AppointAndTransferDoc(string StaffId, string PositionId, string SubDepartmenId)
        {
            var document = new DocParse();
            int positionId = int.Parse(PositionId);
            int staffId = int.Parse(StaffId);
            int subDepartmentId = int.Parse(SubDepartmenId);
            var positions = _dataManager.Positiond.GetPositions();
            var staff = await _serviceManager.Staff.GetStaffById(staffId);
            var positionOld = positions.FirstOrDefault(x => x.PositionId == staff.PositionId);
            var subDepartmentOld = await _dataManager.SubDepartment.GetSubDepartmentById(staff.SubDepartmenId);
            staff.Position = new PositionViewModel
            {
                Name = positions.FirstOrDefault(x => x.PositionId == positionId).Name
            };
            var subdepartmentFromDb = await _dataManager.SubDepartment.GetSubDepartmentById(subDepartmentId);
            staff.SubDepartmen = new SubDepartmentViewModel { Name = subdepartmentFromDb.Name };

            MemoryStream bais = new MemoryStream(document.AppointAndTransfer(staff, positionOld, subDepartmentOld).ToArray());
            string file_type = "application/docx";
            string file_name = "prikaz.docx";
            return File(bais, file_type, file_name);

            // return RedirectToAction("GetStaff", "Home", new { model.StaffId });
        }


        [Route("Home/StaffAppoint/{StaffId}/{PositionId}")]
        [HttpPost]
        public async Task<bool> StaffAppoint(string StaffId, string PositionId)
        {
            var staff = await _serviceManager.Staff.GetStaffById(int.Parse(StaffId));
            staff.PositionId = int.Parse(PositionId);
            //  await _serviceManager.Staff.SaveStaffEditToDb(staff);
            return true;
            // return RedirectToAction("GetStaff", "Home", new { model.StaffId });
        }


        [Route("Home/StaffFired/{StaffId}/{HowFired}/{TimeFired}/{DateFired}")]
        [HttpPost]
        public async Task<bool> StaffFired(string StaffId, string HowFired, string TimeFired, string DateFired)
        {
            string day = DateFired.Substring(0, 2);
            string monh = DateFired.Substring(3, 2);
            string year = DateFired.Substring(6, 4);
            string hour = TimeFired.Substring(0, 2);
            string min = TimeFired.Substring(3, 2);
            DateTime date = new DateTime(int.Parse(year), int.Parse(monh), int.Parse(day), int.Parse(hour), int.Parse(min), 0);
            var staff = await _serviceManager.Staff.GetStaffById(int.Parse(StaffId));
            staff.Fired = true;
            staff.HowFired = HowFired;
            staff.HowTimeFired = date;
            await _serviceManager.Staff.SaveStaffEditToDb(staff);
            return true;
            // return RedirectToAction("GetStaff", "Home", new { model.StaffId });
        }

        [HttpGet]
        public IActionResult CreateDocFile() => View();

        //[Route("Home/CreateDocFile/{name}")]
        [HttpPost]
        public async Task<IActionResult> CreateDocFile(string typeDocument)
        {
            switch (typeDocument)
            {
                case ".docx":
                    {
                        var model = await _serviceManager.Staff.StaffsList();
                        int countRecord = model.Count();
                        var document = new DocParse();
                        MemoryStream bais = new MemoryStream(document.CreateTableDoc(model, countRecord).ToArray());
                        string file_type = "application/docx";
                        string file_name = "prikaz.docx";
                        return File(bais, file_type, file_name);
                    }
                case ".xlsx":
                    {
                        var model = await _serviceManager.Staff.StaffsList();
                        int countRecord = model.Count();
                        var document = new XlsxParser();
                        MemoryStream bais = new MemoryStream(document.CreateTableXlsx(model, countRecord).ToArray());
                        string file_type = "application/xlsx";
                        string file_name = "prikaz.xlsx";
                        return File(bais, file_type, file_name);
                    }
            }
            return View();
        }


        public IActionResult CreatePosition()
        {
            return View();
        }

        public async Task<IActionResult> CreatePosition(Position position)
        {
            if (ModelState.IsValid)
            {
                await _dataManager.Positiond.SavePosition(position);
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> CreateRank(Rank rank)
        {
            if (ModelState.IsValid)
            {
                await _dataManager.Rank.SaveRank(rank);
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetSubDepartments()
        {
            var model = await _serviceManager.SubDepartment.SubDepartmentList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _serviceManager.Depatrment.SaveToDb(model);
                return RedirectToAction("getDepartmens");
            }
            return View(model);

        }

        public async Task<IActionResult> GetDepartmens()
        {
            var model = await _serviceManager.Depatrment.DepartmentViewModels();

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
