using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Common.Domain;

namespace Package.Domain
{
    public class PackageObj : Entity<long>
    {
        private string _name;
        private decimal _price;
        private string _description;

        [JsonPropertyName("NombrePaquete")]
        public string Name => _name;
        [JsonPropertyName("Costo")]
        public decimal Price => _price;
        [JsonPropertyName("Descripcion")]
        public string Description => _description;

        private PackageObj(long id, string name)
        {
            Id = id;
            _name = name;
            _price = 0;
            _description = string.Empty;
        }

        public static PackageObj Create(long id, string name)
        {
            return new PackageObj(id, name);
        }

        public PackageObj SetInformationAditional(decimal price, string description)
        {
            _price = price;
            _description = description;
            return this;
        }
    }
}
