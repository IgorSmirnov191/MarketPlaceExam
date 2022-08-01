using MarketPlace.Entities;

namespace MarketPlaceExam.Data.Repos.Interfaces
{
    public interface IPictureRepo
    {
        Task AddPicture(Picture picture);
        Task DeletePicture(int id);
        Task<Picture> GetPicture(int id);
        Task<IEnumerable<Picture>> GetPictures();
        Task UpdatePicture(Picture picture);
    }
}