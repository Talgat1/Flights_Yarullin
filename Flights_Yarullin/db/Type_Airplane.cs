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
    
    public partial class Type_Airplane
    {
        public Type_Airplane()
        {
            this.Airplane = new HashSet<Airplane>();
        }
    
        public int Id_type { get; set; }
        public string Type_airplane1 { get; set; }
    
        public virtual ICollection<Airplane> Airplane { get; set; }
    }
}
