using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Models.Product
{
    public class ReadProductDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Active { get; private set; }
        public DateTime DateFabrication { get; set; }
        public DateTime DateValidity { get; set; }
        public int IdProvider { get; set; }
        public string DescriptionProvider { get; set; }
        public string DocumentProvider { get; set; }
    }
}
