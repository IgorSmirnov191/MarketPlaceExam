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

        public PictureService(IPictureRepo repo)
        {
            _repo = repo;
        }

        // TODO: Perform mappings using Automapper instead of manually.
        // TODO: CRUD.
        public async Task AddPicture(PictureModel picture)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PictureModel, Picture>());
            var mapper = new Mapper(config);
            var pictureEntity = mapper.Map<PictureModel, Picture>(picture);
            await _repo.AddPicture(pictureEntity);
        }

        public async Task<PictureModel> GetPicture(int id)
        {
            Picture pictureEntity = await _repo.GetPicture(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Picture, PictureModel>());
            var mapper = new Mapper(config);
            var model = mapper.Map<Picture, PictureModel>(pictureEntity);
            return model;
        }
        public async Task UpdatePicture(PictureModel picture)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PictureModel, Picture>());
            var mapper = new Mapper(config);
            var pictureEntity = mapper.Map<PictureModel, Picture>(picture);
            await _repo.UpdatePicture(pictureEntity);
        }

        public async Task DeletePicture(int id)
        {
            await _repo.DeletePicture(id);
        }
    }
}
