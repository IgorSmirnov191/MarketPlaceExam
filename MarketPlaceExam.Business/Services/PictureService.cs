using AutoMapper;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Business.Services.Interfaces;
using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;
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
        public PictureService(IPictureRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task AddPicture(PictureModel picture)
        {
            var pictureEntity = _mapper.Map<PictureModel, Picture>(picture);
            await _repo.AddPicture(pictureEntity);
        }

        public async Task<PictureModel> GetPicture(int id)
        {
            Picture pictureEntity = await _repo.GetPicture(id);
            var model = _mapper.Map<Picture, PictureModel>(pictureEntity);
            return model;
        }
        public async Task UpdatePicture(PictureModel picture)
        {
            var pictureEntity = _mapper.Map<PictureModel, Picture>(picture);
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
    }
}
