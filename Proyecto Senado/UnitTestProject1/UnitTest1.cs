using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ExceptionSerializacion()
        {
            try
            { 
                Votacion votacion = new Votacion();
                SerializarXML xml = new SerializarXML();
                xml.Guardar("", votacion);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ErrorArchivoException));
            }
        }

        private static int cont = 0;

        [TestMethod]
        public void CantidadEventos()
        {
            Dictionary<string, Votacion.EVoto> senadores = new Dictionary<string, Votacion.EVoto>();
            senadores.Add("1", Votacion.EVoto.Abstencion);
            senadores.Add("2", Votacion.EVoto.Afirmativo);

            Votacion votacion = new Votacion("TestUnitario", senadores);
            votacion.EventoVotoEfectuado += new Voto(Contador);
            votacion.Simular();

            Assert.AreEqual(cont, senadores.Count);
        }

        public static void Contador(string senador, Votacion.EVoto voto)
        {
            cont += 1;
        }
    }
}
