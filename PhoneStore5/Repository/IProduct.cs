using PhoneStore5.Models;

namespace PhoneStore5.Repository
{
    public interface IProduct
    {
        Task Insert(PhoneProduct model);
        Task<PhoneProduct> GetById(int Id);
        Task<PhoneProduct> Search(int Id);
        Task<List<PhoneProduct>> GetAll();
        Task Delete(int Id);
        Task Update(PhoneProduct phoneProduct);
    }
}
