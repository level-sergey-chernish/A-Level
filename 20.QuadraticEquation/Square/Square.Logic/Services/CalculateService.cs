using Square.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square.Logic.Services
{
    public interface ICalculateService
    {
        void Calculate(Input model);
    }

    public class CalculateService: ICalculateService
    {
        public void Calculate(Input model)
        {
            model.X = new List<double> { };

            if (model.A == 0)
            {
                model.Notify = "Coefficient A can't be 0";
            }
            else
            {
                model.D = Math.Pow(model.B, 2) - 4 * model.A * model.C;

                if (model.D < 0)
                {
                    model.Notify = "Quadratic equation doesn't has roots";
                }

                if (model.D == 0)
                {
                    model.X.Add((-model.B + Math.Sqrt(model.D)) / 2 * model.A);
                    model.Notify = "Quadratic equation has one root";
                }

                if (model.D > 0)
                {
                    model.X.Add((-model.B + Math.Sqrt(model.D)) / 2 * model.A);
                    model.X.Add((-model.B - Math.Sqrt(model.D)) / 2 * model.A);
                    model.Notify = "Quadratic equation has two roots";
                }
            }
        }
     }
}
