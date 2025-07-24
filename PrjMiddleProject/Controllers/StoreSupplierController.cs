using Microsoft.AspNetCore.Mvc;
using PrjMiddleProject.Models;
using PrjMiddleProject.ViewModel;

namespace PrjMiddleProject.Controllers
{
    public class StoreSupplierController : Controller
    {
        public IActionResult StoreSupplierIndex(CStoreSupplierKeywordViewModel vm)
        {
            NursingHomeContext nh = new NursingHomeContext();
            IEnumerable<StoreSupplier> datas = null;

            if (string.IsNullOrEmpty(vm.txtKeyword))
                datas = from s in nh.StoreSuppliers
                        select s;
            else
                datas = nh.StoreSuppliers.Where(d => d.SupplierName.Contains(vm.txtKeyword) || d.SupplierGui.Contains(vm.txtKeyword) || d.Contact.Contains(vm.txtKeyword) || d.ContactNumber.Contains(vm.txtKeyword) || d.Address.Contains(vm.txtKeyword));

                return View(datas);
        }
        // 新增
        public IActionResult StoreSupplierCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult StoreSupplierCreate(StoreSupplier s)
        {
            NursingHomeContext nh = new NursingHomeContext();
            nh.StoreSuppliers.Add(s);
            nh.SaveChanges();
            return RedirectToAction("StoreSupplierIndex");
        }

        // 删除
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("StoreSupplierIndex");

            NursingHomeContext nh = new NursingHomeContext();
            StoreSupplier x = nh.StoreSuppliers.FirstOrDefault(p => p.SupplierId == id);
            if (x == null)
                return RedirectToAction("StoreSupplierIndex");

            nh.StoreSuppliers.Remove(x);
            nh.SaveChanges();
            return RedirectToAction("StoreSupplierIndex");
        }

        // 修改
        public IActionResult StoreSupplierEdit(int? id)
        {
            if (id == null)
                return RedirectToAction("StoreSupplierIndex");

            NursingHomeContext nh = new NursingHomeContext();
            StoreSupplier x = nh.StoreSuppliers.FirstOrDefault(p => p.SupplierId == id);
            if (x == null)
                return RedirectToAction("StoreSupplierIndex");

            return View(x);
        }
        [HttpPost]
        public IActionResult StoreSupplierEdit(StoreSupplier uiSup)
        {
            NursingHomeContext nh = new NursingHomeContext();
            StoreSupplier nhSup = nh.StoreSuppliers.FirstOrDefault(p => p.SupplierId == uiSup.SupplierId);
            if (nhSup == null)
                return RedirectToAction("StoreSupplierIndex");

            nhSup.SupplierName = uiSup.SupplierName;
            nhSup.SupplierGui = uiSup.SupplierGui;
            nhSup.Contact = uiSup.Contact;
            nhSup.ContactNumber = uiSup.ContactNumber;
            nhSup.Address = uiSup.Address;

            nh.SaveChanges();
            return RedirectToAction("StoreSupplierIndex");
        }
    }
}
