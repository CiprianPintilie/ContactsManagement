﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class CompanyEntity
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Vat { get; set; }
        [Required]
        public string MainCountry { get; set; }
        [Required]
        public string MainCity { get; set; }
        [Required]
        public int MainPostCode { get; set; }
        [Required]
        public string MainStreet { get; set; }
        [Required]
        public int MainStreetNumber { get; set; }

        public ICollection<ContactCompanyEntity> ContactCompanies { get; set; }
        public ICollection<CompanyAddressEntity> Addresses { get; set; }
    }
}
