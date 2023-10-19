using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat1
{
    internal class Utente
    {
        public Utente(string username, string password, bool bloccato, int IdBancaCorrente) {
            Username = username;
            Password = password;
            Bloccato = bloccato;
            IdBanca =  IdBancaCorrente;
        
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Tentativi { get; set; }
        public bool Bloccato = false;
        public int IdBanca {  get; set; }
        public DateTime DataBlocco { get; set; }



        public bool ControlloSeBloccato()
        {
            if(Bloccato)
            {
                if((DateTime.Now - DataBlocco).TotalDays <30) { return true; }
                return true;
            }
            return false;
        }

        public bool CheckPassword(string password)
        {
            if(ControlloSeBloccato())
            {
                return false;
            }
            if (Password == password)
            {
                return true;
            }
            Tentativi += 1;
            if(Tentativi == 3)
            {
                Bloccato = true;
            }
            return false;
        }
        //private const int _tentativiDiAccessoPermessi = 3;
        //private ContoCorrente _contoCorrente;
        //public string NomeUtente { get => username; set => username = value; }
        //public string Password { get => password; set => password = value; }
        //public bool Bloccato { get => bloccato; }

        //public ContoCorrente contoCorrente { get => _contoCorrente; set => _contoCorrente = value; }

        //public int TentativiDiAccessoResidui
        //{
        //    get
        //    {
        //        return _tentativiDiAccessoPermessi - _tentativiDiAccessoErrati;
        //    }
        //}
        //public int TentativiDiAccessoErrati
        //{
        //    get => _tentativiDiAccessoErrati;
        //    set
        //    {
        //        _tentativiDiAccessoErrati = value;
        //        if (_tentativiDiAccessoErrati >= _tentativiDiAccessoPermessi)
        //        {
        //            _bloccato = true;
        //        }
        //    }
        //}
    }
}

