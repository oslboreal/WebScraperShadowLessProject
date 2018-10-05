using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Threading;

namespace AMF
{
    public class ServicioTestCodigo
    {
        public static Uri MainUrl { get; } = new Uri("http://addmefast.com");
        public static Dictionary<string, string> values;
        public static Dictionary<string, string> parametrosAjax;

        static ServicioTestCodigo()
        {
            values = new Dictionary<string, string>();
            parametrosAjax = new Dictionary<string, string>();
            #region MyRegion
            values.Add("email", "oslboreal@gmail.com");
            values.Add("password", "mamadera223");
            values.Add("login_button", "Login");
            #endregion

            parametrosAjax.Add("act", "getYoutubeVideos");
            parametrosAjax.Add("params", "{\"network\":\"5\", \"page\":\"1\"}");
        }

        // Test asincronismo.
        public static async void Proceso()
        {
            using (HttpClient temporal = new HttpClient())
            {
                // Configuramos el DefaultrequestHeader.
                temporal.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36");

                FormUrlEncodedContent content = new FormUrlEncodedContent(values);
                var consulta = temporal.PostAsync(MainUrl, content);
                consulta.Wait();
                var respuesta = consulta.Result.Content.ReadAsStringAsync();
                respuesta.Wait();
                Console.WriteLine(consulta.Result.RequestMessage.RequestUri.AbsoluteUri);
                // Caemos en Welcome.
                Console.ReadLine();
                consulta = temporal.GetAsync(new Uri("http://addmefast.com/free_points/youtube_views"));
                Console.WriteLine(consulta.Result.StatusCode + "Youtube Views");
                Console.ReadLine();
                var contenidoAjax = new FormUrlEncodedContent(parametrosAjax);
                consulta = temporal.PostAsync(new Uri("http://addmefast.com/includes/ajax.php"), contenidoAjax);
                consulta.Wait();
                string web = await consulta.Result.Content.ReadAsStringAsync();
                var arreglo = web.Split('\'');
                var token = arreglo[3];
                Console.WriteLine(token);
                consulta = temporal.GetAsync(new Uri($"http://addmefast.com/getUrl.php?i={token}"));
                consulta.Wait();
                Console.WriteLine(await consulta.Result.Content.ReadAsStringAsync());
                Thread.Sleep(5000);
                Console.WriteLine(await consulta.Result.Content.ReadAsStringAsync());
                Console.ReadLine();
                // Corroborar como ADDMEFAST Logra obtener el control de la ventana.
                
            }   
        }

    }
}