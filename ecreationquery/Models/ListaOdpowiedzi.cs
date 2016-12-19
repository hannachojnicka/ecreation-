namespace ecreationquery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ListaOdpowiedzi
    {
       
        public int id { get; set; }
        [Required]
        public string odpowiedz { get; set; }

        public string IP { get; set; }

        public int liczbaOdpowiedzi { get; set; }

      
       public virtual ListaPytan listaPytans { get; set; }
    }
}
