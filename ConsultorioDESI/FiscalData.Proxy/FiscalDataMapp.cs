using FiscalData.Domain;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FiscalData.Proxy
{
    public class FiscalDataMapp
    {
        public static List<FiscalDataObj> MappFiscalData(DataTable dto)
        {
            // Si dto es null lanzamos excepción indicando que no fue posible obtener valores
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "No fue posible obtener valores desde el DataTable.");

            var list = new List<FiscalDataObj>();

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

                string rfc = dto.Columns.Contains("RFC") && row["RFC"] != DBNull.Value
                    ? row["RFC"].ToString() ?? string.Empty
                    : string.Empty;

                string reasonSocial = dto.Columns.Contains("RazonSocial") && row["RazonSocial"] != DBNull.Value
                    ? row["RazonSocial"].ToString() ?? string.Empty
                    : string.Empty;

                string address = dto.Columns.Contains("Direccion") && row["Direccion"] != DBNull.Value
                    ? row["Direccion"].ToString() ?? string.Empty
                    : string.Empty;
                
                string email = dto.Columns.Contains("Email") && row["Email"] != DBNull.Value
                    ? row["Email"].ToString() ?? string.Empty
                    : string.Empty;

                string regimen = dto.Columns.Contains("Regimen") && row["Regimen"] != DBNull.Value
                    ? row["Regimen"].ToString() ?? string.Empty
                    : string.Empty;

                long companyId = 0;
                if(dto.Columns.Contains("EmpresaId") && row["EmpresaId"] != DBNull.Value)
                {
                    try { companyId = Convert.ToInt64(row["EmpresaId"]); } catch(Exception ex) { companyId = 0; }
                }

                // Crear nuevo WorkAreaObj por cada fila
                var item = FiscalDataObj.Create(id);
                if (item != null)
                {
                    //ingresar los demas campos faltantes
                    item.SetInformationFiscal(rfc, reasonSocial, regimen);
                    item.SetInformationContact(email);
                    item.SetInformationLocation(address);
                    item.SetInformationAditional(companyId);
                    list.Add(item);
                }
            }

            return list;
        }
    }
}