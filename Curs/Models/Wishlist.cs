//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Curs.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Wishlist
    {
        public int IdCard { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Date { get; set; }
        public Nullable<int> IdGenre { get; set; }
    
        public virtual Genres Genres { get; set; }
    }
}
