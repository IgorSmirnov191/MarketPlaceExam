using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace MarketPlaceExam.Business.Services.Interfaces
{
    public interface IPictureService
    {
        Task AddPicture(PictureModel picture);
        Task<string> SavePicture(int productId, IFormFile picture, string path);
        Task DeletePicture(int id);
        Task<PictureModel> GetPicture(int id);
        Task UpdatePicture(PictureModel picture);
        bool IsPicturesEmpty();
    }
}