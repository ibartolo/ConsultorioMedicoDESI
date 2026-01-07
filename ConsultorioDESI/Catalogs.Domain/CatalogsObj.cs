using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Catalogs.Domain
{
    public class CatalogsObj : Entity<long>
    {
        private string _name;
        private string _description;
        private string _representative;
        private string _contactPhone;
        private string _EmailContact;

        [JsonPropertyName("Nombre")]
        public string Name => _name;

        [JsonPropertyName("Descripcion")]
        public string Description => _description;

        [JsonPropertyName("Representante")]
        public string Representative => _representative;

        [JsonPropertyName("TelContacto")]
        public string ContactPhone => _contactPhone;

        [JsonPropertyName("EmailContacto")]
        public string EmailContact => _EmailContact;

        private CatalogsObj(long CatalogId, string name)
        {
            Id = CatalogId;
            _name = name;
            _description = string.Empty;
            _representative = string.Empty;
            _contactPhone = string.Empty;
            _EmailContact = string.Empty;
        }

        //Metodo para creaer una instancia de catalogoObj con informacion minima
        public static CatalogsObj Create(long CatalogId, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("El nombre no puede estar vacio.", nameof(name));
            return new CatalogsObj(CatalogId, name);
        }

        public CatalogsObj SetInformationContact(string contactPhone, string emailContact)
        {
            if(!string.IsNullOrWhiteSpace(contactPhone))
                _contactPhone = contactPhone;
            
            if(!string.IsNullOrWhiteSpace(emailContact))    
                _EmailContact = emailContact;
            return this;
        }

        public CatalogsObj SetAditionalInformation(string description, string representative)
        {
            if (!string.IsNullOrWhiteSpace(description))
                _description = description;

            if (!string.IsNullOrWhiteSpace(representative))
                _representative = representative;
                
            return this;
        }
    }
}
