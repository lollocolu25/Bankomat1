using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat1
{
    internal class Interfaccia
    {
        enum Richiesta
        {
            SchermataDiBenvenuto,
            Login,
            MenuPrincipale,
            //Versamento,
            //ReportSaldo,
            //Prelievo,
            Uscita
        };

        private SortedList<int, Banca> _banche;
        private Banca _bancaCorrente;

        public Interfaccia(SortedList<int, Banca> banche)
        {
            _banche = new SortedList<int, Banca>();
        }

        private void StampaIntestazione()
        {
            Console.Clear();
            Console.WriteLine("**************************************************");
            Console.WriteLine("*              Bankomat Simulator               *");
            return;
        }

        private int Menu(int min, int max)
        {
            string rispostaUtente;


            Console.Write("Scelta: ");
            rispostaUtente = Console.ReadKey().KeyChar.ToString();
            if (!Int32.TryParse(rispostaUtente, out int scelta) ||
                !(min <= scelta && scelta <= max))
            {
                scelta = -1;
                Console.WriteLine("");
                Console.WriteLine($"Scelta non consentita - {rispostaUtente}");
                Console.Write("Premere un tasto per proseguire");
                Console.ReadKey();
            }
            return scelta;
        }

        private int SchermataDiBenvenuto()
        {
            int scelta = -1;
            while (scelta == -1)
            {
                StampaIntestazione();

                using (var ctx = new EsercitazioneEntities())
                {
                    Console.WriteLine("lista banche:");
                    int key = 0;
                    foreach (var banca_db in ctx.Banche)
                    {
                        key++;
                        Banca banca = new Banca();
                        banca.Nome = banca_db.Nome;

                      

                        _banche.Add(key, banca);

                        Console.WriteLine($"{key} - {banca_db.Nome} ");
                    }

                }
                Console.WriteLine("0 - Uscita");

                scelta = Menu(0, _banche.Count);
            }

            return scelta;

        }

        //private bool Login()
        //{

        //    bool autenticato = false;

        //    Utente credenziali = new Utente();
        //    Console.Write("Nome utente: ");
        //    credenziali.NomeUtente = Console.ReadLine();
        //    Console.Write("Password: ");
        //    credenziali.Password = Console.ReadLine();
        //    using (var ctx = new EsercitazioneEntities()) {
        //        foreach (var utenti_db in banca_db.Utentis)
        //        {
        //            Utente utente = new Utente();
        //            utente.NomeUtente = utenti_db.NomeUtente;
        //            utente.Password = utenti_db.Password;

                    

                    
        //        }

        //        StampaIntestazione($"Login - {_bancaCorrente.Nome}");

            

        //    Banca.EsitoLogin esitoLogin =
        //        _bancaCorrente.Login(credenziali, out Utente utente);

        //    switch (esitoLogin)
        //    {
        //        case Banca.EsitoLogin.PasswordErrata:
        //            Console.WriteLine($"Password errata - " +
        //                $"{utente.TentativiDiAccessoResidui} " +
        //                @"tentativ{0} residu{0}", utente.TentativiDiAccessoResidui == 1 ? "o" : "i");
        //            Console.Write("Premere un tasto per proseguire");
        //            Console.ReadKey();
        //            break;
        //        case Banca.EsitoLogin.UtentePasswordErrati:
        //            Console.WriteLine("Utente o password errati");
        //            Console.Write("Premere un tasto per proseguire");
        //            Console.ReadKey();
        //            break;
        //        case Banca.EsitoLogin.AccountBloccato:
        //            Console.WriteLine("*** Account utente bloccato ***");
        //            Console.Write("Premere un tasto per proseguire");
        //            Console.ReadKey();
        //            break;
        //        case Banca.EsitoLogin.AccessoConsentito:
        //            _bancaCorrente.UtenteCorrente = utente;
        //            autenticato = true;
        //            break;
        //    }

        //    return autenticato;
        //}

        public void Esegui()
        {
            int rispostaUtente = 0;
            Richiesta richiesta = Richiesta.SchermataDiBenvenuto;

            while (richiesta != Richiesta.Uscita)
            {
                switch (richiesta)
                {
                    case Richiesta.SchermataDiBenvenuto:
                        rispostaUtente = SchermataDiBenvenuto();

                        if (rispostaUtente == 0)
                            richiesta = Richiesta.Uscita;
                        else
                        {

                            _bancaCorrente = _banche[rispostaUtente];
                            richiesta = Richiesta.Login;
                        }
                        break;
                    //case Richiesta.Login:
                    //    if (Login())
                    //        richiesta = Richiesta.MenuPrincipale;
                    //    else
                    //        richiesta = Richiesta.SchermataDiBenvenuto;
                    //    break;
                        //case Richiesta.MenuPrincipale:
                        //    switch (MenuPrincipale())
                        //    {
                        //        case Banca.Funzionalita.Uscita:
                        //            richiesta = Richiesta.SchermataDiBenvenuto;
                        //            break;
                        //        case Banca.Funzionalita.Versamento:
                        //            richiesta = Richiesta.Versamento;
                        //            break;
                        //        case Banca.Funzionalita.ReportSaldo:
                        //            richiesta = Richiesta.ReportSaldo;
                        //            break;
                        //        case Banca.Funzionalita.Prelievo:
                        //            richiesta = Richiesta.Prelievo;
                        //            break;
                        //    }
                        //    break;
                        //case Richiesta.Versamento:
                        //    bool esito = Versamento();
                        //    if (esito && _bancaCorrente.ElencoFunzionalita
                        //        .ContainsValue(Banca.Funzionalita.ReportSaldo))
                        //        richiesta = Richiesta.ReportSaldo;
                        //    else
                        //        richiesta = Richiesta.MenuPrincipale;
                        //    break;
                        //case Richiesta.ReportSaldo:
                        //    ReportSaldo();
                        //    richiesta = Richiesta.MenuPrincipale;
                        //    break;
                        //case Richiesta.Prelievo:
                        //    Prelievo();
                        //    richiesta = Richiesta.MenuPrincipale;
                        //    break;
                        //default:
                        //    break;
                }
            }
        }
    }
}
