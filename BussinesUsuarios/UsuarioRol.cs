﻿namespace BussinesUsuarios
{
    public class UsuarioRol : IUsuarioROL
    {
        Singleton S = Singleton.GetInstance;

        public Usuario Usuario { get ; set ; }
        public string Rol { get; set; }
        public int ID { get ; set ; }

        public void Add()
        {
            S.ISUR.Add(this);
        }

        public void Erase()
        {
            S.ISUR.Erase(this);
        }

        public string Find()
        {
            return S.ISUR.Find(this);
        }

        public string ListRolesByUsurio()
        {
            return S.ISUR.ListRolesByUsuario(this);
        }
        public string ListUsuariosByRol()
        {
            throw new System.NotImplementedException();
        }
        public void Modify()
        {
            throw new System.NotImplementedException();
        }
    }
}
