//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace KuasRepair.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Sort
    {
        public Sort()
        {
            this.Repair = new HashSet<Repair>();
        }
        [Display(Name = "ID")]
        public int Sort_ID { get; set; }
        [Display(Name = "類型")]
        public string Sort_Name { get; set; }

        public virtual ICollection<Repair> Repair { get; set; }
    }
}
