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
    class ClasseRectangle : Classe4Angles
    {
        private int Largeur;
        private int Longueur;

        public Rectangle Dessin()
        {
            Rectangle MonRect = new Rectangle();
            MonRect.Fill = Brushes.Orange;
            MonRect.Width = Longueur * 20;
            MonRect.Height = Largeur * 20;
            MonRect.HorizontalAlignment = HorizontalAlignment.Center;
            MonRect.VerticalAlignment = VerticalAlignment.Center;

            return MonRect;
        }

        public new(int, int) Init()
        {
            Largeur = base.Init();
            System.Threading.Thread.Sleep(10);
            Longueur = base.Init();
            while (Longueur == Largeur)
            {
                System.Threading.Thread.Sleep(10);
                Longueur = base.Init();
            }
            return (Largeur, Longueur);
        }

        public double Perimetre()
        {
            double perimetre = 2 * Largeur + 2 * Longueur;
            return perimetre;
        }

        public double Surface()
        {
            double surface = Longueur * Largeur;
            return surface;
        }
    }
}
