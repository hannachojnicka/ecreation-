namespace ecreationquery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ListaAnkiet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ListaAnkiet()
        {
            ListaOdpowiedzis = new HashSet<ListaOdpowiedzi>();
        }

        public int id { get; set; }

        public string nazwaAnkiety { get; set; }

        public DateTime dataDodania { get; set; }

        public DateTime dataZakonczenia { get; set; }

        public bool Aktywna { get; set; }

        public int liczbaAnkietowanych { get; set; }

        public string Pytanie { get; set; }

        public int idUzyt { get; set; }

        public string nazwaUzytko { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListaOdpowiedzi> ListaOdpowiedzis { get; set; }
    }
}
