using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public class Group
    {
        public string Name { get; set; }

        public Tutor Tutor { get; set; }

        public Pupil[] Pupil { get; set; }
    }
}
