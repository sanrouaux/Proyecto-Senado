using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Entidades
{
    public class SerializarXML : IArchivo<Votacion>
    {
        public Votacion Leer(string rutaArchivo)
        {
            Votacion aux;
            try
            {                
                XmlSerializer xml = new XmlSerializer(typeof(Votacion));
                StreamReader sr = new StreamReader(rutaArchivo);
                aux = (Votacion)xml.Deserialize(sr);
                sr.Close();
            }
            catch (Exception)
            {
                throw new ErrorArchivoException();
            }
            return aux;
        }

        public bool Guardar(string rutaArchivo, Votacion objeto)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(Votacion));
                StreamWriter sw = new StreamWriter(rutaArchivo, true);
                xml.Serialize(sw, objeto);
                sw.Close();
                return true;
            }
            catch (Exception)
            {
                throw new ErrorArchivoException();
            }
        }
    }
}
