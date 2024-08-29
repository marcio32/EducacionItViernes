using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class EncryptHelper
    {

        private static string hash
        {

            get
            {
                return "b14ca5898a4e4133bbce2ea2315a1918";
            }

        }

        // Paso 1: Crear una funcion para encriptar la clave
        public static string Encriptar(string clave)
        {
            //Paso 2: Crear una instancia del algoritmo AES usando using para liberar recursos en memoria una vez que finaliza
            using (var aes = Aes.Create())
            {
                //paso 3: Establecemos la clave de la encriptacion
                aes.Key = Encoding.UTF8.GetBytes(hash);
                //paso 4: Establecemos el vector de inicializacion
                aes.IV = new byte[16];

                //paso 5: Creamos el encritpador con la clave y el IV establecidos
                var encriptador = aes.CreateEncryptor(aes.Key, aes.IV);

                //paso 6: Creamos un MemoryStream para almacenar los datos encriptados
                using (var ms = new MemoryStream())
                {  //paso 7: Creamos un CryptoStream que encripta los datos que se esriben en el CryptoStream
                    using (var cryptoStream = new CryptoStream(ms, encriptador, CryptoStreamMode.Write))
                    {
                        //paso 8: Creamos un StreamWriter para escribir la cadena clave en el StreamWriter
                        using (var sw = new StreamWriter(cryptoStream))
                        {
                            //paso 9: Escribo la clave en el streamWriter
                            sw.Write(clave);
                        }
                        //paso 10: Convierte todo el contenido de MemoryStream a un arreglo de bytes que luego lo retornamos como un string convertido.
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }
    }
}
