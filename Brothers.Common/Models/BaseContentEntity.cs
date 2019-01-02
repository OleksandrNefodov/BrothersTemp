/// <summary>
/// Photo and Video
/// </summary>

namespace Brothers.Common.Models
{
    public class BaseContentEntity : BaseDbEntity
    {
        public BaseContentEntity()
        {
        }

        public BaseContentEntity(string name, ContentType type, int size)
        :base()
        {
            Name = name;
            Type = type;
            Size = size;
        }

        public string Name { get; set; }

        public ContentType Type { get; set; }

        public int Size { get; set; }

    }
}