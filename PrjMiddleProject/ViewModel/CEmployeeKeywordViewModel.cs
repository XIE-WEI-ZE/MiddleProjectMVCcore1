using Microsoft.AspNetCore.Mvc.Rendering;

namespace PrjMiddleProject.ViewModel
{
    public class CEmployeeKeywordViewModel
    {
        public string? txtKeyword { get; set; }
        public string? SelectedDepartment { get; set; }
        public string? SelectedJobTitle { get; set; }
        public List<SelectListItem> DepartmentList { get; set; }
        public List<SelectListItem> JobTitleList { get; set; }
        public List<CEmployeeListViewModel> Employees { get; set; }

    }

}
