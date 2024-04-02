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

        public void Insert(Seller seller) {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public Seller FindById(int id) {
            return _context.Seller.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id) {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }    
    }
}
