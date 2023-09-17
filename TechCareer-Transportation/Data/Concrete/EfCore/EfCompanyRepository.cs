using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Entity;

namespace BlogApp.Data.Concrete
{
    public class EfCompanyRepository:ICompanyRepository  
    {
        private TransportContext _context;
        public EfCompanyRepository(TransportContext context)
        {
            _context = context;
        }

        public IQueryable<Company> Companies => _context.Companies;

        public void CreateCompany(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
        }
    }
}