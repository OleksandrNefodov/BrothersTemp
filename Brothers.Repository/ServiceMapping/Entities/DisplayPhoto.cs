using Brothers.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Brothers.Repository.ServiceMapping.Entities
{
    public class DisplayPhoto
    {
        public DisplayPhoto()
        {
        }

        public DisplayPhoto(Photo photo)
        {
            Identifier = photo.Id;
            Name = photo.Name;
            Type = photo.Type;
            AlbumId = photo.AlbumId;
            Size = photo.Size;
            RawData = photo.RawData;
        }

        public int Identifier { get; set; }

        [Required(ErrorMessage = "Name is required field.")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Name lenth must be in range from 3 to 10 characters.")]
        [Display(Name = "Photo Name")]
        public string Name { get; set; }

        [Display(Name = "Photo Type")]
        public ContentType Type { get; set; }

        public int AlbumId { get; set; }

        [Display(Name = "Photo Size")]
        public int Size { get; set; }

        public byte[] RawData { get; set; }
    }
}