using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolproject.Model
{
    public class Kha_course
    {
        public int id { get; set; }
        public string name { get; set; }
        public int points { get; set; }
        public DateFormat start_date { get; set; }
        public DateFormat end_date { get; set; }
    }
}
