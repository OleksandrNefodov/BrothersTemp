using Brothers.Common.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Brothers.Common.Models.Context;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using Brothers.Repository.ServiceMapping.Entities;

namespace Brothers.Repository.PhotoService
{
    public static class PhotoService
    {
        public static async Task<List<DisplayPhoto>> ListPhotosAsync()
        {
            using (var dbContext = new BrothersContext())
            {
                var photos = await dbContext
                    .Photos
                    .Select(photo => new DisplayPhoto
                        {
                            Identifier = photo.Id,
                            Size = photo.Size,
                            Name = photo.Name,
                            Type = photo.Type,
                            AlbumId = photo.AlbumId
                        })
                    .ToListAsync();

                return photos;
            }
        }

        public static async Task<bool> DeleteAsync(int id)
        {
            using (var dbcontext = new BrothersContext())
            {
                Photo photo = await dbcontext
                    .Photos
                    .Where(item => item.Id == id)
                    .SingleOrDefaultAsync();

                if (photo == null)
                {
                    return false;
                }

                dbcontext.Photos.Remove(photo);

                await dbcontext.SaveChangesAsync();

                return true;
            }
        }

        public static async Task<Photo> GetAsync(int id)
        {
            using (var context = new BrothersContext())
            {
                var photo = await context.Photos.FindAsync(id);
                if (photo != null)
                {
                    return photo;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public static async Task AddAsync(Photo photo)
        {
            using (var context = new BrothersContext())
            {
                if (photo.Id != 0)
                {
                    context.Photos.Attach(photo);
                    var manager = ((IObjectContextAdapter)context).ObjectContext.ObjectStateManager;
                    manager.ChangeObjectState(photo, EntityState.Modified);
                }
                else
                {
                    context.Photos.Add(photo);
                }

                await context.SaveChangesAsync();
            }
        }
    }
}