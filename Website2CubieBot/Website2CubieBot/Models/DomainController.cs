using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Website2CubieBot.Models
{
    [NotMapped]
    public class DomainController
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        #region Singleton Pattern
        // Bron: https://csharpindepth.com/Articles/Singleton
        private static readonly DomainController instance = new DomainController();
        // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static DomainController() { }
        private DomainController() { }
        public static DomainController Instance { get { return instance; } }
        #endregion

        #region Properties
        public DbSet<Persoon> Personen
        {
            get { return db.Personen; }
            set { db.Personen = value; }
        }

        public DbSet<LogboekItem> LogboekItems
        {
            get { return db.LogboekItems; }
            set { db.LogboekItems = value; }
        }

        public DbSet<Fout> Fouten
        {
            get { return db.Fouten; }
            set { db.Fouten = value; }
        }

        public DbSet<Taal> Talen
        {
            get { return db.Talen; }
            set { db.Talen = value; }
        }
        #endregion

        #region LogboekItem

        /// <summary>
        /// Zoekt een item in de DB
        /// </summary>
        /// <param name="id">Het Id van het te zoeken item</param>
        /// <returns>Het gevonden item indien gelukt anders null</returns>
        public LogboekItem GetLogboekItem(int? id)
        {
            LogboekItem item = null;
            try
            {
                item = db.LogboekItems.Find(id);
                if (item != null)
                {
                    return item;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogFout(ex);
                return null;
            }
        }

        /// <summary>
        /// Voegt een item toe aan de DB
        /// </summary>
        /// <param name="item">Het toe te voegen logboekitem</param>
        /// <returns>het item indien gelukt anders null</returns>
        public LogboekItem CreateLogboekItem(LogboekItem item)
        {
            try
            {
                if (item != null)
                {
                    db.LogboekItems.Add(item);

                    db.SaveChanges();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogFout(ex);
                return null;
            }

            return item;
        }

        /// <summary>
        /// Edit een logboek item
        /// </summary>
        /// <param name="item">het te editen item</param>
        /// <returns>Het geëdite item indien gelukt, anders null</returns>
        public LogboekItem EditLogboekItem(LogboekItem item)
        {
            LogboekItem itemTeEditen;

            try
            {
                if (item != null)
                {
                    itemTeEditen = GetLogboekItem(item.Id);
                    if (itemTeEditen != null)
                    {
                        itemTeEditen.Inhoud = item.Inhoud;
                        itemTeEditen.Titel = item.Titel;
                        itemTeEditen.Datum = item.Datum;
                        itemTeEditen.Persoon = item.Persoon;

                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                LogFout(ex);
                return null;
            }

            return item;
        }

        /// <summary>
        /// Verwijderd een item uit de DB
        /// </summary>
        /// <param name="item">Het te verwijdere item</param>
        /// <returns>True indien gelukt, anders false</returns>
        public bool DeleteLogboekItem(LogboekItem item)
        {
            try
            {
                if (item != null)
                {
                    db.LogboekItems.Remove(item);
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                LogFout(ex);
                return false;
            }

            return true;
        }

        #endregion

        #region Persoon

        /// <summary>
        /// Zoekt een persoon op in de DB
        /// </summary>
        /// <param name="id">Het id van de persoon</param>
        /// <returns>De persoon indien gevonden anders null</returns>
        public Persoon GetPersoon(int? id)
        {
            Persoon persoon = null;
            try
            {
                if (id != 0)
                {
                    persoon = db.Personen.Find(id);
                }
            }
            catch (Exception ex)
            {
                LogFout(ex);

                return null;
            }

            return persoon;
        }

        /// <summary>
        /// Voegt een persoon toe aan de DB
        /// </summary>
        /// <param name="persoon">De toe te voegen persoon</param>
        /// <returns>De persoon indien gelukt, null indien mislukt</returns>
        public Persoon CreatePersoon(Persoon persoon)
        {
            try
            {
                //Toevoegen van persoon
                db.Personen.Add(persoon);

                //Opslaan
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                LogFout(ex);

                return null;
            }

            return persoon;
        }

        /// <summary>
        /// Edit een persoon
        /// </summary>
        /// <param name="persoon">De aangepaste persoon</param>
        /// <returns>De persoon indien gelukt anders null</returns>
        public Persoon EditPersoon(Persoon persoon)
        {
            Persoon persoonTeEditen;
            try
            {
                persoonTeEditen = db.Personen.Find(persoon.Id);

                if (persoonTeEditen != null)
                {
                    persoonTeEditen.Voornaam = persoon.Voornaam;
                    persoonTeEditen.Achternaam = persoon.Achternaam;
                    persoonTeEditen.Email = persoon.Email;
                    persoonTeEditen.GeboorteDatum = persoon.GeboorteDatum;
                    persoonTeEditen.Gemeente = persoon.Gemeente;

                    db.SaveChanges();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogFout(ex);
                return null;
            }

            return persoonTeEditen;
        }

        /// <summary>
        /// Verwijderd een persoon uit de db
        /// </summary>
        /// <param name="persoon">De te verwijderen persoon</param>
        /// <returns>True gelukt; False niet</returns>
        public bool DeletePersoon(Persoon persoon)
        {
            try
            {
                if (persoon != null)
                {
                    db.Personen.Remove(persoon);

                    db.SaveChanges();
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogFout(ex);
                throw;
            }

            return true;
        }

        #endregion

        #region Talen

        /// <summary>
        /// Zoekt een taal op in de databank. Op basis van een Id.
        /// </summary>
        /// <param name="id">Id van de taal</param>
        /// <returns>De juiste taal</returns>
        public Taal GetTaal(int? id)
        {
            Taal taal = null;
            try
            {
                if (id != null && id != 0)
                {
                    taal = db.Talen.Find(id);
                }
            }
            catch (Exception ex)
            {
                LogFout(ex);
                return null;
            }

            return taal;
        }

        /// <summary>
        /// Voegt een taal toe aan de databank
        /// </summary>
        /// <param name="taal">De toe te voegen taal</param>
        /// <returns>De taal</returns>
        public Taal CreateTaal(Taal taal)
        {
            try
            {
                if (taal != null)
                {
                    db.Talen.Add(taal);

                    db.SaveChanges();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogFout(ex);
                return null;
            }

            return taal;
        }

        /// <summary>
        /// Een taal aanpassen
        /// </summary>
        /// <param name="taal">De aangepaste taal</param>
        /// <returns>De aangpaste taal indien gelukt anders null</returns>
        public Taal EditTaal(Taal taal)
        {
            Taal taalTeEditen;
            try
            {
                if (taal != null)
                {
                    taalTeEditen = GetTaal(taal.Id);

                    taalTeEditen.Inhoud = taal.Inhoud;
                    taalTeEditen.Keuze = taal.Keuze;
                    taalTeEditen.Locatie = taal.Locatie;
                    taalTeEditen.Volgorde = taal.Volgorde;
                    taalTeEditen.Titel = taal.Titel;

                    db.SaveChanges();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogFout(ex);
                return null;
            }

            return taal;
        }

        /// <summary>
        /// Verwijderen van een taal
        /// </summary>
        /// <param name="taal">De te verwijderen taal</param>
        /// <returns>True indien gelukt, anders false</returns>
        public bool DeleteTaal(Taal taal)
        {
            try
            {
                if (taal != null)
                {
                    db.Talen.Remove(taal);

                    db.SaveChanges();
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                LogFout(ex);
                return false;
            }

            return true;
        }

        public List<Taal> GetTalenVanPagina(string pagina, TaalKeuze keuze)
        {
            List<Taal> lstTalen = new List<Taal>();

            try
            {
                //Dit haalt al de juiste talen op
                if (pagina != null)
                {
                    lstTalen = db.Talen.Where(t => t.Locatie == pagina && t.Keuze == keuze).ToList();
                    lstTalen = lstTalen.OrderBy(t => t.Volgorde).ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogFout(ex);
                return null;
            }

            return lstTalen;
        }

        #endregion

        #region Fouten

        /// <summary>
        /// Maakt een voegt een fout toe aan de DB
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <returns>fout anders (indien mislukt) null</returns>
        public Fout LogFout(Exception ex)
        {
            Fout fout = new Fout();
            try
            {
                fout.Tijdstip = DateTime.Now;
                fout.Melding = ex.Message;
                if (ex.InnerException != null)
                {
                    fout.InnerMelding = ex.InnerException.ToString();
                }

                db.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }

            return fout;
        }

        #endregion
    }
}