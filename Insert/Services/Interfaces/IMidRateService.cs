using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Insert.Dtos;
using Insert.Models;

namespace Insert.Services.Interfaces
{
    public interface IMidRateService
    {
        MidRateTableModel GetMidRates(TableType tableType);
    }
}
