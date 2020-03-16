using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketPresentationLayer.Models
{
    public class CategoryInsertViewModel
    {
        [Required(ErrorMessage ="O nome deve ser informado")]
        [StringLength(maximumLength:30, ErrorMessage ="O nome deve conter entre 2 e 30 caracteres", MinimumLength =2)]
        public string Name { get; set; }
    }
}
