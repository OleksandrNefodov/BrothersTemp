using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Brothers.Common.Models;

namespace Brothers.Repository.ServiceMapping
{
    public static class Transformations
    {
        public static ContentType ContentTypeToPhoto(string type)
        {
            switch (type)
            {
                case "Home":
                    return ContentType.Home;
                case "Fishing":
                    return ContentType.Fishing;
                case "Travel":
                    return ContentType.Travel;
                case "CountryHouse":
                    return ContentType.CountryHouse;
                default:
                    return ContentType.Others;
            }
        }

        public static AlbumType AlbumTypeToPhoto(string albumType)
        {
            switch (albumType)
            {
                case "Autumn":
                    return AlbumType.Autumn;
                case "Spring":
                    return AlbumType.Spring;
                case "Summer":
                    return AlbumType.Summer;
                default:
                    return AlbumType.Winter;
            }
        }
    }
}