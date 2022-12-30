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


        //outils permettant de choisir une direction pour se rendre vers des coordonnées précise.
        public static double[] Direction(double departureX,double departureY, double destinationX,double destinationY)   //gives the direction you need to take to go from departure-point to destination-point
        {
            double[] vector = new double[] { destinationX - departureX, destinationY - departureY };
            if (vector[0] == 0)
            {
                if (vector[1] > 0) { return new double[] { 0, 1 }; }
                else { return new double[] { 0, -1 }; }
            }
            if (vector[1] == 0)
            {
                if (vector[0] > 0) { return new double[] { 1, 0 }; }
                else { return new double[] { -1, 0 }; }
            }
            double sinus = (double)Math.Round((double)(1000 * (vector[1] / vector[0])));
            if (vector[0] > 0 && vector[1] > 0) //1st quadrant
            {
                if (sinus > 924) { return new double[] { 0, 1 }; } //N
                else if (sinus < 383) { return new double[] { 1, 0 }; }    //E
                else { return new double[] { 1, 1 }; } //NE
            }
            else if (vector[0] > 0 && vector[1] < 0) //2nd quadrant
            {
                if (sinus > -383) { return new double[] { 1, 0 }; }    //E
                else if (sinus < -924) { return new double[] { 0, -1 }; }  //S
                else { return new double[] { 1, -1 }; }    //SE
            }
            else if (vector[0] < 0 && vector[1] < 0) //3rd quadrant
            {
                if (sinus < -924) { return new double[] { 0, -1 }; }  //S
                else if (sinus > -383) { return new double[] { -1, 0 }; } //O
                else { return new double[] { -1, -1 }; }   //SO
            }
            else  //4th quadrant
            {
                if (sinus < 383) { return new double[] { -1, 0 }; }    //O
                else if (sinus > 924) { return new double[] { 0, 1 }; }    //N
                else { return new double[] { -1, 1 }; }    //NO
            }
        }

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
