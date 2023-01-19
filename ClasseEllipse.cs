using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Geometrie
{
    class ClasseEllipse : ClasseRond
    {
        private int rayonUn;
        private int rayonDeux;
        public Ellipse Dessin()
        {
            Ellipse MonElli = new Ellipse();
            MonElli.Fill = Brushes.Green;
            MonElli.StrokeThickness = 2;
            MonElli.Width = rayonDeux * 20;
            MonElli.Height = rayonUn * 20;

            return MonElli;
        }

        public new(int, int) Init()
        {
            rayonUn = base.Init();
            System.Threading.Thread.Sleep(10);
            rayonDeux = base.Init();
            while (rayonUn == rayonDeux)
            {
                System.Threading.Thread.Sleep(10);
                rayonDeux = base.Init();
            }
            return (rayonUn, rayonDeux);
        }

        public double Surface()
        {
            double surface = rayonUn * rayonDeux * Math.PI;
            return Math.Round(surface, 2);
        }
    }
}
