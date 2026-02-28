using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Common.Domain;

namespace FiscalData.Domain
{
    public class FiscalDataObj : Entity<long>
    {
        private string _rfc;
        private string _reasonSocial;
        private string _address;
        private string _email;
        private string _regimen;
        private long _companyId;

        [JsonPropertyName("RFC")]
        public string RFC => _rfc;
        [JsonPropertyName("RazonSocial")]
        public string ReasonSocial => _reasonSocial;
        [JsonPropertyName("Direccion")]
        public string Address => _address;
        [JsonPropertyName("Email")]
        public string Email => _email;
        [JsonPropertyName("Regimen")]
        public string Regimen => _regimen;
        [JsonPropertyName("EmpresaId")]
        public long CompanyId => _companyId;

        private FiscalDataObj(long id)
        {
            Id = id;
            _rfc = string.Empty;
            _reasonSocial = string.Empty;
            _address = string.Empty;
            _email = string.Empty;
            _regimen = string.Empty;
            _companyId = 0;
        }

        public static FiscalDataObj Create(long id)
        {
            return new FiscalDataObj(id);
        }

        public FiscalDataObj SetInformationFiscal(string rfc, string razonSocial, string regimen) 
        {
            if (!string.IsNullOrWhiteSpace(rfc))
                _rfc = rfc;

            if (!string.IsNullOrWhiteSpace(razonSocial))
                _reasonSocial = razonSocial;

            if (!string.IsNullOrWhiteSpace(regimen))
                _regimen = regimen;
            return this;
        }

        public FiscalDataObj SetInformationLocation(string address)
        {
            if (!string.IsNullOrWhiteSpace(address))
                _address = address;
            return this;
        }

        public FiscalDataObj SetInformationContact(string email)
        {
            if (!string.IsNullOrWhiteSpace(email))
                _email = email;
            return this;
        }

        public FiscalDataObj SetInformationAditional(long companyId)
        {
            if(companyId > 0)
            {
                _companyId = companyId;
            }
            return this;
        }
    }
}
