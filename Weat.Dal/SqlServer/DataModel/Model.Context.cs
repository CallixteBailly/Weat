﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Weat.Dal.SqlServer.DataModel
{
    using Entities.DataModel;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class WeatEntities : DbContext
    {
        public WeatEntities()
            : base("name=WeatEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<FRIDGE> FRIDGEs { get; set; }
        public virtual DbSet<FRIDGEINGREDIENT> FRIDGEINGREDIENTs { get; set; }
        public virtual DbSet<INGREDIENT> INGREDIENTs { get; set; }
        public virtual DbSet<PERSON> People { get; set; }
        public virtual DbSet<PLANNING> PLANNINGs { get; set; }
        public virtual DbSet<RECIPE> RECIPEs { get; set; }
        public virtual DbSet<STEPRECIPE> STEPRECIPEs { get; set; }
        public virtual DbSet<TYPEFRIDGE> TYPEFRIDGEs { get; set; }
        public virtual DbSet<TYPEINGREDIENT> TYPEINGREDIENTs { get; set; }
        public virtual DbSet<TYPERECIPE> TYPERECIPEs { get; set; }
    }
}
