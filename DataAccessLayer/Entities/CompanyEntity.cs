﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class CompanyEntity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Vat { get; set; }

        public ICollection<ContactCompanyEntity> ContactCompanies { get; set; }
        public ICollection<CompanyAddressEntity> CompanyAddresses { get; set; }
    }
}
