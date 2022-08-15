using AutoMapper;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Business.Services.Interfaces;
using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceExam.Business.Services
{
    public class PictureService : IPictureService
    {
        // Dependencies
        private IPictureRepo _repo;
        private IMapper _mapper;
        private IProductService _productService;
        public PictureService(IPictureRepo repo, IMapper mapper, IProductService productService)
        {
            _repo = repo;
            _mapper = mapper;
            _productService = productService;
        }
        public async Task AddPicture(PictureModel picture)
        {
            Picture pictureEntity = _mapper.Map<PictureModel, Picture>(picture);
            await _repo.AddPicture(pictureEntity);
        }

        public async Task<PictureModel> GetPicture(int id)
        {
            Picture pictureEntity = await _repo.GetPicture(id);
            PictureModel model = _mapper.Map<Picture, PictureModel>(pictureEntity);
            return model;
        }
        public async Task UpdatePicture(PictureModel picture)
        {
            Picture pictureEntity = _mapper.Map<PictureModel, Picture>(picture);
            await _repo.UpdatePicture(pictureEntity);
        }

        public async Task DeletePicture(int id)
        {
            await _repo.DeletePicture(id);
        }

        public bool IsPicturesEmpty()
        {
            return _repo.IsPicturesEmpty();
        }

        public async Task<string> SavePicture(int productId, IFormFile picture, string path)
        {
           
            return await _repo.SavePicture(productId,picture,path);
        }
    }
}
