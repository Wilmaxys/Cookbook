using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cookbook.Web.Models.Login
{
    public class ApplicationUserModel
    {
        [Range(0, int.MaxValue)]
        public int ApplicationUserId { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(254)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public ApplicationUserModel()
        {

        }

        public ApplicationUserModel(ApplicationUser user)
        {
            if (user == null)
            {
                this.ApplicationUserId = user.ApplicationUserId;
                this.Email = user.Email;
                this.FirstName = user.FirstName;
                this.LastName = user.LastName;
                this.Password = user.Password;
            }

        }
    }
}