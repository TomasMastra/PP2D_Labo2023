using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Net.Http.Json;
using System.Xml;
using System.Reflection.Emit;



namespace Clases
{
    public class Archivos<T>
    {
        public static string SerializarJson<T>(T datos)//VER
        {
            JsonSerializerOptions opciones = new JsonSerializerOptions();

            opciones.WriteIndented = true;//meter en constructor

            string json = JsonSerializer.Serialize(datos, opciones);
            return json;
        }

        public static T DeserializarJson(string json)
        {
            T datos = JsonSerializer.Deserialize<T>(json);
            return datos;
        }

        public static string SerializarXml<T>(T datos)//VER <T>
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            try
            {
                using (StringWriter writer = new StringWriter())
                {
                    serializer.Serialize(writer, datos);
                    return writer.ToString();
                }
            }
            catch(Exception ex)
            {
                return default(string);

            }
        }

        public static T DeserializarXml(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(xml))
            {
                T datos = (T)serializer.Deserialize(reader);
                return datos;
            }
        }

        public static string GuardarEnArchivoJson(string path, T datos)
        {
            try
            {
                string json = SerializarJson(datos);
                File.WriteAllText(path, json);
                Console.WriteLine("Datos guardados en archivo JSON.");
                return json;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar en archivo JSON: {ex.Message}");
                return default(string);

            }
        }

        public static T CargarDesdeArchivoJson(string path)
        {
            try
            {
                string json = File.ReadAllText(path);
                Console.WriteLine($"Tipo de datos utilizados en la deserialización: {typeof(T)}");

                return DeserializarJson(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar desde archivo JSON: {ex.Message}");
                return default(T);
            }
        }

        public static string GuardarEnArchivoXml(string path, T datos)
        {
            try
            {
                string xml = SerializarXml(datos);
                File.WriteAllText(path, xml);
                return xml;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error al guardar en archivo XML: {ex.Message}");
                return default(string);
                    
            }
        }

        public static T CargarDesdeArchivoXml(string path)
        {
            try
            {
                string xml = File.ReadAllText(path);
                Console.WriteLine("Datos guardados en archivo XML.");

                return DeserializarXml(xml);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar desde archivo XML: {ex.Message}");
                return default(T);

            }
        }

        public static void GuardarEnArchivoTxt(string path, T dato)
        {
            try
            {
                string contenido = dato.ToString();
                File.WriteAllText(path, contenido);
                Console.WriteLine("Datos guardados en archivo TXT");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar en archivo TXT: {ex.Message}");
            }
        }

        public static T CargarDesdeArchivoTxt(string path)
        {
            try
            {
                string contenido = File.ReadAllText(path);
                return ConvertirTextoAContenido(contenido); // Convierte el texto a un objeto del tipo T
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar desde archivo TXT: {ex.Message}");
                return default(T);
            }
        }

        public static T ConvertirTextoAContenido(string texto)
        {
            T contenido;

            try
            {
                contenido = DeserializarJson(texto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al convertir texto a contenido: {ex.Message}");
                contenido = default(T);
            }

            return contenido;
        }

        public void MostrarLista(List<T> listaDato)
        {
            {
                foreach (T item in listaDato)
                {
                    Console.WriteLine(item);
                }
            }
        }

    }

}
