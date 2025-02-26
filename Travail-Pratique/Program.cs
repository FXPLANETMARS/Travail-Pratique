using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using System;
using Travail_Pratique;

class Program
{
    static void Main(string[] args)
    {
        Matrice matrice = new Matrice();
        Echantillon echantillon = new Echantillon();
        bool quitter = false;

        while (!quitter)
        {
            Console.WriteLine("\n--- Menu Principal ---");
            Console.WriteLine("1. Charger un fichier de données");
            Console.WriteLine("2. Afficher la matrice");
            Console.WriteLine("3. Extraire un échantillon");
            Console.WriteLine("4. Calculer les statistiques de l'échantillon");
            Console.WriteLine("5. Quitter");
            Console.Write("Choisissez une option : ");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    Console.Write("Entrez le chemin du fichier : ");
                    string cheminFichier = Console.ReadLine();
                    matrice.ChargerFichier(cheminFichier);
                    break;

                case "2":
                    matrice.AfficherMatrice();
                    break;

                case "3":
                    if (ligne > 0)
                    {
                        Console.Write("Entrez la taille de l'échantillon à extraire : ");
                        if (int.TryParse(Console.ReadLine(), out int tailleEchantillon))
                        {
                            if (tailleEchantillon <= matrice.GetLigne())
                            {
                                echantillon.ExtraireEchantillon(matrice, tailleEchantillon);
                                Console.WriteLine("Échantillon extrait avec succès !");
                                echantillon.AfficherEchantillon();
                                echantillon.SauvegarderEchantillon("Echantillon.csv");
                            }
                            else
                            {
                                Console.WriteLine("Pas assez de données pour extraire cet échantillon.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Veuillez entrer un nombre valide.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("La matrice de données est vide. Veuillez charger un fichier en premier.");
                    }
                    break;

                case "4":
                    if (echantillon.Existe())
                    {
                        echantillon.CalculerStatistiques("Statistiques");
                    }
                    else
                    {
                        Console.WriteLine("Aucun échantillon n'a encore été extrait.");
                    }
                    break;

                case "5":
                    quitter = true;
                    Console.WriteLine("Fermeture du programme...");
                    break;

                default:
                    Console.WriteLine("Choix invalide. Veuillez réessayer.");
                    break;
            }
        }
    }
}

