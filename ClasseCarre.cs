using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Geometrie
{
    class ClasseCarre : Classe4Angles
    {
        private int Cote;

        public Rectangle Dessin()
        {
            Rectangle MonRect = new Rectangle();
            MonRect.Fill = Brushes.Red;
            MonRect.Width = Cote * 30;
            MonRect.Height = Cote * 30;
            MonRect.Stretch = Stretch.Fill;
            MonRect.StrokeThickness = 1;

            return MonRect;
        }

        public new int Init()
        {
            Cote = base.Init();
            return Cote;
        }

        public double Perimetre()
        {
            double perimetre = Cote * 4;
            return perimetre;
        }

        public double Surface()
        {
            double surface = Math.Pow(Cote, 2);
            return surface;
        }
    }
}
