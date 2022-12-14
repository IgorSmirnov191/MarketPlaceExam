using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using MarketPlaceExam.Data.Data;
using Microsoft.AspNetCore.Http;

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
            Picture? piclocal = await _context.Pictures.FindAsync(id);
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

        public async Task<string> SavePicture(int productId, IFormFile picture, string defaultpath)
        {
            var product = await _context.Products.FindAsync(productId);

            var path = defaultpath + $"{DateTime.Now.Year}-{picture.FileName}";
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await picture.CopyToAsync(stream);
            }

            path = path.Replace("wwwroot", "");
            return path;
        }
    }
}
