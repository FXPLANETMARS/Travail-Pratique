using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travail_Pratique
{
    internal class MenuPrincipal
    {
        public  MenuPrincipal()
        {
            while (true)
            {
                Console.WriteLine("Modélisation des concepts statistiques!\n" +
                "****************************************\n" +
                "\tOption 1- Charger le fichier de donnees en memoire\n" +
                "\tOption 2- Afficher l'ensemble  de donnees\n" +
                "\tOption 3- Generer un echantillon\n" +
                "\tOption 4- Quitter\n\n\tOptions ? : ");
            }
        }
    }
}

                /*switch (Console.ReadLine())
                {
                    case "1": ChargerMatrice(); break;
                    case "2": AfficherMatrice(dataMatrix); break;
                    case "3": ExtraireEchantillon(); break;
                    case "4": CalculerStatistiques(); break;
                    case "5": return;
                    default: Console.WriteLine("Option invalide, veuillez réessayer."); break;
                }*/
