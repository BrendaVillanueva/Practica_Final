using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Practica_Final.Droid;
using System.IO;

[assembly: Dependency(typeof(ISQLite_Droid))]

namespace Practica_Final.Droid
{
   public class ISQLite_Droid: ISQLite
    {
        public String GetLocalFilePath(string Filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, Filename);

        }

    }
}