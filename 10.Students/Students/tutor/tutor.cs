using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public class Tutor
    {
        public string Name { get; set; }
        public Degree Degree;
    }

    public enum Degree
    {
        Professor,
        Docent,
        Assistant
    }
}
