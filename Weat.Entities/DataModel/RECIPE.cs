//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Weat.Entities.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class RECIPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RECIPE()
        {
            this.PLANNINGs = new HashSet<PLANNING>();
            this.STEPRECIPEs = new HashSet<STEPRECIPE>();
            this.People = new HashSet<PERSON>();
            this.INGREDIENTs = new HashSet<INGREDIENT>();
        }
    
        public short IDRECIPE { get; set; }
        public string CODETYPERECIPE { get; set; }
        public short IDUSER { get; set; }
        public string NAMERECIPE { get; set; }
    
        public virtual PERSON PERSON { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PLANNING> PLANNINGs { get; set; }
        public virtual TYPERECIPE TYPERECIPE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STEPRECIPE> STEPRECIPEs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PERSON> People { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INGREDIENT> INGREDIENTs { get; set; }
    }
}
