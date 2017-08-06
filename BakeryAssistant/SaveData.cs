using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
namespace BakeryAssistant
{
    public class SaveData
    {
         public static void serialization(string nazwa_pliku, List<ProductsClass> z, string elementname)
        {
            XmlRootAttribute oRootAttr = new XmlRootAttribute();
            oRootAttr.ElementName = elementname;
            oRootAttr.IsNullable = true;
            XmlSerializer oSerializer = new XmlSerializer(typeof(List<ProductsClass>), oRootAttr);
            StreamWriter oStreamWriter = null;
            try
            {
                oStreamWriter = new StreamWriter(nazwa_pliku);
                oSerializer.Serialize(oStreamWriter, z);
            }
            catch (Exception oException)
            {
                Console.WriteLine("Aplikacja wygenerowała następujący wyjątek: " + oException.Message);
            }
            finally
            {
                if (null != oStreamWriter)
                {
                    oStreamWriter.Dispose();
                }
            }
        }
        public static void serialization(string nazwa_pliku, List<ComponentsInWarehouse> z, string elementname)
        {
            XmlRootAttribute oRootAttr = new XmlRootAttribute();
            oRootAttr.ElementName = elementname;
            oRootAttr.IsNullable = true;
            XmlSerializer oSerializer = new XmlSerializer(typeof(List<ComponentsInWarehouse>), oRootAttr);
            StreamWriter oStreamWriter = null;
            try
            {
                oStreamWriter = new StreamWriter(nazwa_pliku);
                oSerializer.Serialize(oStreamWriter, z);
            }
            catch (Exception oException)
            {
                Console.WriteLine("Aplikacja wygenerowała następujący wyjątek: " + oException.Message);
            }
            finally
            {
                if (null != oStreamWriter)
                {
                    oStreamWriter.Dispose();
                }
            }
        }
        public static void serialization(string nazwa_pliku, List<Order> z, string elementname)
        {
            XmlRootAttribute oRootAttr = new XmlRootAttribute();
            oRootAttr.ElementName = elementname;
            oRootAttr.IsNullable = true;
            XmlSerializer oSerializer = new XmlSerializer(typeof(List<Order>), oRootAttr);
            StreamWriter oStreamWriter = null;
            try
            {
                oStreamWriter = new StreamWriter(nazwa_pliku);
                oSerializer.Serialize(oStreamWriter, z);
            }
            catch (Exception oException)
            {
                Console.WriteLine("Aplikacja wygenerowała następujący wyjątek: " + oException.Message);
            }
            finally
            {
                if (null != oStreamWriter)
                {
                    oStreamWriter.Dispose();
                }
            }
        }

        public static void serialization(string nazwa_pliku, List<Login> z, string elementname)
        {
            XmlRootAttribute oRootAttr = new XmlRootAttribute();
            oRootAttr.ElementName = elementname;
            oRootAttr.IsNullable = true;
            XmlSerializer oSerializer = new XmlSerializer(typeof(List<Login>), oRootAttr);
            StreamWriter oStreamWriter = null;
            try
            {
                oStreamWriter = new StreamWriter(nazwa_pliku);
                oSerializer.Serialize(oStreamWriter, z);
            }
            catch (Exception oException)
            {
                Console.WriteLine("Aplikacja wygenerowała następujący wyjątek: " + oException.Message);
            }
            finally
            {
                if (null != oStreamWriter)
                {
                    oStreamWriter.Dispose();
                }
            }
        }
    }
}
