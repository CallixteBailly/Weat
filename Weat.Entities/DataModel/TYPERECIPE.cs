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
    
    public partial class TYPERECIPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TYPERECIPE()
        {
            this.RECIPEs = new HashSet<RECIPE>();
        }
    
        public string CODETYPERECIPE { get; set; }
        public string CAPTION { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RECIPE> RECIPEs { get; set; }
    }
}