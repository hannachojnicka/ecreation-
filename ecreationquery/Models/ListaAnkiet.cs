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
            ListaPytans = new HashSet<ListaPytan>();
      
        }

        public int id { get; set; }
        [Required]
        public string nazwaAnkiety { get; set; }

        public DateTime dataDodania { get; set; }

        public  Nullable<DateTime> dataZakonczenia { get; set; }

        public bool Aktywna { get; set; }

        public int liczbaAnkietowanych { get; set; }


        public string nazwaUzytko { get; set; }
  
        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListaPytan> ListaPytans { get; set; }
     
    }

    public partial class RodzajAnkiet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RodzajAnkiet()
        {
            listaPytans = new HashSet<ListaPytan>();

        }
        public int id { get; set; }
        [Required]
        public string nazwa { get; set; }
        public virtual ICollection<ListaPytan> listaPytans { get; set; }


    }
    public partial class ListaPytan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ListaPytan()
        {
            listaOdpowiedzis = new HashSet<ListaOdpowiedzi>();

        }
        public int id { get; set; }
        [Required]
        public string Pytanie { get; set; }
        public RodzajAnkiet RodzajAnkiet { get; set; }
        public virtual ListaAnkiet ListaAnkiet { get; set; }
        public virtual ICollection<ListaOdpowiedzi> listaOdpowiedzis { get; set; }

    }
}
