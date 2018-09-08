using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CockroachRun.Classes;

namespace CockroachRun
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> RunnerAppearence = new List<char> { 'Ñ', 'ú', 'ñ', '¿' };

            List<Cockroach> Cockroaches = new List<Cockroach>();

            for (var i = 0; i < RunnerAppearence.Count; i++)
            {
                var cockroach = new Cockroach(RunnerAppearence.ElementAt(i));

                Cockroaches.Add(cockroach);


                new Task(() =>
                {
                    Cockroaches.ElementAt(i).Race(i, GameFuncs.Distance, Cockroaches.ElementAt(i).Appearence);
                }).Start();
                
            }
            
            Task.WaitAll();

        }
    }
}


//using System.Threading.Tasks;
//The most direct way

//Task.Factory.StartNew(() => {Console.WriteLine("Hello Task library!"); });
//Using Action


//Task task = new Task(new Action(PrintMessage));
//task.Start();
//…where PrintMessage is a method:


//private void PrintMessage()
//{
//    Console.WriteLine("Hello Task library!");
//}
//Using a delegate


//Task task = new Task(delegate { PrintMessage(); });
//task.Start();
//Lambda and named method


//Task task = new Task(() => PrintMessage());
//task.Start();
//Lambda and anonymous method


//Task task = new Task(() => { PrintMessage(); });
//task.Start();
//Using Task.Run in .NET4.5


//public async Task DoWork()
//{
//    await Task.Run(() => PrintMessage());
//}
//Using Task.FromResult in .NET4.5 to return a result from a Task


//public async Task DoWork()
//{
//    int res = await Task.FromResult<int>(GetSum(4, 5));
//}

//private int GetSum(int a, int b)
//{
//    return a + b;
//}

