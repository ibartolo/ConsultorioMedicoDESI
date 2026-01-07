using Institute.Domain;
using System.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogs.Proxy
{
    public class InstituteMapp
    {
        public static List<InstituteObj> MappInstitute(DataTable dto)
        {
            // Si dto es null lanzamos excepción indicando que no fue posible obtener valores
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "No fue posible obtener valores desde el DataTable.");

            var list = new List<InstituteObj>();

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

                string numeroTrabajadores = dto.Columns.Contains("NumeroTrabajadores") && row["NumeroTrabajadores"] != DBNull.Value
                    ? row["NumeroTrabajadores"].ToString() ?? string.Empty
                    : string.Empty;

                string telefono1 = dto.Columns.Contains("TelefonoL1") && row["TelefonoL1"] != DBNull.Value
                    ? row["TelefonoL1"].ToString() ?? string.Empty
                    : string.Empty;

                string telefono2 = dto.Columns.Contains("TelefonoL2") && row["TelefonoL2"] != DBNull.Value
                    ? row["TelefonoL2"].ToString() ?? string.Empty
                    : string.Empty;

                string email = dto.Columns.Contains("Email") && row["Email"] != DBNull.Value
                    ? row["Email"].ToString() ?? string.Empty
                    : string.Empty;

                string calle = dto.Columns.Contains("Calle") && row["Calle"] != DBNull.Value
                    ? row["Calle"].ToString() ?? string.Empty
                    : string.Empty;

                string numeroInterior = dto.Columns.Contains("NumeroInterior") && row["NumeroInterior"] != DBNull.Value
                    ? row["NumeroInterior"].ToString() ?? string.Empty
                    : string.Empty;

                string numeroExterior = dto.Columns.Contains("NumeroExterior") && row["NumeroExterior"] != DBNull.Value
                    ? row["NumeroExterior"].ToString() ?? string.Empty
                    : string.Empty;

                string colonia = dto.Columns.Contains("Colonia") && row["Colonia"] != DBNull.Value
                    ? row["Colonia"].ToString() ?? string.Empty
                    : string.Empty;

                string delegacion = dto.Columns.Contains("Delegacion") && row["Delegacion"] != DBNull.Value
                    ? row["Delegacion"].ToString() ?? string.Empty
                    : string.Empty;

                string municipio = dto.Columns.Contains("Municipio") && row["Municipio"] != DBNull.Value
                    ? row["Municipio"].ToString() ?? string.Empty
                    : string.Empty;

                string estado = dto.Columns.Contains("Estado") && row["Estado"] != DBNull.Value
                    ? row["Estado"].ToString() ?? string.Empty
                    : string.Empty;

                string codigoPostal = dto.Columns.Contains("CodigoPostal") && row["CodigoPostal"] != DBNull.Value
                    ? row["CodigoPostal"].ToString() ?? string.Empty
                    : string.Empty;

                string pais = dto.Columns.Contains("Pais") && row["Pais"] != DBNull.Value
                    ? row["Pais"].ToString() ?? string.Empty
                    : string.Empty;

                

                // Crear nuevo WorkAreaObj por cada fila
                var item = InstituteObj.Create(id, name);
                if (item != null)
                {
                    item.SetInformationContact(telefono1, telefono2, email);
                    item.SetInformationAddress(calle, colonia, numeroInterior, numeroExterior, codigoPostal);
                    item.SetInformationLocation(delegacion, municipio, estado, pais);
                    list.Add(item);
                }
            }

            return list;
        }
    }
}