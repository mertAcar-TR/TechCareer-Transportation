using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface ICompanyRepository
    {
        IQueryable<Company> Companies { get; }
        void CreateCompany(Company company);
    }
}