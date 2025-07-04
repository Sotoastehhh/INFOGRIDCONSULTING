﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PAGINA.Models;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services.Description;

namespace PAGINA.Controllers
{
    public class AccesoController : Controller {
        
        static string KERLY6Entities = " Data Source=DESKTOP-AVQDB47;Initial Catalog=KERLY6;Integrated Security=True";


        // GET: Acceso
        public ActionResult Login()
    {
        return View();
    }

    // Esto es un cambio de prueba para CI/CD

    public ActionResult Registrar()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Registrar(Usuario oUsuario)
    {
        bool registrado;
        string mensaje;

        if (oUsuario.Clave == oUsuario.ConfirmarClave) {


            oUsuario.Clave = ConvertirSha256(oUsuario.Clave);
       
                
        }else
        {
            ViewData["mensaje"] = "las contraseñas no coiniden";
            return View();
        }
            using (SqlConnection cn = new SqlConnection(KERLY6Entities)) {

                SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", cn);
                cmd.Parameters.AddWithValue("Correo", oUsuario.Correo);
                cmd.Parameters.AddWithValue("Clave", oUsuario.Clave);
                cmd.Parameters.Add("Registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                cmd.ExecuteNonQuery();

                registrado = Convert.ToBoolean(cmd.Parameters["Registrado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();






            }

            ViewData["Mensaje"] = mensaje;
            if (registrado)
            {
                return RedirectToAction("Login", "Acceso");
            }   else
            {
                return View();
            }
                  
    }
        [HttpPost]
        public ActionResult Login(Usuario oUsuario)
        {
            oUsuario.Clave = ConvertirSha256(oUsuario.Clave);
            using (SqlConnection cn = new SqlConnection(KERLY6Entities))
            {

                SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", cn);
                cmd.Parameters.AddWithValue("Correo", oUsuario.Correo);
                cmd.Parameters.AddWithValue("Clave", oUsuario.Clave);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                    
                oUsuario.IdUsuario = Convert.ToInt32 (cmd.ExecuteScalar().ToString());

            

            }
            if (oUsuario.IdUsuario  != 0) {
                Session["Usuario"] = oUsuario;
                return RedirectToAction("Index","Home");

            }else
            {
                ViewData["mensaje"] = "Usuario no encontrado";
                return View();
            }

            
        }

        public static string ConvertirSha256(string texto)
        {
            //using System.Text;
            //USAR LA REFERENCIA DE "System.Security.Cryptography"

            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();

        }
            
        

    }
}
