//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Flights_Yarullin.db
{
    using System;
    using System.Collections.Generic;
    
    public partial class Airline
    {
        public Airline()
        {
            this.Flight = new HashSet<Flight>();
        }
    
        public int Id_airline { get; set; }
        public string Name_arline { get; set; }
        public string Phone { get; set; }
    
        public virtual ICollection<Flight> Flight { get; set; }
    }
}