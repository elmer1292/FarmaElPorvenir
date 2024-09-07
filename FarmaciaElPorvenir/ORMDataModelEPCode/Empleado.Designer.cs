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
namespace FarmaciaElPorvenir.el_porvenirdb
{

    [Persistent(@"empleado")]
    public partial class Empleado : XPLiteObject
    {
        int fId;
        [Key(true)]
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue<int>(nameof(Id), ref fId, value); }
        }
        string fNombre_Completo;
        [Size(50)]
        public string Nombre_Completo
        {
            get { return fNombre_Completo; }
            set { SetPropertyValue<string>(nameof(Nombre_Completo), ref fNombre_Completo, value); }
        }
        string fCargo;
        [Size(50)]
        public string Cargo
        {
            get { return fCargo; }
            set { SetPropertyValue<string>(nameof(Cargo), ref fCargo, value); }
        }
        [Association(@"Factura_compraReferencesEmpleado")]
        public XPCollection<Factura_compra> Factura_compras { get { return GetCollection<Factura_compra>(nameof(Factura_compras)); } }
        [Association(@"Factura_ventaReferencesEmpleado")]
        public XPCollection<Factura_venta> Factura_ventas { get { return GetCollection<Factura_venta>(nameof(Factura_ventas)); } }
        [Association(@"UsuarioReferencesEmpleado")]
        public XPCollection<Usuario> Usuarios { get { return GetCollection<Usuario>(nameof(Usuarios)); } }
    }

}
