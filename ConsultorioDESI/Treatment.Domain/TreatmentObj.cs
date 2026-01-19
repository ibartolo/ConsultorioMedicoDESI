using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Common.Domain;

namespace Treatment.Domain
{
    public class TreatmentObj : Entity<long>
    {
        private string _name;
        private int _duration;
        private string _description;

        [JsonPropertyName("Nombre")]
        public string Name => _name;
        [JsonPropertyName("Duracion")]
        public int Duration => _duration;
        [JsonPropertyName("Descripcion")]
        public string Description => _description;

        private TreatmentObj(long id, string name)
        {
            Id = id;
            _name = name;
            _duration = 0;
            _description = string.Empty;
        }

        public static TreatmentObj Create(long id, string name)
        {
            return new TreatmentObj(id, name);
        }

        public TreatmentObj SetInformationAditional(int duration, string description)
        {
            _duration = duration;
            _description = description;
            return this;
        }
    }
}
