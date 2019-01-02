using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using Brothers.Common.Models;
using Brothers.Common.Models.Context;

namespace Brothers.Common.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Brothers.Common.Models.Context.BrothersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Brothers.Common.Models.Context.BrothersContext";
        }

        protected override void Seed(BrothersContext context)
        {
            Album album = new Album("Albomchik", AlbumType.Autumn);

            context.Albums.Add(album);

            List<Photo> Photos = new List<Photo>
            {
                new Photo("Photo1", ContentType.Fishing, 23, new byte[0], album.Id),
                new Photo("Photo2", ContentType.CountryHouse, 23, new byte[0], album.Id)
            };

            context.Photos.AddRange(Photos);

            List<Video> Videos = new List<Video>
            {
                new Video("Video1", ContentType.Travel, 12, "", album.Id),
                new Video("Video2", ContentType.Others, 12, "", album.Id)
            };

            context.Videos.AddRange(Videos);

            base.Seed(context);
        }
    }
}
