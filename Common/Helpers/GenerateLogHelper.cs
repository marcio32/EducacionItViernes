using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public static class GenerateLogHelper
    {

        public static async Task LogError(Exception ex)
        {
            var path = string.Format(@"C:\Logs\{0:dd-MM-yyyy}", DateTime.Now);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var file = string.Format(@"{0}\{1:dd-MM-yyyy}.txt", path, DateTime.Now);

            var contenido = $"============================================================================================================================================================================================================================================\n" +
                            $"--------------------------------------------------------------------------------------------------------{DateTime.Now:dd/MM/yyyy HH:mm:ss}-----------------------------------------------------------------------------------------------------------------\n" +
                            $"Proyecto: {ex.Source}\n" +
                            $"Error: {ex.Message}\n" +
                            $"Ubicacion: {ex.StackTrace}\n" +
                            $"============================================================================================================================================================================================================================================\n\n";

           await File.AppendAllTextAsync(file, contenido);
        }
    }
}
