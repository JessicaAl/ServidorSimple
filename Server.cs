using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServidorSimple_171G0214
{
    public class Server
    {
        HttpListener servidor;
        public Server()
        {
            servidor = new HttpListener();
            servidor.Prefixes.Add("http://localhost/act1/");
        }

        private void Responses(IAsyncResult ar)
        { //método callback: se realiza en diferente tiempo a cuando se invocó
            var context = servidor.EndGetContext(ar);
            servidor.BeginGetContext(Responses, null);
            var peticion= context.Request;
            if (peticion.Url.LocalPath== "/act1/")
            {
                string res = "<h1>Desarrollo de aplicaciones Cliente/Servidor</h1> <p>Ing. H&eacutector Javier Padilla Lara <br/> " +
                     "<br/>Alumna: Jessica Gabriela Alarc&oacuten M&aacuterquez </p>";
                byte[] buffer = Encoding.UTF8.GetBytes(res);

                context.Response.ContentType = "text/html";
                context.Response.StatusCode = 200;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                context.Response.Close();
            }
            else if (peticion.Url.LocalPath == "/act1/fecha") 
            {
                string res = DateTime.Now.ToString();
                byte[] buffer = Encoding.UTF8.GetBytes(res);

               
                context.Response.StatusCode = 200;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                context.Response.Close();

            }
            else if (peticion.Url.LocalPath == "/act1/suma" && peticion.QueryString["a"]!=null
                && peticion.QueryString["b"]!=null)
            {
                int a= int.Parse(peticion.QueryString["a"]);
                int b= int.Parse(peticion.QueryString["b"]);
                int c = a + b;
                string res = $"{a} + {b} = {c} ";
                byte[] buffer = Encoding.UTF8.GetBytes(res);


                context.Response.StatusCode = 200;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                context.Response.Close();

            }
            else
            {
                context.Response.StatusCode = 404;
            }
            context.Response.Close();
        }

        public void Inicio()
        {

            servidor.Start();
            servidor.BeginGetContext(Responses, null);
        }
        public void Final()
        {
            servidor.Stop();
        }


    }
}
