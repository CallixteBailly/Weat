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
    
    public partial class FRIDGE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FRIDGE()
        {
            this.FRIDGEINGREDIENTs = new HashSet<FRIDGEINGREDIENT>();
        }
    
        public short IDFRIDGE { get; set; }
        public string CODETYPEFRIDGE { get; set; }
        public short IDUSER { get; set; }
        public string NAMEFRIDGE { get; set; }
    
        public virtual PERSON PERSON { get; set; }
        public virtual TYPEFRIDGE TYPEFRIDGE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FRIDGEINGREDIENT> FRIDGEINGREDIENTs { get; set; }
    }
}
