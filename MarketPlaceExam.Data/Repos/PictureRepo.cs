using AutoMapper;
using MarketPlaceExam.Data.Entities;
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
            if (picture != null)
            {
                _context.Pictures.Update(picture);
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
        public bool IsPicturesEmpty()
        {
           return _context.Pictures.Any();
        } 
    }
}
