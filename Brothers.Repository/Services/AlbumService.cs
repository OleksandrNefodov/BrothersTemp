using Brothers.Common.Models;
using Brothers.Common.Models.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Brothers.Repository.PhotoService
{
    public class AlbumService
    {
        public static async Task<List<Album>> ListAlbumsAsync()
        {
            using (var dbContext = new BrothersContext())
            {
                var albums = await dbContext.Albums.ToListAsync();

                return albums;
            }
        }

    }
}