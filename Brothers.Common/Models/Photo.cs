using System.ComponentModel.DataAnnotations.Schema;

namespace Brothers.Common.Models
{
    public class Photo : BaseContentEntity
    {
        public Photo()
        {
        }

        public Photo(string name, ContentType types, int size, byte[] rawData, int albumId)
        : base(name, types, size)
        {
            RawData = rawData;
            AlbumId = albumId;
        }

        public byte[] RawData { get; set; }

        [ForeignKey(nameof(AlbumId))]
        public Album Album { get; set; }
        public int AlbumId { get; set; } 
    }
}