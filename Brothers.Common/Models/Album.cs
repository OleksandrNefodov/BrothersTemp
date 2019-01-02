using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brothers.Common.Models
{
    public class Album : BaseDbEntity
    {
        public string Name { get; set; }

        public AlbumType Type { get; set; }

        public Album()
        {
        }

        public Album(string name, AlbumType type)
        {
            Name = name;
            Type = type;
        }
    }
}