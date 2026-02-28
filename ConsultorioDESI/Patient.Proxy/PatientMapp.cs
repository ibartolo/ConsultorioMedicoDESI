using Patient.Domain;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Proxy
{
    public class PatientMapp
    {
        public static List<PatientObj> MappPatient(DataTable dto)
        {
            // Si dto es null lanzamos excepción indicando que no fue posible obtener valores
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "No fue posible obtener valores desde el DataTable.");

            var list = new List<PatientObj>();

            // Si no tiene filas regresamos lista vacía
            if (dto.Rows.Count == 0)
                return list;

            foreach (DataRow row in dto.Rows)
            {
                // Obtener valores de forma segura (si la columna no existe o es DBNull, usar valores por defecto)
                long id = 0;
                if (dto.Columns.Contains("Id") && row["Id"] != DBNull.Value)
                {
                    try { id = Convert.ToInt64(row["Id"]); } catch { id = 0; }
                }

                string name = dto.Columns.Contains("Nombre") && row["Nombre"] != DBNull.Value
                    ? row["Nombre"].ToString() ?? string.Empty
                    : string.Empty;

                string lastnameP = dto.Columns.Contains("ApellidoP") && row["ApellidoP"] != DBNull.Value
                    ? row["ApellidoP"].ToString() ?? string.Empty
                    : string.Empty;

                string lastnameM = dto.Columns.Contains("ApellidoM") && row["ApellidoM"] != DBNull.Value
                    ? row["ApellidoM"].ToString() ?? string.Empty
                    : string.Empty;

                string gender = dto.Columns.Contains("Genero") && row["Genero"] != DBNull.Value
                    ? row["Genero"].ToString() ?? string.Empty
                    : string.Empty;

                DateTime? birthdate = null;
                if (dto.Columns.Contains("FechaNacimiento") && row["FechaNacimiento"] != DBNull.Value)
                {
                    try { birthdate = Convert.ToDateTime(row["FechaNacimiento"]); } catch { birthdate = null; }
                }

                int age = 0;
                if(dto.Columns.Contains("Edad") && row["Edad"] != DBNull.Value)
                {
                    try { age = Convert.ToInt32(row["Edad"]); } catch { age = 0; }
                }

                string phone = dto.Columns.Contains("Telefono") && row["Telefono"] != DBNull.Value
                    ? row["Telefono"].ToString() ?? string.Empty
                    : string.Empty;

                string email = dto.Columns.Contains("Email") && row["Email"] != DBNull.Value
                    ? row["Email"].ToString() ?? string.Empty
                    : string.Empty;

                DateTime? receiptdate = null;
                if (dto.Columns.Contains("FechaRecepcion") && row["FechaRecepcion"] != DBNull.Value)
                {
                    try { receiptdate = Convert.ToDateTime(row["FechaRecepcion"]); } catch { receiptdate = null; }
                }

                string comments = dto.Columns.Contains("Comentario") && row["Comentario"] != DBNull.Value
                    ? row["Comentario"].ToString() ?? string.Empty
                    : string.Empty;


                // Crear nuevo WorkAreaObj por cada fila
                var item = PatientObj.Create(id, name, lastnameP, lastnameM);
                if (item != null)
                {
                    item.SetInformationContact(phone, email);
                    item.SetInformationDate(birthdate, receiptdate);
                    item.SetInformationAditional(age, gender, comments);
                    list.Add(item);
                }
            }

            return list;
        }
    }
}
