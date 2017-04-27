using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

            throw new DivideByZeroException();
        }

        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            var error = new Tracto.Apm.TractoException((Exception)e.ExceptionObject)
            {
                Configuration = new Tracto.Apm.Models.Configuration()
                {
                    PublicKey = "in5rNd0SzTz5gkFsCmJy3woGDsuhj7UC",
                    PrivateKey = "6JjNKGC408r74urvoj75m7RiYwZNoikl",
                    Environment = "production",
                },
                ApplicationName = "tkbs.odtuteknokent.com.tr",
                User = new Tracto.Apm.Models.User()
                {
                    Name = "Baris Kalaycioglu",
                    Email = "baris@ydyazilim.com"
                }
            };

                var sonuc = JsonConvert.SerializeObject(error);
        }
    }
}
