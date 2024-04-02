using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services {
    public class DepartmentService {

        private readonly SalesWebMvcContext _context;

        public DepartmentService(SalesWebMvcContext _context) {
            this._context = _context;
        }

        public List<Department> FindAll() {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
