﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;
using KusumgarDataAccess;

namespace KusumgarModel
{
   public class AttributeCodeManager
    {
        public List<AttributeCodeInfo> Get_Attribute_Codes(ref PaginationInfo pager)
        {
            List<AttributeCodeInfo> attributeCodes = new List<AttributeCodeInfo>();

            AttributeCodeRepo dRepo = new AttributeCodeRepo();

            attributeCodes = dRepo.Get_Attribute_Codes(ref pager);

            return attributeCodes;
       }

        public List<AttributeCodeInfo> Get_Attribute_Codes_By_Attribute_Name(int attributeId,ref PaginationInfo pager)
        {
            List<AttributeCodeInfo> attributeCodes = new List<AttributeCodeInfo>();

            AttributeCodeRepo dRepo = new AttributeCodeRepo();

            attributeCodes = dRepo.Get_Attribute_Codes_By_Attribute_Name(attributeId,ref pager);

            return attributeCodes;
        }

        public void Insert(AttributeCodeInfo attributeCode)
        {
            AttributeCodeRepo dRepo = new AttributeCodeRepo();
            
            dRepo.Insert(attributeCode);
        }

        public AttributeCodeInfo Get_Attribute_Code_By_Id(int attributeCodeId)
        {
            AttributeCodeInfo attributeCodeInfo = new AttributeCodeInfo();

            AttributeCodeRepo dRepo = new AttributeCodeRepo();

            attributeCodeInfo = dRepo.Get_Attribute_Code_By_Id(attributeCodeId);

            return attributeCodeInfo;
        }

        public void Update(AttributeCodeInfo attributeCode)
        {
            AttributeCodeRepo dRepo = new AttributeCodeRepo();

            dRepo.Update(attributeCode);
        }

        public List<AttributeCodeInfo> Get_Grid_By_Attrinute_Code_Name(int attributeId)
        {
            List<AttributeCodeInfo> attributeCodes = new List<AttributeCodeInfo>();

            AttributeCodeRepo dRepo = new AttributeCodeRepo();

            attributeCodes = dRepo.Get_Grid_By_Attrinute_Code_Name(attributeId);

            return attributeCodes;
        }
    }
}
