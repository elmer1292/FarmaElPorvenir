using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace FarmaciaElPorvenir.el_porvenirdb
{

    public partial class Medicamento
    {
        public Medicamento(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
