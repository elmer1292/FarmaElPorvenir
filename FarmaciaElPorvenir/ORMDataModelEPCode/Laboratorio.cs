﻿using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace FarmaciaElPorvenir.el_porvenirdb
{

    public partial class Laboratorio
    {
        public Laboratorio(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
