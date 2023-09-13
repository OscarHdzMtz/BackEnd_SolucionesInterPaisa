using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_SolucionesInterPaisa.Controllers
{
    public class Utilerias
    {

        public string ipMKT = "192.168.1.72";
        public string userMKT = "admin";
        public string passwordMKT = "123";
        //GENERA EL USUARIO DE ACUERDO A LA CONFIGURACION QUE VIENE DE FRONT
        public string cadenaAleatoriaUsers(int LongitudUserFichas, string tipoUsuarioGenerarFichas)
        {
            var characters = "";
            if (tipoUsuarioGenerarFichas == "Letras")
            {
                characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ9";
            }
            if (tipoUsuarioGenerarFichas == "Numeros")
            {
                characters = "0123456789";
            }
            if (tipoUsuarioGenerarFichas == "Letras y numeros")
            {
                characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ90123456789";
            }

            var Charsarr = new char[LongitudUserFichas];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            var resultString = new String(Charsarr);
            return resultString;
        }
        //GENERA EL CONTRASEÑA DE ACUERDO A LA CONFIGURACION QUE VIENE DE FRONT
        public string cadenaAleatoriaPassword(int valorLongPassFichas, string tipoPasswordGenerarFichas)
        {
            var characters = "";
            if (tipoPasswordGenerarFichas == "Letras")
            {
                characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZAEIOU";
            }
            if (tipoPasswordGenerarFichas == "Numeros")
            {
                characters = "0123456789876543210";
            }
            if (tipoPasswordGenerarFichas == "Letras y numeros")
            {
                characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ90123456789";
            }

            var Charsarr = new char[valorLongPassFichas];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            var resultString = new String(Charsarr);
            return resultString;
        }     
    }
}
