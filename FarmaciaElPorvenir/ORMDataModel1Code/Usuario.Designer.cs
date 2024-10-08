﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace FarmaciaElPorvenir.Database
{

    [Persistent(@"usuario")]
    public partial class Usuario : XPLiteObject
    {
        int fId;
        [Key(true)]
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue<int>(nameof(Id), ref fId, value); }
        }
        string fUsuario1;
        [Indexed(Name = @"usuario_UNIQUE", Unique = true)]
        [Size(50)]
        [Persistent(@"usuario")]
        public string Usuario1
        {
            get { return fUsuario1; }
            set { SetPropertyValue<string>(nameof(Usuario1), ref fUsuario1, value); }
        }
        string fPass;
        [Size(50)]
        [Persistent(@"pass")]
        public string Pass
        {
            get { return fPass; }
            set { SetPropertyValue<string>(nameof(Pass), ref fPass, value); }
        }
        Empleado fId_Empleado;
        [Association(@"UsuarioReferencesEmpleado")]
        public Empleado Id_Empleado
        {
            get { return fId_Empleado; }
            set { SetPropertyValue<Empleado>(nameof(Id_Empleado), ref fId_Empleado, value); }
        }
        Rol fId_Rol;
        [Association(@"UsuarioReferencesRol")]
        public Rol Id_Rol
        {
            get { return fId_Rol; }
            set { SetPropertyValue<Rol>(nameof(Id_Rol), ref fId_Rol, value); }
        }
    }

}
