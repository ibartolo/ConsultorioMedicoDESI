using Catalogs.Domain;
using System.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogs.Proxy
{
    public class CatalogsMapp
    {
        public static List<CatalogsObj> MappCatalogs(DataTable dto)
        {
            // Si dto es null lanzamos excepción indicando que no fue posible obtener valores
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "No fue posible obtener valores desde el DataTable.");

            var list = new List<CatalogsObj>();

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

                string contactPhone = dto.Columns.Contains("TelContacto") && row["TelContacto"] != DBNull.Value
                    ? row["TelContacto"].ToString() ?? string.Empty
                    : string.Empty;

                string emailContact = dto.Columns.Contains("EmailContacto") && row["EmailContacto"] != DBNull.Value
                    ? row["EmailContacto"].ToString() ?? string.Empty
                    : string.Empty;

                string description = dto.Columns.Contains("Descripcion") && row["Descripcion"] != DBNull.Value
                    ? row["Descripcion"].ToString() ?? string.Empty
                    : string.Empty;

                string representative = dto.Columns.Contains("Representante") && row["Representante"] != DBNull.Value
                    ? row["Representante"].ToString() ?? string.Empty
                    : string.Empty;

                // Crear nuevo WorkAreaObj por cada fila
                var item = CatalogsObj.Create(id, name).SetInformationContact(contactPhone, emailContact).SetAditionalInformation(description, representative); 
                if (item != null)
                {
                    list.Add(item);
                }
            } 

            return list;
        }
    }
}