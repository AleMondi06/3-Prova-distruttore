using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Prova_distruttore
{
    internal class Program
    {
        static void Main()
        {
            // Creazione di un'istanza della classe "Esempio"
            using (Ex esempio = new Ex("Ciao", 10))
            {
                // Utilizzo dell'istanza
                Console.WriteLine("Stringa: {0}, Numero: {1}", esempio.GetStringa(), esempio.GetNumero());
            } // Qui verrà chiamato automaticamente Dispose() quando esce dal blocco using

            // Chiamata esplicita al Garbage Collector
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.ReadLine();
        }
        class Ex : IDisposable
    {
        private string Stringa;
        private int Numero;

        // Costruttore
        public Ex(string IStringa, int INumero)
        {
            Stringa = IStringa;
            Numero = INumero;
            Console.WriteLine("Oggetto creato. Stringa: {0}, Numero: {1}", Stringa, Numero);
        }

        // Metodo accessor per la stringa
        public string GetStringa()
        {
            return Stringa;
        }

        // Metodo accessor per il numero
        public int GetNumero()
        {
            return Numero;
        }

        // Metodo Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Distruttore
        ~Ex()
        {
            Dispose(false);
        }

        // Implementazione del metodo Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Rilascia le risorse gestite
                Console.WriteLine("Risorse gestite rilasciate.");
            }

            // Rilascia le risorse non gestite
            Console.WriteLine("Risorse non gestite rilasciate.");
        }
    }

    }
}
