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
    
    public partial class Exams
    {
        public int ID_Exam { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> ID_Discipline { get; set; }
        public Nullable<int> ID_Student { get; set; }
        public Nullable<int> ID_Educator { get; set; }
        public string Audience { get; set; }
        public Nullable<int> Appraisal { get; set; }
    
        public virtual Disciplines Disciplines { get; set; }
        public virtual Employees Employees { get; set; }
        public virtual Students Students { get; set; }
    }
}
