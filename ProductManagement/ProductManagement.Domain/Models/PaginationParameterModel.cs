using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Models
{
    public record PaginationParameterModel(int limit = 5, int page = 1);
}
