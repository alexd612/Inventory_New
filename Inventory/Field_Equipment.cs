//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inventory
{
    using System;
    using System.Collections.Generic;
    
    public partial class Field_Equipment
    {
        public int Field_ID { get; set; }
        public int Equipment_ID { get; set; }
        public Nullable<int> Mouse_Count { get; set; }
        public Nullable<int> Monitor_Count { get; set; }
        public Nullable<int> Keyboard_Count { get; set; }
        public Nullable<int> Dock_Station_Count { get; set; }
        public string Printer { get; set; }
        public string Office_Location { get; set; }
    
        public virtual Equipment Equipment { get; set; }
    }
}
