//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UP_Gubaidullin.ModelDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class DepartmentHeads
    {
        public int ID_DepartmentHead { get; set; }
        public Nullable<int> Seniority { get; set; }
    
        public virtual Employees Employees { get; set; }
    }
}