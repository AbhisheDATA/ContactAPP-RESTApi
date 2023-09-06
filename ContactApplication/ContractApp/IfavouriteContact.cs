using ContactApplication.Entities;
using ContactApplication.Model;
namespace ContactApplication.ContractApp
{
    public interface IfavouriteContact
    {
        Task AddToFavouriteList( int id);
        Task<FavouriteContact> GetFavrtContactById(int id);
        Task<List<FavouriteContact>> GetAllFavouriteContact();
        Task<List<FavouriteContact>> GetFvrtContactByName(string name);
        Task DeleteFvrtContactAsync(int id);
    }
}
