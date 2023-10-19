using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bankomat1.ContoCorrente;

namespace Bankomat1
{
    class Banca
    {
        public enum Funzionalita
        {
            Versamento,
            Prelievo,
            ReportSaldo,
            Sblocco,
            Uscita
        }


        public enum EsitoLogin
        {
            AccessoConsentito,
            UtentePasswordErrati,
            PasswordErrata,
            AccountBloccato
        }


        private string _nome;
        private List<Utente> _utenti;
        private SortedList<int, Funzionalita> _funzionalita;


        private Utente _utenteCorrente;

        public string Nome { get => _nome; set => _nome = value; }

        public List<Utente> Utenti { get => _utenti; set => _utenti = value; }
        public Utente UtenteCorrente { get => _utenteCorrente; set => _utenteCorrente = value; }
        internal SortedList<int, Funzionalita> ElencoFunzionalita { get => _funzionalita; set => _funzionalita = value; }

        public EsitoLogin Login(Utente credenziali, out Utente utente)
        {
            Utente utenteDaValidare = null;
            //ricerco utente sul 
            utente = null;

            foreach (var elem in Utenti)
            {
                if (elem.NomeUtente == credenziali.NomeUtente)
                {
                    utenteDaValidare = elem;
                    break;
                }
            }
            if (utenteDaValidare == null)
            {
                return EsitoLogin.UtentePasswordErrati;
            }


            if (credenziali.Password != utenteDaValidare.Password)
            {
                utente = utenteDaValidare;
                utenteDaValidare.TentativiDiAccessoErrati++;
                if (utenteDaValidare.Bloccato)
                {
                    return EsitoLogin.AccountBloccato;
                }
                return EsitoLogin.PasswordErrata;
            }
            else
            {
                utente = utenteDaValidare;
                if (utenteDaValidare.Bloccato)
                {
                    return EsitoLogin.AccountBloccato;
                }
                utenteDaValidare.TentativiDiAccessoErrati = 0;
                return EsitoLogin.AccessoConsentito;
            }
        }
    }
}
