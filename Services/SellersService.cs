using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services {
    public class SellersService {

        private readonly SalesWebMvcContext _context;

        public SellersService(SalesWebMvcContext _context) {
            this._context = _context;
        }

        public List<Seller> FindAll() {
            return _context.Seller.ToList();
        }
    }
}
