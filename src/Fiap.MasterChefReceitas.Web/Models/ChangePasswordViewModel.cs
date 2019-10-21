using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.MasterChefReceitas.Web.Models
{
    public class ChangePasswordViewModel
    {
        [Display(Name = "Usuario")]
        public string User { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password atual")]
        public string PasswordOld { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirma Password")]
        [Compare("Password")]
        public string ConfirmePassword { get; set; }
    }
}
