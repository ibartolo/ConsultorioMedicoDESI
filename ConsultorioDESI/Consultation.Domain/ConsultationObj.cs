using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Common.Domain;

namespace Consultation.Domain
{
    public class ConsultationObj : Entity<long>
    {
        private long _patient { get; set; }
        private DateTime? _date { get; set; }
        private TimeSpan? _hour { get; set; }
        private string _typeConsultation { get; set; }
        private string _comments { get; set; }

        [JsonPropertyName("Paciente")]
        public long Patient => _patient;
        [JsonPropertyName("Fecha")]
        public DateTime? Date => _date;
        [JsonPropertyName("Hora")]
        public TimeSpan? Hour => _hour;
        [JsonPropertyName("TipoConsulta")]
        public string TypeConsultation => _typeConsultation;
        [JsonPropertyName("Comentarios")]
        public string Comment => _comments;

        private ConsultationObj(long consultationId)
        {
            Id = consultationId;
            _patient = 0;
            _date = null;
            _hour = null;
            _typeConsultation = string.Empty;
            _comments = string.Empty;
        }

        public static ConsultationObj Create(long consultationId)
        {
            if (consultationId <= 0)
                throw new ArgumentException("El Id de la consulta no puede ser menor o igual a cero.", nameof(consultationId));

            return new ConsultationObj(consultationId);
        }

        public ConsultationObj SetInformationAppointment(string typeConsultation)
        {
            if (!string.IsNullOrWhiteSpace(typeConsultation))
                _typeConsultation = typeConsultation;
            return this;
        }

        public ConsultationObj SetInformationDateTime(DateTime? date, TimeSpan? hour)
        {
            if(date != null)
                _date = date;

            if(hour != null) 
                _hour = hour;
            return this;
        }

        public ConsultationObj SetInformationAditional(string comments)
        {
            if(!string.IsNullOrWhiteSpace(comments))
                _comments = comments;
            return this;
        }
    }
}
