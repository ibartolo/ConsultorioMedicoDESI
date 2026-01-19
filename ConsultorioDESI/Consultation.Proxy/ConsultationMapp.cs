using Consultation.Domain;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Proxy
{
    public class ConsultationMapp
    {
        public static List<ConsultationObj> MappConsultation(DataTable dto)
        {
            // Si dto es null lanzamos excepción indicando que no fue posible obtener valores
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "No fue posible obtener valores desde el DataTable.");

            var list = new List<ConsultationObj>();

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

                DateTime? date = null;
                if (dto.Columns.Contains("Fecha") && row["Fecha"] != DBNull.Value)
                {
                    try { date = Convert.ToDateTime(row["Fecha"]); } catch { date = null; }
                }

                TimeSpan? hour = null;
                if (dto.Columns.Contains("Hora") && row["Hora"] != DBNull.Value)
                {
                    try { hour = (TimeSpan)row["Hora"]; } catch { hour = null; }
                }

                string tipoConsulta= dto.Columns.Contains("TipoConsulta") && row["TipoConsulta"] != DBNull.Value
                    ? row["TipoConsulta"].ToString() ?? string.Empty
                    : string.Empty;

                string comentarios = dto.Columns.Contains("Comentarios") && row["Comentarios"] != DBNull.Value
                    ? row["Comentarios"].ToString() ?? string.Empty
                    : string.Empty;

                // Crear nuevo WorkAreaObj por cada fila
                var item = ConsultationObj.Create(id);
                if (item != null)
                {
                    //ingresar los demas campos faltantes
                    item.SetInformationAppointment(tipoConsulta);
                    item.SetInformationDateTime(date, hour);
                    item.SetInformationAditional(comentarios);
                    list.Add(item);
                }
            }

            return list;
        }
    }
}
