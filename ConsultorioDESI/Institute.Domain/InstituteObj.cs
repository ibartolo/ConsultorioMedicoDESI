using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Institute.Domain
{
    public class InstituteObj : Entity<long>
    {
        private string _name;
        private string _numberOfEmployees;
        private string _phone1;
        private string _phone2;
        private string _email;
        private string _street;
        private string _interiorNumber;
        private string _exteriorNumber;
        private string _neighborhood;
        private string _delegation;
        private string _municipality;
        private string _state;
        private string _postalCode;
        private string _country;

        [JsonPropertyName("Nombre")]
        public string Name => _name;
        [JsonPropertyName("NumeroTrabajadores")]
        public string NumberOfEmployees => _numberOfEmployees;
        [JsonPropertyName("TelefonoL1")]
        public string Phone1 => _phone1;
        [JsonPropertyName("TelefonoL2")]
        public string Phone2 => _phone2;
        [JsonPropertyName("Email")]
        public string Email => _email;
        [JsonPropertyName("Calle")]
        public string Street => _street;
        [JsonPropertyName("NumeroInterior")]
        public string InteriorNumber => _interiorNumber;
        [JsonPropertyName("NumeroExterior")]
        public string ExteriorNumber => _exteriorNumber;
        [JsonPropertyName("Colonia")]
        public string Neighborhood => _neighborhood;
        [JsonPropertyName("Delegacion")]
        public string Delegation => _delegation;
        [JsonPropertyName("Municipio")]
        public string Municipality => _municipality;
        [JsonPropertyName("Estado")]
        public string State => _state;
        [JsonPropertyName("CodigoPostal")]
        public string PostalCode => _postalCode;
        [JsonPropertyName("Pais")]
        public string Country => _country;

        private InstituteObj(long InstituteId, string name)
        {
            Id = InstituteId;
            _name = name;
            _numberOfEmployees = string.Empty;
            _phone1 = string.Empty;
            _phone2 = string.Empty;
            _email = string.Empty;
            _street = string.Empty;
            _interiorNumber = string.Empty;
            _exteriorNumber = string.Empty;
            _neighborhood = string.Empty;
            _delegation = string.Empty;
            _municipality = string.Empty;
            _state = string.Empty;
            _postalCode = string.Empty;
            _country = string.Empty;
        }

        //Con informacion minima
        public static InstituteObj Create(long InstituteId, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("El nombre no puede estar vacio.", nameof(name));
            return new InstituteObj(InstituteId, name);
        }

        public InstituteObj SetInformationContact(string phone1, string phone2, string email)
        {
            if (!string.IsNullOrWhiteSpace(phone1))
            {
                _phone1 = phone1;
            }

            if (!string.IsNullOrWhiteSpace(phone2))
            {
                _phone2 = phone2;
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                _email = email;
            }

            return this;
        }

        public InstituteObj SetInformationAddress(string street, string neighborhood, string interiorNumber, string exteriorNumber, string postalCode)
        {
            if (!string.IsNullOrWhiteSpace(street))
            {
                _street = street;
            }

            if (!string.IsNullOrWhiteSpace(neighborhood))
            {
                _neighborhood = neighborhood;
            }

            if (!string.IsNullOrWhiteSpace(interiorNumber))
            {
                _interiorNumber = interiorNumber;
            }

            if (!string.IsNullOrWhiteSpace(exteriorNumber))
            {
                _exteriorNumber = exteriorNumber;
            }

            if (!string.IsNullOrWhiteSpace(postalCode))
            {
                _postalCode = postalCode;
            }

            return this;
        }

        public InstituteObj SetInformationLocation(string delegation, string municipality, string state, string country)
        {
            if (!string.IsNullOrWhiteSpace(delegation))
            {
                _delegation = delegation;
            }
            if (!string.IsNullOrWhiteSpace(municipality))
            {
                _municipality = municipality;
            }
            if (!string.IsNullOrWhiteSpace(state))
            {
                _state = state;
            }
            if (!string.IsNullOrWhiteSpace(country))
            {
                _country = country;
            }
            return this;
        }

        public InstituteObj SetAditionalInformation(string numberOfEmployees)
        {
            if (!string.IsNullOrWhiteSpace(numberOfEmployees))
                _numberOfEmployees = numberOfEmployees;
            return this;
        }
    }
}
