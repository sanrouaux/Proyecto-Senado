using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Votacion
    {
        public event Voto EventoVotoEfectuado;

        public enum EVoto { Afirmativo, Negativo, Abstencion, Esperando }

        private string nombreLey;
        private Dictionary<string, EVoto> senadores;
        private short contadorAfirmativo;
        private short contadorNegativo;
        private short contadorAbstencion;

        public string NombreLey { get { return this.nombreLey; } set { this.nombreLey = value; } }
        //public Dictionary<string, EVoto> Senadores { get { return this.senadores; } set { this.senadores = value; } }
        public short ContadorAfirmativo { get { return this.contadorAfirmativo; } set { this.contadorAfirmativo = value; } }
        public short ContadorNegativo { get { return this.contadorNegativo; } set { this.contadorNegativo = value; } }
        public short ContadorAbstencion { get { return this.contadorAbstencion; } set { this.contadorAbstencion = value; } }

        public Votacion() { }

        public Votacion(string nombreLey, Dictionary<string, EVoto> senadores)
        {
            this.nombreLey = nombreLey;
            this.senadores = senadores;
        }

        public void Simular()
        {
            // Reseteo contadores
            this.contadorAbstencion = 0;
            this.contadorAfirmativo = 0;
            this.contadorNegativo = 0;
            // Itero todos los Senadores
            for (int index = 0; index < this.senadores.Count; index++)
            {
                // Duermo el hilo
                System.Threading.Thread.Sleep(100);

                // Leo el senador actual
                KeyValuePair<string, EVoto> k = this.senadores.ElementAt(index);
                // Generador de número aleatorio
                Random r = new Random(k.Key.ToString().Length + DateTime.Now.Millisecond);
                // Modifico el voto de forma aleatoria
                this.senadores[k.Key] = (EVoto)r.Next(0, 3);
                
                // Invocar Evento
                this.EventoVotoEfectuado(k.Key, senadores[k.Key]);
                
                // Incrementar contadores
                if(this.senadores[k.Key] == EVoto.Afirmativo)
                    this.contadorAfirmativo += 1;
                else if (this.senadores[k.Key] == EVoto.Negativo)
                    this.contadorNegativo += 1;
                else if (this.senadores[k.Key] == EVoto.Abstencion)
                    this.contadorAbstencion += 1;
            }
        }
    }
}
