using ContactApplication_.Entities;
using ContactApplication_.Model;
namespace ContactApplication_.contactContract
{
    public interface IFavouriteContact
    {
        Task AddToFavouriteList(int id);
        Task<FavouriteContact> GetFavrtContactById(int id);
        Task<List<FavouriteContact>> GetAllFavouriteContact();
        Task<List<FavouriteContact>> GetFvrtContactByName(string name);
        Task DeleteFvrtContactAsync(int id);
    }
}