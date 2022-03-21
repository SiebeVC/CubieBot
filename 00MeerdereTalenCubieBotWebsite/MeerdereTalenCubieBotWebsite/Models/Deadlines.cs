using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeerdereTalenCubieBotWebsite.Models
{
    public class Deadlines
    {
        public List<Deadline> lijstDeadlines { get; set; }

        public Deadlines()
        {
            lijstDeadlines = new List<Deadline>();

            //Projectvoorstelling
            lijstDeadlines.Add(new Deadline("16/09/2019", "Projectvoorteling 1", "Project presentation 1", "Presentation de project 1", "Projectvoorstelling V1.pdf"));
            lijstDeadlines.Add(new Deadline("23/09/2019", "Projectvoorteling 2", "Project presentation 2", "Presentation de project 2", "Projectvoorstelling V2.pptx"));

            //Projectplan
            lijstDeadlines.Add(new Deadline("07/10/2019", "Projectplan 1", "Project plan 1", "Plan de projet 1", "Projectplan versie 1.pdf"));
            lijstDeadlines.Add(new Deadline("21/10/2019", "Projectplan 2", "Project plan 2", "Plan de projet 2", "Projectplan Versie 2.pdf"));

            //Klacht via telefoon
            lijstDeadlines.Add(new Deadline("04/11/2019", "Klacht via telefoon", "Complaint via telephone", "Plainte par téléphone"));

            //Technische analyse
            lijstDeadlines.Add(new Deadline("21/10/2019", "Technische analyse 1", "Technical analysis 1", "Analyse technique 1", "Technische analyse V1.pdf"));
            lijstDeadlines.Add(new Deadline("13/11/2019", "Technische analyse 2", "Technical analysis 2", "Analyse technique 2"));

            //Teaser
            lijstDeadlines.Add(new Deadline("06/11/2019", "Teaser 1", "Teaser 1", "Teaser 1","Teaser V1.png"));
            lijstDeadlines.Add(new Deadline("20/11/2019", "Teaser 2", "Teaser 2", "Teaser 2"));

            //Voicemail
            lijstDeadlines.Add(new Deadline("06/11/2019", "Voicemail 1", "Voicemail 1", "Voicemail 1"));
            lijstDeadlines.Add(new Deadline("20/11/2019", "Voicemail 2", "Voicemail 2", "Voicemail 2"));

            //Verkoopsgesprek
            lijstDeadlines.Add(new Deadline("14/11/2019", "Verkoopsgesprek", "Sales conversation", "Argumentaire de vente"));

            //Dossier externe jury
            lijstDeadlines.Add(new Deadline("20/12/2019", "Dossier externe jury 1", "Dossier external jury 1", "Dossier jury externe 1"));
            lijstDeadlines.Add(new Deadline("Eind mei", "Dossier externe jury 2", "Dossier external jury 2", "Dossier jury externe 2"));

            //Projectontwikkeling
            lijstDeadlines.Add(new Deadline("08/01/2020", "Projectontwikkeling 1", "Project development 1", "Développement du projet 1"));
            lijstDeadlines.Add(new Deadline("27/04/2020", "Projectontwikkeling 2", "Project development 2", "Développement du projet 2"));

            //Marketing
            lijstDeadlines.Add(new Deadline("09/03/2020", "Marketing 1", "Marketing 1", "Marketing 1"));
            lijstDeadlines.Add(new Deadline("23/03/2020", "Marketing 2", "Marketing 2", "Marketing 2"));
            lijstDeadlines.Add(new Deadline("03/04/2020", "Marketing 3", "Marketing 3", "Marketing 3"));

            //Helpdeks via telefoon
            lijstDeadlines.Add(new Deadline("14/02/2020", "Helpdesk via telefoon", "Helpdesk via telephone", "Helpdesk par téléphone"));

            //Handleiding
            lijstDeadlines.Add(new Deadline("04/05/2020", "Handleiding 1", "Guide 1", "Cours d'instruction 1"));
            lijstDeadlines.Add(new Deadline("18/05/2020", "Handleiding 2", "Guide 2", "Cours d'instruction 2"));

        }
    }
}