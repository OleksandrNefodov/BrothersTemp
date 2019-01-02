using System.ComponentModel.DataAnnotations;

namespace Brothers.Repository.ServiceMapping.Entities
{
    public class UserModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }


    }

}