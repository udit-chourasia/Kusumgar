//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KusumgarDatabaseEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class IndustrialMaster
    {
        public int IndustrialMasterId { get; set; }
        public int IndustrialCategoryId { get; set; }
        public int IndustrialGroupId { get; set; }
        public string IndustrialSubGrpName { get; set; }
        public string Size { get; set; }
        public string COD { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDtm { get; set; }
        public int UpdatedBy { get; set; }
        public System.DateTime UpdatedDtm { get; set; }
    }
}
