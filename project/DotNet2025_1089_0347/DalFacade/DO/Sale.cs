using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record Sale
        (
        int? ProductId,
        int? Amount,
        double? TotalPrice,
        bool? ForClubCustomers,
        DateOnly? SaleStartDate,
        DateOnly? SaleEndDate,
        int Id
        )
    {
        public Sale() : this(0, 0, 0, false, null, null, 0)
        {

        }

    }
}