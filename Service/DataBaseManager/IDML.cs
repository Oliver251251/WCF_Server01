using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Models;

namespace Service.DataBaseManager
{
    internal interface IDML
    {
        string Insert(Record record);
        string Update(Record record);
        string Delete(int Id);
    }
}
