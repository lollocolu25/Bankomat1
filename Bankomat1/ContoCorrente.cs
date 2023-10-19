using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat1
{
    internal class ContoCorrente
    {
        private double _saldo;
        private long _idContoCorrente;
        private DateTime _dataUltimoVersamento;

        public ContoCorrente()
        {
            DateTime date = DateTime.Now;
            _dataUltimoVersamento = date.AddDays(-1);
        }

        public struct DatiReport
        {
            public double saldo;
            public DateTime dataUltimoVersamento;
            public DateTime dataCorrente;
        }

        public double Saldo { get => _saldo; set => _saldo = value; }

        public long IdContoCorrente { get => _idContoCorrente; set => _idContoCorrente = value; }
    }
}
