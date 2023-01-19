using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Geometrie
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        int Pourcentage;
        int NbrQuestion = 0;
        int NbrBonneRep = 0;
        string message = "";
        double perimetre;
        double surface;
        int idQuest;
        public MainWindow()
        {
            InitializeComponent();
            Btn_ValideRep.IsEnabled = false;

            // Affiche le triangle du début
            PointCollection MesPoints = new PointCollection();
            MesPoints.Add(new Point(1, 1));
            MesPoints.Add(new Point(0, 1));
            MesPoints.Add(new Point(0, 0));

            Polygon MonTriangle = new Polygon();
            MonTriangle.Points = MesPoints;
            MonTriangle.Fill = Brushes.Purple;
            MonTriangle.Width = 5 * 30;
            MonTriangle.Height = 3 * 30;
            MonTriangle.Stretch = Stretch.Fill;
            CnvTriangle.Children.Clear();
            CnvTriangle.Children.Add(MonTriangle);

            // Affiche le rectangle du début
            Rectangle MonRectangle = new Rectangle();
            MonRectangle.Fill = Brushes.Orange;
            MonRectangle.Width = 7 * 20;
            MonRectangle.Height = 4 * 20;
            MonRectangle.HorizontalAlignment = HorizontalAlignment.Center;
            MonRectangle.VerticalAlignment = VerticalAlignment.Center;
            CnvRectangle.Children.Clear();
            CnvRectangle.Children.Add(MonRectangle);

            // Affiche Carre du début
            Rectangle MonCarre = new Rectangle();
            MonCarre.Fill = Brushes.Red;
            MonCarre.Width = 4 * 30;
            MonCarre.Height = 4 * 30;
            MonCarre.Stretch = Stretch.Fill;
            MonCarre.StrokeThickness = 1;
            CnvCarre.Children.Clear();
            CnvCarre.Children.Add(MonCarre);

            // Affiche ellipse du début
            Ellipse MonEllipse = new Ellipse();
            MonEllipse.Fill = Brushes.Green;
            MonEllipse.StrokeThickness = 2;
            MonEllipse.Width = 7 * 20;
            MonEllipse.Height = 5 * 20;
            CnvEllipse.Children.Clear();
            CnvEllipse.Children.Add(MonEllipse);

            // Affiche Cercle du début
            Ellipse MonCercle = new Ellipse();
            MonCercle.Fill = Brushes.Yellow;
            MonCercle.StrokeThickness = 2;
            MonCercle.Width = 4 * 30;
            MonCercle.Height = 4 * 30;
            CnvCercle.Children.Clear();
            CnvCercle.Children.Add(MonCercle);

        }

        private void BtnTriangle_Click(object sender, RoutedEventArgs e)
        {
            Apparition(1);
            Lbl_Titre.Content = "S'amuser avec les maths : Le Triangle";
        }

        private void BtnRectangle_Click(object sender, RoutedEventArgs e)
        {
            Apparition(2);
            Lbl_Titre.Content = "S'amuser avec les maths : Le Rectangle";
        }

        private void BtnCarre_Click(object sender, RoutedEventArgs e)
        {
            Apparition(3);
            Lbl_Titre.Content = "S'amuser avec les maths : Le Carré";
        }

        private void BtnEllipse_Click(object sender, RoutedEventArgs e)
        {
            Apparition(4);
            Lbl_Titre.Content = "S'amuser avec les maths : L'Ellipse";
        }

        private void BtnCercle_Click(object sender, RoutedEventArgs e)
        {
            Apparition(5);
            Lbl_Titre.Content = "S'amuser avec les maths : Le Cercle";
        }

        public void Apparition(int id)
        {
            idQuest = id;
            BtnTriangle.Visibility = Visibility.Hidden;
            BtnRectangle.Visibility = Visibility.Hidden;
            BtnCarre.Visibility = Visibility.Hidden;
            BtnEllipse.Visibility = Visibility.Hidden;
            BtnCercle.Visibility = Visibility.Hidden;
            LblAccueil.Visibility = Visibility.Hidden;
            Btn_Back.Visibility = Visibility.Visible;
            Btn_New.Visibility = Visibility.Visible;
            TheCanvas.Visibility = Visibility.Visible;
            Txb_QuestionUn.Visibility = Visibility.Visible;
            Lbl_DemandeUn.Visibility = Visibility.Visible;
            Txb_RepUn.Visibility = Visibility.Visible;
            Txb_QuestionDeux.Visibility = Visibility.Visible;
            Lbl_DemandeDeux.Visibility = Visibility.Visible;
            Txb_RepDeux.Visibility = Visibility.Visible;
            Btn_ValideRep.Visibility = Visibility.Visible;
            Txb_RepUn.Focus();
            switch (id)
            {
                case 1:
                    CreationTriangle();
                    break;
                case 2:
                    CreationRectangle();
                    break;
                case 3:
                    CreationCarre();
                    break;
                case 4:
                    CreationEllipse();
                    break;
                case 5:
                    CreationCercle();
                    break;
                default:
                    break;
            }
        }

        public void CreationTriangle()
        {
            ClasseTriangle triangle = new ClasseTriangle();
            var cotes = triangle.Init();
            perimetre = triangle.Perimetre();
            surface = triangle.Surface();
            string q1 = "Quelle est la valeur du périmètre sachant que la base vaut " + cotes.Item1 + ", la hauteur vaut " + cotes.Item2 + " et l'hypothénuse vaut " + cotes.Item3 + " ?";
            string q2 = "Quelle est la valeur de la surface sachant que la base vaut " + cotes.Item1 + " et la hauteur vaut " + cotes.Item2 + " ?";
            QuestionAffiche(q1, q2);
            Polygon cnvtriangle = triangle.Dessin();
            TheCanvas.Children.Clear();
            TheCanvas.Children.Add(cnvtriangle);
        }

        public void CreationRectangle()
        {
            ClasseRectangle rectangle = new ClasseRectangle();
            var cotes = rectangle.Init();
            perimetre = rectangle.Perimetre();
            surface = rectangle.Surface();
            string q1 = "Quelle est la valeur du périmètre sachant que la largeur vaut " + cotes.Item1 + " et la longueur vaut " + cotes.Item2 + " ?";
            string q2 = "Quelle est la valeur de la surface sachant que la largeur vaut " + cotes.Item1 + " et la longueur vaut " + cotes.Item2 + " ?";
            QuestionAffiche(q1, q2);
            Rectangle cnvrectangle = rectangle.Dessin();
            TheCanvas.Children.Clear();
            TheCanvas.Children.Add(cnvrectangle);
        }

        public void CreationCarre()
        {
            ClasseCarre carre = new ClasseCarre();
            var cotes = carre.Init();
            perimetre = carre.Perimetre();
            surface = carre.Surface();
            string q1 = "Quelle est la valeur du périmètre sachant qu'un côté vaut " + cotes + " ?";
            string q2 = "Quelle est la valeur de la surface sachant qu'un côté vaut " + cotes + " ?";
            QuestionAffiche(q1, q2);
            Rectangle cnvcarre = carre.Dessin();
            TheCanvas.Children.Clear();
            TheCanvas.Children.Add(cnvcarre);
        }

        public void CreationEllipse()
        {
            ClasseEllipse ellipse = new ClasseEllipse();
            var lesrayons = ellipse.Init();
            surface = ellipse.Surface();
            if (lesrayons.Item1 > lesrayons.Item2)
            {
                string q1 = "Quelle est la valeur de la surface sachant que le grand rayon vaut " + lesrayons.Item1 + " et le petit rayon vaut " + lesrayons.Item2 + " ?";
                QuestionAffiche("", q1);
            }
            else
            {
                string q1 = "Quelle est la valeur de la surface sachant que le petit rayon vaut " + lesrayons.Item1 + " et le grand rayon vaut " + lesrayons.Item2 + " ?";
                QuestionAffiche("", q1);
            }
            Ellipse cnvellipse = ellipse.Dessin();
            TheCanvas.Children.Clear();
            TheCanvas.Children.Add(cnvellipse);
            Txb_QuestionUn.Visibility = Visibility.Hidden;
            Txb_RepUn.Visibility = Visibility.Hidden;
            Lbl_DemandeUn.Visibility = Visibility.Hidden;
        }

        public void CreationCercle()
        {
            ClasseCercle circle = new ClasseCercle();
            var lerayon = circle.Init();
            surface = circle.Surface();
            perimetre = circle.Perimetre();
            string q1 = "Quelle est la valeur du périmètre sachant que le rayon vaut " + lerayon + " ?";
            string q2 = "Quelle est la valeur de la surface sachant que le rayon vaut " + lerayon + " ?";
            QuestionAffiche(q1, q2);
            Ellipse cnvcircle = circle.Dessin();
            TheCanvas.Children.Clear();
            TheCanvas.Children.Add(cnvcircle);
        }

        public void QuestionAffiche(string QuestionUn, string QuestionDeux)
        {
            Txb_QuestionDeux.Text = QuestionDeux;

            if (QuestionUn != "")
            {
                Txb_QuestionUn.Text = QuestionUn;
            }
        }

        private void Btn_New_Click(object sender, RoutedEventArgs e)
        {
            Apparition(idQuest);
            Txb_RepUn.IsEnabled = true;
            Txb_RepUn.Text = "";
            Txb_RepUn.Background = Brushes.White;
            Txb_RepDeux.IsEnabled = true;
            Txb_RepDeux.Text = "";
            Txb_RepDeux.Background = Brushes.White;
            Btn_ValideRep.IsEnabled = true;
            Btn_ValideRep.IsEnabled = false;
        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            Btn_ValideRep.IsEnabled = false;
            BtnTriangle.Visibility = Visibility.Visible;
            BtnRectangle.Visibility = Visibility.Visible;
            BtnCarre.Visibility = Visibility.Visible;
            BtnEllipse.Visibility = Visibility.Visible;
            BtnCercle.Visibility = Visibility.Visible;
            LblAccueil.Visibility = Visibility.Visible;
            Btn_Back.Visibility = Visibility.Hidden;
            Btn_New.Visibility = Visibility.Hidden;
            TheCanvas.Visibility = Visibility.Hidden;
            Txb_QuestionUn.Visibility = Visibility.Hidden;
            Lbl_DemandeUn.Visibility = Visibility.Hidden;
            Txb_RepUn.Visibility = Visibility.Hidden;
            Txb_QuestionDeux.Visibility = Visibility.Hidden;
            Lbl_DemandeDeux.Visibility = Visibility.Hidden;
            Txb_RepDeux.Visibility = Visibility.Hidden;
            Btn_ValideRep.Visibility = Visibility.Hidden;
            Lbl_Titre.Content = "S'amuser avec les maths !!!";
            Txb_RepUn.IsEnabled = true;
            Txb_RepUn.Text = "";
            Txb_RepUn.Background = Brushes.White;
            Txb_RepDeux.IsEnabled = true;
            Txb_RepDeux.Text = "";
            Txb_RepDeux.Background = Brushes.White;
            Btn_ValideRep.IsEnabled = true;
        }

        private void Btn_ValideRep_Click(object sender, RoutedEventArgs e)
        {
            if(Txb_RepUn.Background != Brushes.Green)
            {
                if (Txb_RepUn.Text != "")
                {
                    int erreurtotal1 = 0;
                    int erreurlettre1 = 0;
                    int virguleTxb1 = 0;
                    if (idQuest != 4)
                    {
                        // verif pour la question 1
                        // on verifie pour chaque caractère de la reponse
                        for (var i = 0; i < Txb_RepUn.Text.Length; i++)
                        {
                            // si un caractere n'est pas un nombre ou si il n'est pas une virgule on ajoute 1 a la variable erreur
                            if ((Txb_RepUn.Text[i] < Convert.ToChar("0") || Txb_RepUn.Text[i] > Convert.ToChar("9")) && Txb_RepUn.Text[i] != Convert.ToChar(","))
                            {
                                erreurtotal1 = erreurtotal1 + 1;
                                erreurlettre1 = erreurlettre1 + 1;
                            }

                            // on compte le nombre de virgule
                            if (Txb_RepUn.Text[i] == Convert.ToChar(","))
                            {
                                virguleTxb1 = virguleTxb1 + 1;
                            }
                        }
                        // si le premier caractere est une virgule erreur prend 1
                        if (Txb_RepUn.Text[0] == Convert.ToChar(","))
                        {
                            erreurtotal1 = erreurtotal1 + 1;
                        }

                        // si il y a une erreur 
                        if (erreurtotal1 != 0)
                        {
                            // si il y aau moins 2 virgules on affiche un message
                            if (virguleTxb1 >= 2)
                            {
                                MessageBox.Show("Il faut mettre qu'une seule virgule et elle ne dois pas être en première position !");
                            }
                            // si il y a des lettres on affiche un message
                            if (erreurlettre1 != 0)
                            {
                                MessageBox.Show("Il faut mettre que des numéros et utiliser la virgule pour les nombres décimaux !");
                            }
                        }
                        else
                        {
                            if (perimetre == Convert.ToDouble(Txb_RepUn.Text))
                            {
                                Txb_RepUn.Background = Brushes.Green;
                                Txb_RepUn.IsEnabled = false;
                                message = message + "\r\n Vous avez juste à la première question, vous gagnez un point .";
                                NbrQuestion = NbrQuestion + 1;
                                NbrBonneRep = NbrBonneRep + 1;
                            }
                            else
                            {
                                Txb_RepUn.Background = Brushes.Red;
                                message = message + "\r\n Vous avez faux à la première question, vous ne gagnez pas de point .";
                                Correction(idQuest, 1, perimetre);
                                message = message + "\r\n \r\n Retente ta chance :) ";
                                NbrQuestion = NbrQuestion + 1;
                            }
                        }
                    }
                }
            }

            if (Txb_RepDeux.Background != Brushes.Green)
            {
                if (Txb_RepDeux.Text != "")
                {
                    int erreurtotal2 = 0;
                    int erreurlettre2 = 0;
                    int virguleTxb2 = 0;
                    // verif pour la question 2
                    // on verifie pour chaque caractère de la reponse
                    for (var i = 0; i < Txb_RepDeux.Text.Length; i++)
                    {
                        // si un caractere n'est pas un nombre ou si il n'est pas une virgule on ajoute 1 a la variable erreur
                        if ((Txb_RepDeux.Text[i] < Convert.ToChar("0") || Txb_RepDeux.Text[i] > Convert.ToChar("9")) && Txb_RepDeux.Text[i] != Convert.ToChar(","))
                        {
                            erreurtotal2 = erreurtotal2 + 1;
                            erreurlettre2 = erreurlettre2 + 1;
                        }

                        // on compte le nombre de virgule
                        if (Txb_RepDeux.Text[i] == Convert.ToChar(","))
                        {
                            virguleTxb2 = virguleTxb2 + 1;
                        }
                    }
                    // si le premier caractere est une virgule erreur prend 1
                    if (Txb_RepDeux.Text[0] == Convert.ToChar(","))
                    {
                        erreurtotal2 = erreurtotal2 + 1;
                    }

                    // si il y a une erreur 
                    if (erreurtotal2 != 0)
                    {
                        // si il y aau moins 2 virgules on affiche un message
                        if (virguleTxb2 >= 2)
                        {
                            MessageBox.Show("Il faut mettre qu'une seule virgule et elle ne dois pas être en première position !");
                        }
                        // si il y a des lettres on affiche un message
                        if (erreurlettre2 != 0)
                        {
                            MessageBox.Show("Il faut mettre que des numéros et utiliser la virgule pour les nombres décimaux !");
                        }
                    }
                    else
                    {
                        if (surface == Convert.ToDouble(Txb_RepDeux.Text))
                        {
                            Txb_RepDeux.Background = Brushes.Green;
                            Txb_RepDeux.IsEnabled = false;
                            if (idQuest == 4)
                            {
                                message = message + "\r\n \r\n Vous avez juste, vous gagnez un point .";
                                NbrQuestion = NbrQuestion + 1;
                                NbrBonneRep = NbrBonneRep + 1;
                            }
                            else
                            {
                                message = message + "\r\n \r\n Vous avez juste à la deuxième question, vous gagnez un point .";
                                NbrQuestion = NbrQuestion + 1;
                                NbrBonneRep = NbrBonneRep + 1;
                            }
                        }
                        else
                        {
                            Txb_RepDeux.Background = Brushes.Red;
                            if (idQuest == 4)
                            {
                                message = message + "\r\n \r\n Vous avez faux, vous ne gagnez pas de point .";
                                Correction(idQuest, 2, surface);
                                message = message + "\r\n \r\n Retente ta chance :) ";
                                NbrQuestion = NbrQuestion + 1;
                            }
                            else
                            {
                                message = message + "\r\n \r\n Vous avez faux à la deuxième question, vous ne gagnez pas de point .";
                                Correction(idQuest, 2, surface);
                                message = message + "\r\n \r\n Retente ta chance :) ";
                                NbrQuestion = NbrQuestion + 1;
                            }
                        }
                    }
                }
            }
            
            

            
            Btn_ValideRep.IsEnabled = false;
            Txb_Score.Text = Convert.ToString(NbrBonneRep);
            Txb_Score2.Text = Convert.ToString(NbrQuestion);
            Pourcentage = (100 * NbrBonneRep ) / NbrQuestion;
            Txb_Pourcentage.Text = Convert.ToString(Pourcentage);
            if (message != "")
            {
                MessageBox.Show(message);
            }           
            message = "";
        }

        private void Correction(int num, int qt, double rep)
        {
            if (qt == 1)
            {
                if (num == 1)
                {
                    message = message + "\r\n La formule pour calculer le périmètre d'un triangle est: base + hauteur + hypothénuse . \r\n La réponse était donc " + Convert.ToString(rep) + ".";
                }
                else
                {
                    if (num == 2)
                    {
                        message = message + "\r\n La formule pour calculer le périmètre d'un rectangle est: (2 * largeur) + (2 * longueur) . \r\n La réponse était donc " + Convert.ToString(rep) + ".";
                    }
                    else
                    {
                        if (num == 3)
                        {
                            message = message + "\r\n La formule pour calculer le périmètre d'un carré est: 4 * côté . \r\n La réponse était donc " + Convert.ToString(rep) + ".";
                        }
                        else
                        {
                            message = message + "\r\n La formule pour calculer le périmètre d'un cercle est: 2 * PI * Rayon . \r\n La réponse était donc " + Convert.ToString(rep) + ".";
                        }
                    }
                }
            }
            else
            {
                if (num == 1)
                {
                    message = message + "\r\n La formule pour calculer la surface d'un triangle est: (base * hauteur)/2 . \r\n La réponse était donc " + Convert.ToString(rep) + ".";
                }
                else
                {
                    if (num == 2)
                    {
                        message = message + "\r\n La formule pour calculer la surface d'un rectangle est: largeur * longueur . \r\n La réponse était donc " + Convert.ToString(rep) + ".";
                    }
                    else
                    {
                        if (num == 3)
                        {
                            message = message + "\r\n La formule pour calculer la surface d'un carré est: côté * côté . \r\n La réponse était donc " + Convert.ToString(rep) + ".";
                        }
                        else
                        {
                            if (num == 4)
                            {
                                message = message + "\r\n La formule pour calculer la surface d'une ellipse est: (Petit Rayon) * (Grand Rayon) * PI . \r\n La réponse était donc " + Convert.ToString(rep) + ".";
                            }
                            else
                            {
                                message = message + "\r\n La formule pour calculer la surface d'un cercle est: PI * Rayon * Rayon . \r\n La réponse était donc " + Convert.ToString(rep) + ".";
                            }
                        }
                    }
                }
            }
        }

        private void Btn_Quitter_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Txb_RepUn_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Txb_RepUn.Text == "" && Txb_RepDeux.Text == "")
            {
                Btn_ValideRep.IsEnabled = false;
            }
            else
            {
                Btn_ValideRep.IsEnabled = true;
            }
        }

        private void Txb_RepDeux_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Txb_RepUn.Text == "" && Txb_RepDeux.Text == "")
            {
                Btn_ValideRep.IsEnabled = false;
            }
            else
            {
                Btn_ValideRep.IsEnabled = true;
            }
        }
    }        
    
}