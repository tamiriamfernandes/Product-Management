using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Models.Product
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public string Description { get; set; }
        public DateTime DateFabrication { get; set; }
        public DateTime DateValidity { get; set; }
        public int IdProvider { get; set; }
        public string DescriptionProvider { get; set; }
        public string DocumentProvider { get; set; }
    }
}
