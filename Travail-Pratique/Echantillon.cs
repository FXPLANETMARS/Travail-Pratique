using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travail_Pratique
{
    internal class Echantillon
    {
        private double[,] donneesEchantillon;
        private int lignes;
        private int colonnes;

        private List<double[]> echantillon;

        public Echantillon()
        {
            echantillon = new List<double[]>();
        }

        public void ExtraireEchantillon(Matrice matrice, int taille)
        {
            if (matrice == null)
            {
                Console.WriteLine("La matrice de données n'est pas encore chargée.");
                return;
            }

            int lignes = Convert.ToInt32(matrice.GetLigne);
            if (lignes == 0)
            {
                Console.WriteLine("La matrice est vide.");
                return;
            }

            if (taille > lignes)
            {
                Console.WriteLine("Pas assez de données pour extraire l'échantillon désiré.");
                return;
            }

            Random rand = new Random();
            HashSet<int> indicesChoisis = new HashSet<int>();
            while (indicesChoisis.Count < taille)
            {
                indicesChoisis.Add(rand.Next(lignes));
            }

            echantillon = indicesChoisis.Select(index => matrice.GetLigne(index)).ToList();
            Console.WriteLine("Échantillon extrait avec succès.");
            AfficherEchantillon();
            SauvegarderEchantillon("Echantillon.csv");
        }

        public void AfficherEchantillon()
        {
            if (echantillon.Count == 0)
            {
                Console.WriteLine("Aucun échantillon disponible.");
                return;
            }

            foreach (var ligne in echantillon)
            {
                Console.WriteLine(string.Join("\t", ligne));
            }
        }

        public void SauvegarderEchantillon(string nomFichier)
        {
            File.WriteAllLines(nomFichier, echantillon.Select(ligne => string.Join(";", ligne)));
            Console.WriteLine($"Échantillon sauvegardé dans {nomFichier}.");
        }

        public void CalculerStatistiques()
        {
            if (donneesEchantillon == null || donneesEchantillon.Length == 0)
            {
                Console.WriteLine("L'échantillon est vide.");
                return;
            }

            List<double> moyennes = new List<double>();
            List<double> variances = new List<double>();
            List<double> ecartsTypes = new List<double>();
            List<double> minimums = new List<double>();
            List<double> maximums = new List<double>();

            for (int i = 0; i < lignes; i++)
            {
                double[] ligne = new double[colonnes];
                for (int j = 0; j < colonnes; j++)
                {
                    ligne[j] = donneesEchantillon[i, j];
                }
                moyennes.Add(ligne.Average());
                variances.Add(ligne.Select(val => Math.Pow(val - ligne.Average(), 2)).Average());
                ecartsTypes.Add(Math.Sqrt(variances.Last()));
                minimums.Add(ligne.Min());
                maximums.Add(ligne.Max());
            }

            EnregistrerStatistiques(moyennes, "Moyenne.csv");
            EnregistrerStatistiques(variances, "Variance.csv");
            EnregistrerStatistiques(ecartsTypes, "EcartType.csv");
            EnregistrerStatistiques(minimums, "Minimum.csv");
            EnregistrerStatistiques(maximums, "Maximum.csv");
        }

        private void EnregistrerStatistiques(List<double> valeurs, string cheminFichier)
        {
            File.WriteAllLines(cheminFichier, valeurs.Select(val => val.ToString()));
            Console.WriteLine($"Statistiques sauvegardées dans {cheminFichier}");
        }
    }
}

