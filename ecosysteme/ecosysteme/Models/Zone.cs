using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecosysteme.Models
{
    public class Zone
    {
        double rayon;
        public Zone(double rayon)
        {
            this.rayon = rayon;
        }
        public double getRayon() { return this.rayon;}

        //outil permettant de calculer la distance entre 2 points
        public static double Distance(double firstCoordinateX,double firstCoordinateY, double secondCoordinateX,double secondCoordinateY)   
        {
            return (double)Math.Ceiling(Math.Sqrt(Math.Pow(firstCoordinateX - secondCoordinateX, 2) + Math.Pow(firstCoordinateY - secondCoordinateY, 2)));
            //N.B.: I use Math.Ceiling to always round UP
        }

        //renvoi une liste de toutes les coordonnées dans la zone.
        public List<double[]> Area(double x,double y)
        {
            List<double[]> answer = new List<double[]>();
            for (double i = x - this.rayon; i <= x + this.rayon; i++)
            {
                for (double j = y - this.rayon; j <= y + this.rayon; j++)
                {
                    if (Distance(i,j,x,y) <= this.rayon) { answer.Add(new double[] { i, j }); }    //carré pour l'instant
                }
            }
            return answer;
        }
    }
}
