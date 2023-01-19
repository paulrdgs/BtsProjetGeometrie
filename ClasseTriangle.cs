using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Geometrie
{
    class ClasseTriangle : ClasseAvecAngle
    {
        private int C1;
        private int C2;
        private double Haut;

        public Polygon Dessin()
        {
            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(new Point(1, 1));
            myPointCollection.Add(new Point(0, 1));
            myPointCollection.Add(new Point(0, 0));

            Polygon myPolygon = new Polygon();
            myPolygon.Points = myPointCollection;
            myPolygon.Fill = Brushes.Purple;
            myPolygon.Width = C1 * 30;
            myPolygon.Height = C2 * 30;
            myPolygon.Stretch = Stretch.Fill;

            return myPolygon;
        }

        public new(int, int, double) Init()
        {
            C1 = base.Init();
            System.Threading.Thread.Sleep(10);
            C2 = base.Init();
            Haut = Math.Round(Math.Sqrt((C1 * C1) + (C2 * C2)), 2);
            return (C1, C2, Haut);
        }

        public double Perimetre()
        {
            double peri = C1 + C2 + Haut;
            return Math.Round(peri, 2);
        }

        public double Surface()
        {
            double surf = C1 * C2;
            surf = surf / 2;
            return Math.Round(surf, 2);
        }
    }
}
