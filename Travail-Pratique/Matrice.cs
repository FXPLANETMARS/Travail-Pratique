using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travail_Pratique
{
    internal class Matrice
    {
        private double[,] donnees;
        private int lignes;
        private int colonnes;

        public bool ChargerFichier(string nomFichier)
        {
            bool authLoop = true;

            do
            {
                if (!File.Exists(nomFichier))
                {
                    Console.WriteLine("Fichier introuvable.");
                    authLoop = false;
                }
                else { authLoop = true; }
            } while (authLoop == false);

                string[] lignesFichier = File.ReadAllLines(nomFichier);
                lignes = lignesFichier.Length;
                colonnes = lignesFichier[0].Split(';').Length;
                donnees = new double[lignes, colonnes];

                for (int i = 0; i < lignes; i++)
                {
                    string[] valeurs = lignesFichier[i].Split(';');
                    for (int j = 0; j < colonnes; j++)
                    {
                        donnees[i, j] = double.Parse(valeurs[j]);
                    }
                }

                Console.WriteLine("Fichier chargé avec succès.");
                return true;
            
        }

        public void AfficherMatrice()
        {
            if (donnees == null || donnees.Length == 0)
            {
                Console.WriteLine("La matrice est vide.");
                return;
            }

            for (int i = 0; i < lignes; i++)
            {
                for (int j = 0; j < colonnes; j++)
                {
                    Console.Write(donnees[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public double[] GetLigne(int index)
        {
        if (index < 0 || index >= lignes)
        {
            throw new IndexOutOfRangeException("Indice de ligne invalide.");
        }

        double[] ligne = new double[colonnes];
        for (int j = 0; j < colonnes; j++)
        {
            ligne[j] = donnees[index, j];
        }
        return ligne;
        }
    }
}

