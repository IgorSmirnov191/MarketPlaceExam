using AutoMapper;
using MarketPlace.Entities;
using MarketPlace.MVC.Data;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceExam.Data.Repos
{
    public class PictureRepo : IPictureRepo
    {
        private ApplicationDbContext _context;

        public PictureRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddPicture(Picture picture)
        {
            if (picture != null)
            {
                await _context.Pictures.AddAsync(picture);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Picture>> GetPictures()
        {
            return await _context.Pictures.ToListAsync();
        }

        public async Task<Picture> GetPicture(int id)
        {
            return await _context.Pictures.FindAsync(id);
        }

        public async Task UpdatePicture(Picture picture)
        {
            var piclocal = await _context.Pictures.FindAsync(picture.Id);
            if (piclocal != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Picture, Picture>());
                var mapper = new Mapper(config);
                piclocal = mapper.Map<Picture>(picture);
                _context.SaveChanges();

            }
        }

        public async Task DeletePicture(int id)
        {
            var piclocal = await _context.Pictures.FindAsync(id);
            if (piclocal != null)
            {
                _context.Pictures.Remove(piclocal);
                _context.SaveChanges();
            }
        }
    }
}
