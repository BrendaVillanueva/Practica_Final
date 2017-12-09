using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using Practica_Final.UWP;
using Windows.Storage;

[assembly: Dependency(typeof(ISQLite_UWP))]

namespace Practica_Final.UWP
{
   public class ISQLite_UWP: ISQLite
    {

            public String GetLocalFilePath(string Filename)
            {
                return Path.Combine(ApplicationData.Current.LocalFolder.Path, Filename);
            }
        }
}
