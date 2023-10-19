using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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

        
        private Banche _bancaCorrente;
        private Utenti _utenteCorrente;

        //public Interfaccia(SortedList<int, Banca> banche)
        //{
        //    _banche = new SortedList<int, Banca>();
        //}

        private void StampaIntestazione(string titolo)
        {
            Console.Clear();
            Console.WriteLine("**************************************************");
            Console.WriteLine("*              Bankomat Simulator               *");
            Console.WriteLine("".PadLeft(titolo.Length)
                +titolo);
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

        private int SchermataDiBenvenuto(EsercitazioneEntities ctx)
        {
            int scelta = -1;
            while (scelta == -1)
            {
                StampaIntestazione("selezione banca");

                
                    Console.WriteLine("lista banche:");
                    int key = 0;
                    foreach (Banche banche in ctx.Banche)
                    {
                        Console.WriteLine($"{banche.Id}-{banche.Nome}");

                        key++;
                     
                    }

                
                

                scelta = Menu(0, key);
            }

            return scelta;

        }

        private bool Login(EsercitazioneEntities ctx)
        {

            bool autenticato = false;

            Utenti credenziali = new Utenti();

            StampaIntestazione($"Login - {_bancaCorrente.Nome}");

            Console.Write("Nome utente: ");
            credenziali.NomeUtente = Console.ReadLine();

            Console.Write("Password: ");
            credenziali.Password = Console.ReadLine();
            int idBanca = Convert.ToInt32(_bancaCorrente.Id);

            EsitoLogin esitoLogin = _bancaCorrente.Login(credenziali, idBanca, out Utenti utente, ctx);

                switch (esitoLogin)
                {
                    //case Banca.EsitoLogin.PasswordErrata:
                    //    Console.WriteLine($"Password errata - " +
                    //        $"{utente.TentativiDiAccessoResidui} " +
                    //        @"tentativ{0} residu{0}", utente.TentativiDiAccessoResidui == 1 ? "o" : "i");
                    //    Console.Write("Premere un tasto per proseguire");
                    //    Console.ReadKey();
                    //    break;
                    case EsitoLogin.UtentePasswordErrati:
                        Console.WriteLine("Utente o password errati");
                        Console.Write("Premere un tasto per proseguire");
                        Console.ReadKey();
                        break;
                    case EsitoLogin.AccountBloccato:
                        Console.WriteLine("*** Account utente bloccato ***");
                        Console.Write("Premere un tasto per proseguire");
                        Console.ReadKey();
                        break;
                    case EsitoLogin.AccessoConsentito:
                        _utenteCorrente = utente;
                        autenticato = true;
                        break;
                }

                return autenticato;
            }
            private Funzionalita MenuPrincipale()
        {
            return new Funzionalita();  
        }
            public void Esegui(EsercitazioneEntities ctx)
        {
            int rispostaUtente = 0;
            Richiesta richiesta = Richiesta.SchermataDiBenvenuto;

            while (richiesta != Richiesta.Uscita)
            {
                switch (richiesta)
                {
                    case Richiesta.SchermataDiBenvenuto:
                        rispostaUtente = SchermataDiBenvenuto(ctx);

                        if (rispostaUtente == 0)
                            richiesta = Richiesta.Uscita;
                        else
                        {

                            _bancaCorrente = ctx.Banche.FirstOrDefault(b => b.Id == rispostaUtente);
                            richiesta = Richiesta.Login;
                        }
                        break;
                    case Richiesta.Login:
                        if (Login(ctx))
                            richiesta = Richiesta.MenuPrincipale;
                        else
                            richiesta = Richiesta.SchermataDiBenvenuto;
                        break;
                    case Richiesta.MenuPrincipale:
                        switch (MenuPrincipale())
                        {
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
                        }
                        break;
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
