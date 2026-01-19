using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Common.Domain;

namespace Patient.Domain
{
    public class PatientObj : Entity<long>
    {
        private string _name;
        private string _lastnameP;
        private string _lastnameM;
        private string _gender;
        private DateTime? _birthdate;
        private int _age;
        private string _phone;
        private string _email;
        private DateTime? _receiptDate;
        private string _comments;

        [JsonPropertyName("Nombre")]
        public string Name => _name;
        [JsonPropertyName("ApellidoP")]
        public string LastnameP => _lastnameP;
        [JsonPropertyName("ApellidoM")]
        public string LastnameM => _lastnameM;
        [JsonPropertyName("Genero")]
        public string Gender => _gender;
        [JsonPropertyName("FechaNacimiento")]
        public DateTime? Birthdate => _birthdate;
        [JsonPropertyName("Edad")]
        public int Age => _age;
        [JsonPropertyName("Telefono")]
        public string Phone => _phone;
        [JsonPropertyName("Email")]
        public string Email => _email;
        [JsonPropertyName("FechaRecepcion")]
        public DateTime? ReceiptDate => _receiptDate;
        [JsonPropertyName("Comentario")]
        public string Comments => _comments;

        private PatientObj(long patientId, string name, string lastnameP, string lastnameM)
        {
            Id = patientId;
            _name = name;
            _lastnameP = lastnameP;
            _lastnameM = lastnameM;
            _gender = string.Empty;
            _birthdate = null;
            _age = 0;
            _phone = string.Empty;
            _email = string.Empty;
            _receiptDate = null;
            _comments = string.Empty;
        }

        public static PatientObj Create(long patientId, string name, string lastnameP, string lastnameM)
        {
            if (string.IsNullOrWhiteSpace(name)) 
                throw new ArgumentException("El nombre del paciente no puede ser nulo o vacio");
            if(string.IsNullOrWhiteSpace(lastnameP))
                throw new ArgumentException("El apellido paterno del paciente no puede ser nulo o vacio");
            if(string.IsNullOrWhiteSpace(lastnameM))
                throw new ArgumentException("El apellido materno del paciente no puede ser nulo o vacio");

            return new PatientObj(patientId, name, lastnameP, lastnameM);
        }

        public PatientObj SetInformationContact(string phone, string email)
        {
            _phone = phone;
            _email = email;
            return this;
        }

        public PatientObj SetInformationDate(DateTime? birthdate, DateTime? receiptDate)
        {
            _birthdate = birthdate;
            _receiptDate = receiptDate;
            return this;
        }

        public PatientObj SetInformationAditional(int age, string gender, string comments)
        {
            _gender = gender;
            _age = age;
            _comments = comments;
            return this;
        }
    }
}
