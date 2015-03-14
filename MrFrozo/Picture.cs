using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using SQLite;
using Windows.UI.Xaml.Controls;

namespace MrFrozo
{
    class Picture
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [NotNull, Unique]
        public string ImageSource { get; set; }

        [NotNull,Unique]
        public string ImageName { get; set; }
    }
}
