using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Practica_Final
{
   public interface ISQLite
    {
        String GetLocalFilePath(string filename);
    }
}
