using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Geometrie
{
    class ClasseCercle : ClasseRond
    {
        private int rayon;
        public Ellipse Dessin()
        {
            Ellipse MonCircle = new Ellipse();
            MonCircle.Fill = Brushes.Yellow;
            MonCircle.StrokeThickness = 2;
            MonCircle.Width = rayon * 30;
            MonCircle.Height = rayon * 30;

            return MonCircle;
        }

        public new int Init()
        {
            rayon = base.Init();
            return rayon;
        }

        public double Perimetre()
        {
            double perimetre = 2 * Math.PI * rayon;
            return Math.Round(perimetre, 2);
        }

        public double Surface()
        {
            double surface = Math.PI * Math.Pow(rayon, 2);
            return Math.Round(surface, 2);
        }
    }
}
