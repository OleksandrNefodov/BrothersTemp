using System.ComponentModel.DataAnnotations.Schema;

namespace Brothers.Common.Models
{
    public class Video : BaseContentEntity
    {
        public Video(string name, ContentType types, int size, string path, int albumId)
        :base(name, types, size)
        {
            Path = path;
            AlbumId = albumId;
        }

        public string Path { get; set; }

        [ForeignKey(nameof(AlbumId))]
        public Album Album { get; set; }
        public int AlbumId { get; set; }
    }
}