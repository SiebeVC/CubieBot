using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeerdereTalenCubieBotWebsite.Models
{
    public class LogBoekElementen
    {
        public List<LogboekElement> lijstEle { get; set; }

        public LogBoekElementen()
        {
            lijstEle = new List<LogboekElement>();
            //Naam, wanneer, hoelang, wat nederlands, wat frans, wat engels


            //SIEBE & ROBIN


            lijstEle.Add(new LogboekElement("Robin", DateTime.Parse("16/11/2019"), "2:00", "OLL done", "Fait le OLL", "OLL done"));

            lijstEle.Add(new LogboekElement("Robin", DateTime.Parse("16/11/2019"), "2:00", "2de laag gemaakt (F2L)", "Fait la deuxième couche (F2L)", "Made the second layer (F2L)"));

            lijstEle.Add(new LogboekElement("Robin", DateTime.Parse("14/11/2019"), "2:30", "3 Hoekjes juist kunnen plaatsen", "Placé trois coins au bon place", "Placed three corners in the right spot"));

            lijstEle.Add(new LogboekElement("Robin", DateTime.Parse("13/11/2019"), "0:45", "Het blokje geel groen op de juiste plaats geplaatst", "Mettre le coin jaune vert au bon place", "Placed the green and yellow edge in the right spot"));

            lijstEle.Add(new LogboekElement("Robin", DateTime.Parse("13/11/2019"), "2:00", "Twee delen van het kruis gemaakt", "Fait 2 part de la cross", "Made two parts of the cross"));

            lijstEle.Add(new LogboekElement("Siebe", DateTime.Parse("13/11/2019"), "1:56", "Project: Beginnen met het algoritme", "Projet : Commencer par l'algorithme", "Project: Starting with the algorithm"));

            lijstEle.Add(new LogboekElement("Robin", DateTime.Parse("11/11/2019"), "1:00", "Fout opgelost", "Corrige l'erreur", "Fixed the error"));

            lijstEle.Add(new LogboekElement("Robin, Siebe", DateTime.Parse("11/11/2019"), "1:30", "Aan het algoritme van het kruis begonnen + Fout", "commencé l'algorithme de la croix + une erreur", "Started on making the algorithm for the cross + Error"));

            lijstEle.Add(new LogboekElement("Robin", DateTime.Parse("11/11/2019"), "1:30", "Een handleiding gemaakt + uitklapbaar menu", "Réalisation d'un menu manuel + menu pliable", "Made a manual + foldable menu"));

            lijstEle.Add(new LogboekElement("Robin", DateTime.Parse("08/11/2019"), "1:00", "Knoppen beter laten uitzien + optellen van de moves.", "Rendre les boutons plus beaux + additionner les coups", "Made the buttons look better + counter."));
            lijstEle.Add(new LogboekElement("Robin", DateTime.Parse("07/11/2019"), "3:45", "Gewerkt aan de opmaak", "Travaillé sur la mise en page", "Worked on Layout"));
            lijstEle.Add(new LogboekElement("Robin", DateTime.Parse("07/11/2019"), "2:00", "Gewerkt aan 'Show algorithm' + opmaak", "Travaillé sur 'show alogrithm' et la mise en page", "Worked on 'Show Algorithm' + Layout"));
            lijstEle.Add(new LogboekElement("Robin", DateTime.Parse("06/11/2019"), "2:00", "'<--' toets gemaakt", "Fait le bouton '<--'", "Made the '<--' button"));
            lijstEle.Add(new LogboekElement("Robin", DateTime.Parse("06/11/2019"), "1:00", "Werken aan de '<-- toets'", "Travailler à le bouton '<--'", "Working on the '<--' button"));
            lijstEle.Add(new LogboekElement("Siebe", DateTime.Parse("04/11/2019"), "1:30", "Maken van de teaser versie 1", "Réalisation de l'accroche version 1", "Making the teaser version 1"));
            lijstEle.Add(new LogboekElement("Robin", DateTime.Parse("04/11/2019"), "0:30", "Het logboek veranderd naar een tabel", "Changement du journal de bord à une seule table", "Changed the logbook to one table"));
            lijstEle.Add(new LogboekElement("Siebe", DateTime.Parse("28/10/2019"), "0:30", "Accepteren van vakjes toegevoegd", "Acceptation des boîtes ajoutées", "Acceptance of boxes added" ));
            lijstEle.Add(new LogboekElement("Siebe", DateTime.Parse("28/10/2019"), "1:30", "Deel van de controle op het vakje toegevoegd", "Une partie de la vérification de la case ajoutée", "Part of the check on the box added"));
            lijstEle.Add(new LogboekElement("Siebe", DateTime.Parse("28/10/2019"), "1:30", "Kleuren van vakjes toegevoegd", "Couleurs des boîtes ajoutées", "Colours of boxes added"));
            lijstEle.Add(new LogboekElement("Siebe", DateTime.Parse("27/10/2019"), "2:00", "Toevoegen van deadline lijst/menu + Download", "Ajouter une liste/menu de délais + Télécharger", "Add deadline list/menu + Download"));
            lijstEle.Add(new LogboekElement("Robin", DateTime.Parse("27/10/2019"), "2:45", "Toevoegen van deadline lijst/menu + Download", "Ajouter une liste/menu de délais + Télécharger", "Add deadline list/menu + Download"));
            lijstEle.Add(new LogboekElement("Siebe", DateTime.Parse("25/10/2019"), "2:00", "Verbeteren van de website", "Amélioration du site Web", "Improving the website"));
            lijstEle.Add(new LogboekElement("Robin", DateTime.Parse("25/10/2019"), "2:00", "Werken aan taalkiezer", "Travail sur le sélecteur de langue", "Working on the language picker"));
            lijstEle.Add(new LogboekElement("Siebe", DateTime.Parse("23/10/2019"), "2:30","MVC website aanmaken", "Création du site web MVC", "creating MVC website"));






            
        }
    }
}