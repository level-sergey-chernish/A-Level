using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            Group[] groups = new Group[3];

            for (var i = 0; i < groups.Length; i++)
            {
                groups[i] = new Group();
            }

            groups[0].Name = "Group 301";
            groups[0].Tutor = new Tutor();
            groups[0].Tutor.Name = "Ivanov Ivan Ivanovich";
            groups[0].Tutor.Degree = Degree.Professor;
            groups[0].Pupil = new Pupil[3];
            for (var i = 0; i < groups[0].Pupil.Length; i++)
            {
                groups[0].Pupil[i] = new Pupil();
            }
            groups[0].Pupil[0].Name = "Vasya Petrov";
            groups[0].Pupil[1].Name = "Fedya Vasilyev";
            groups[0].Pupil[2].Name = "Olya Pupkova";



            groups[1].Name = "Group 302";
            groups[1].Tutor = new Tutor();
            groups[1].Tutor.Name = "Perov Petr Petrovich";
            groups[1].Tutor.Degree = Degree.Docent;
            groups[1].Pupil = new Pupil[2];
            for (var i = 0; i < groups[1].Pupil.Length; i++)
            {
                groups[1].Pupil[i] = new Pupil();
            }
            groups[1].Pupil[0].Name = "Vasya Petrov";
            groups[1].Pupil[1].Name = "Fedya Vasilyev";

            groups[2].Name = "Group 303";
            groups[2].Tutor = new Tutor();
            groups[2].Tutor.Name = "Sidorov Sidor Sidorovich";
            groups[2].Tutor.Degree = Degree.Assistant;
            groups[2].Pupil = new Pupil[1];
            for (var i = 0; i < groups[2].Pupil.Length; i++)
            {
                groups[2].Pupil[i] = new Pupil();
            }
            groups[2].Pupil[0].Name = "Vasya Petrov";



            for (var i = 0; i < groups.Length; i++)
            {
                Console.WriteLine($"Group name:{groups[i].Name}");
                Console.WriteLine($"Group tutor:{groups[i].Tutor.Degree} {groups[i].Tutor.Name}");
                Console.WriteLine($"Group students:");
                for (var j = 0; j < groups[i].Pupil.Length; j++)
                {
                    Console.WriteLine(groups[i].Pupil[j].Name);
                }
                Console.WriteLine("_________________");
                Console.WriteLine();
            }
        }
    }
}
