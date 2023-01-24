using System;
using System.Web.UI;
using BussinesSchool;


public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["accion"] != null)
        {
            switch (Request["accion"])
            {
                case "LOGIN": Login(); break;
                case "LOADUSUARIOS": LoadUsuarios(); break;
                case "ADDUSUARIO": AddUsuario(); break;
                case "ADDROL": AddRol(); break;
                case "DELROL": DeleteRol(); break;
                case "MODIFYUSERWITHROLES": ModifyUserWithRoles(); break;
                case "MODIFICARUSUARIO": ModificarUsuario(); break;
                case "ObtenerUserRol": ObtenerUserRol(); break;
                case "ELIMINARUSUARIO": EliminarUsuario(); break;
                case "FindUserRolByDni": FindUserRolByDni(); break;
                case "FindUserRolByMail": FindUserRolByMail(); break;
                case "RecoveryPassword": RecoveryPassword(); break;
                //CARRERAS  
                case "ADDCARRERA": AddCarrera(); break;
                case "LISTCARRERAS": ListCarrera(); break;
                case "MODIFYCARRERA": ModifyCarrera(); break;
            }
        }
    }

    private void ModifyCarrera()
    {
        Carrera carrera = new Carrera()
        {
            Nombre = Request["Nombre"],
            Duracion = int.Parse(Request["Duracion"]),
            Titulo = Request["Titulo"],
            Estado = Request["Estado"],
            Sigla = Request["Sigla"],
            ID = int.Parse(Request["ID"])
        };
        if (Request.Files.Count > 0)
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                if (Request.Files[i].FileName.EndsWith("pdf"))
                {
                    carrera.FUPdf = Request.Files[i];
                }
                else if (Request.Files[i].FileName.EndsWith("jpg"))
                {
                    carrera.Fu = Request.Files[i];
                }
            }
        }
        try
        {
            carrera.Modify();
            Response.Write("OK");
        }
        catch (Exception err)
        {
            Response.Write(err.Message);

        }
    }

    private void ListCarrera()
    {
        try
        {
            Carrera carrera = new Carrera();
            carrera.Estado = "ACTIVO";
            Response.Write(carrera.List());
        }
        catch (Exception err)
        {
            Response.Write(err.Message);
        }
    }

    private void AddCarrera()
    {
        Carrera car = new Carrera()
        {
            Nombre = Request["Nombre"],
            Titulo = Request["Titulo"],
            Sigla = Request["Sigla"],
            Estado = Request["Estado"],
            Duracion = int.Parse(Request["Duracion"])
        };

        if (Request.Files.Count > 0)
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                if (Request.Files[i].FileName.EndsWith("pdf"))
                {
                    car.FUPdf = Request.Files[i];
                }
                else if (Request.Files[i].FileName.EndsWith("jpg"))
                {
                    car.Fu = Request.Files[i];
                }
            }

        }
        try
        {
            car.Add();
            Response.Write("OK");
        }
        catch (Exception err)
        {
            Response.Write(err.Message);
        }
    }

    private void RecoveryPassword()
    {
        Usuario usuario = new Usuario()
        {
            Mail = Request["Mail"],
            Dni = int.Parse(Request["Dni"])
        };
        try
        {
            usuario.FindByMailAndDni(); //esto carga todos los datos en el objeto Usuario
            usuario.Password = usuario.Dni.ToString();
            usuario.Modify();
            Response.Write("OK");
        }
        catch (Exception err)
        {
            Response.Write(err.Message);
        }
    }

    private void FindUserRolByMail()
    {
        UsuarioRol usuarioRol = new UsuarioRol()
        {
            Usuario = new Usuario()
            {
                Mail = Request["Mail"]
            },
        };
        try
        {
            usuarioRol.Usuario.FindByMail();
            Response.Write(usuarioRol.ListRolesByUsurio());
        }
        catch (Exception err)
        {
            Response.Write(err.Message);
        }
    }

    private void FindUserRolByDni()
    {
        UsuarioRol usuarioRol = new UsuarioRol()
        {
            Usuario = new Usuario()
            {
                Dni = int.Parse(Request["Dni"])
            },
        };
        try
        {
            usuarioRol.Usuario.FindByDni();
            Response.Write(usuarioRol.ListRolesByUsurio());
        }
        catch (Exception err)
        {
            Response.Write(err.Message);
        }

    }

    private void EliminarUsuario()
    {
        Usuario usuario = new Usuario()
        {
            ID = int.Parse(Request["ID"])
        };
        try
        {
            usuario.Erase();
            Response.Write("OK");
        }
        catch (Exception err)
        {
            Response.Write(err.Message);
        }
    }

    private void ObtenerUserRol()
    {
        try
        {
            UsuarioRol usuarioRol = new UsuarioRol()
            {
                Usuario = new Usuario()
                {
                    ID = int.Parse(Request["ID"]),
                }
            };
            Response.Write(usuarioRol.ListRolesByUsurio());
        }
        catch (Exception err)
        {
            Response.Write(err.Message);
        }
    }

    private void ModificarUsuario()
    {
        try
        {
            Usuario usuario = new Usuario()
            {
                ID = int.Parse(Request["ID"]),
            };

            usuario.Find(); //cargo las propiedades que no se pueden modificar
            usuario.Nombre = Request["Nombre"];
            usuario.Direccion = Request["Direccion"];
            usuario.Telefono = Request["Telefono"];
            usuario.Password = Request["Password"];
            if (Request.Files.Count > 0) usuario.Fu = Request.Files[0];
            usuario.Modify();

            UsuarioRol usuarioRol = new UsuarioRol();
            usuarioRol.Usuario = usuario;
            Response.Write(usuarioRol.ListRolesByUsurio());
        }
        catch (Exception err)
        {
            Response.Write(err.Message);
        }
    }

    private void ModifyUserWithRoles()
    {
        Usuario usuario = new Usuario()
        {
            ID = int.Parse(Request["ID"]),
            Nombre = Request["Nombre"],
            Mail = Request["Mail"],
            Dni = int.Parse(Request["Dni"]),
            Direccion = Request["Direccion"],
            FechaNac = DateTime.Parse(Request["Fecha"]),
            Telefono = Request["Telefono"]
        };
        if (Request["Password"] != null)
        {
            usuario.Password = Request["Password"];
        }
        else
            usuario.Password = "";
        try
        {
            usuario.Modify();
            Response.Write("OK");
        }
        catch (Exception err)
        {
            Response.Write(err.Message);
        }
    }

    private void DeleteRol()
    {
        UsuarioRol UR = new UsuarioRol();
        UR.Usuario = new Usuario();
        UR.Usuario.ID = int.Parse(Request["UserID"]);
        UR.Rol = Request["Rol"];
        UR.Erase();

        Response.Write(UR.ListRolesByUsurio());
    }

    private void AddRol()
    {
        UsuarioRol UR = new UsuarioRol();
        UR.Usuario = new Usuario();
        UR.Usuario.ID = int.Parse(Request["UserID"]);
        UR.Rol = Request["Rol"];
        UR.Add();
        Response.Write(UR.ListRolesByUsurio());
    }

    private void AddUsuario()
    {
        try
        {
            Usuario usuario = new Usuario()
            {
                Nombre = Request["Nombre"],
                Mail = Request["Mail"],
                Dni = int.Parse(Request["Dni"]),
                Direccion = Request["Direccion"],
                FechaNac = DateTime.Parse(Request["Fecha"]),
                Telefono = Request["Telefono"],
                Password = Request["Dni"]
            };
            usuario.Add();
            UsuarioRol usuarioRol = new UsuarioRol()
            {
                Usuario = usuario,
            };
            Response.Write(usuarioRol.ListRolesByUsurio());
        }
        catch (Exception er)
        {
            Response.Write(er.Message);
        }
    }

    private void LoadUsuarios()
    {
        try
        {
            Response.Write(new Usuario().List());
        }
        catch (Exception er)
        {
            Response.Write(er.Message);
        }
    }

    private void Login()
    {
        UsuarioRol UR = new UsuarioRol()
        {
            Usuario = new Usuario()
            {
                Mail = Request["Mail"],
                Password = Request["Password"],
            }
        };
        UR.Usuario.Login();
        try
        {
            Response.Write(UR.ListRolesByUsurio());
        }
        catch (Exception err)
        {
            Response.Write(err.Message);
        }
    }

}