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

    [Persistent(@"producto")]
    public partial class Producto : XPLiteObject
    {
        int fId;
        [Key(true)]
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue<int>(nameof(Id), ref fId, value); }
        }
        string fMedicamento;
        [Size(50)]
        public string Medicamento
        {
            get { return fMedicamento; }
            set { SetPropertyValue<string>(nameof(Medicamento), ref fMedicamento, value); }
        }
        Categoria fId_Categoria;
        [Association(@"ProductoReferencesCategoria")]
        public Categoria Id_Categoria
        {
            get { return fId_Categoria; }
            set { SetPropertyValue<Categoria>(nameof(Id_Categoria), ref fId_Categoria, value); }
        }
        float fPrecio_Compra;
        public float Precio_Compra
        {
            get { return fPrecio_Compra; }
            set { SetPropertyValue<float>(nameof(Precio_Compra), ref fPrecio_Compra, value); }
        }
        float fPrecio_Venta;
        public float Precio_Venta
        {
            get { return fPrecio_Venta; }
            set { SetPropertyValue<float>(nameof(Precio_Venta), ref fPrecio_Venta, value); }
        }
        float fDescuento;
        public float Descuento
        {
            get { return fDescuento; }
            set { SetPropertyValue<float>(nameof(Descuento), ref fDescuento, value); }
        }
        int fStock;
        public int Stock
        {
            get { return fStock; }
            set { SetPropertyValue<int>(nameof(Stock), ref fStock, value); }
        }
        DateTime fVencimiento;
        public DateTime Vencimiento
        {
            get { return fVencimiento; }
            set { SetPropertyValue<DateTime>(nameof(Vencimiento), ref fVencimiento, value); }
        }
        Proveedor fId_Proveedor;
        [Association(@"ProductoReferencesProveedor")]
        public Proveedor Id_Proveedor
        {
            get { return fId_Proveedor; }
            set { SetPropertyValue<Proveedor>(nameof(Id_Proveedor), ref fId_Proveedor, value); }
        }
        Laboratorio fId_Laboratorio;
        [Association(@"ProductoReferencesLaboratorio")]
        public Laboratorio Id_Laboratorio
        {
            get { return fId_Laboratorio; }
            set { SetPropertyValue<Laboratorio>(nameof(Id_Laboratorio), ref fId_Laboratorio, value); }
        }
        [Association(@"DetallecompraReferencesProducto")]
        public XPCollection<Detallecompra> Detallecompras { get { return GetCollection<Detallecompra>(nameof(Detallecompras)); } }
        [Association(@"DetalleventaReferencesProducto")]
        public XPCollection<Detalleventa> Detalleventas { get { return GetCollection<Detalleventa>(nameof(Detalleventas)); } }
    }

}
