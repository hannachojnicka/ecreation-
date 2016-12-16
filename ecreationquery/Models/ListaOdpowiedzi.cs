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

        public string odpowiedz { get; set; }

        public string IP { get; set; }

        public int liczbaOdpowiedzi { get; set; }

        public int? ListaAnkiet_id { get; set; }

        public virtual ListaAnkiet ListaAnkiet { get; set; }
    }
}
