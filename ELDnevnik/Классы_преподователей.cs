//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ELDnevnik
{
    using System;
    using System.Collections.Generic;
    
    public partial class Классы_преподователей
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Классы_преподователей()
        {
            this.Оценки = new HashSet<Оценки>();
        }
    
        public int ИД { get; set; }
        public Nullable<int> ИД_Преподователь { get; set; }
        public int ИД_Класс { get; set; }
        public int ИД_Предмет { get; set; }
    
        public virtual Класс Класс { get; set; }
        public virtual Предмет Предмет { get; set; }
        public virtual Преподователь Преподователь { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Оценки> Оценки { get; set; }
    }
}
