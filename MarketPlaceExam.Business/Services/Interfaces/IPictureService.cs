using MarketPlaceExam.Business.Model;

namespace MarketPlaceExam.Business.Services.Interfaces
{
    public interface IPictureService
    {
        Task AddPicture(PictureModel picture);
        Task DeletePicture(int id);
        Task<PictureModel> GetPicture(int id);
        Task UpdatePicture(PictureModel picture);
        bool IsPicturesEmpty();
    }
}