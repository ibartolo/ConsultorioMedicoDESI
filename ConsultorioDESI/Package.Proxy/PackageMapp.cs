using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Package.Domain;

namespace Package.Proxy
{
    public class PackageMapp
    {
        public static List<PackageObj> MappPackage(DataTable dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "No fue posible obtener valores desde el DataTable.");

            var list = new List<PackageObj>();

            if (dto.Rows.Count == 0)
                return list;

            foreach (DataRow row in dto.Rows)
            {
                long id = 0;
                if (dto.Columns.Contains("Id") && row["Id"] != DBNull.Value)
                {
                    try { id = Convert.ToInt64(row["Id"]); } catch { id = 0; }
                }

                string packageName = dto.Columns.Contains("NombrePaquete") && row["NombrePaquete"] != DBNull.Value
                    ? row["NombrePaquete"].ToString() ?? string.Empty
                    : string.Empty;

                decimal price = 0;
                if (dto.Columns.Contains("Costo") && row["Costo"] != DBNull.Value)
                    try { price = Convert.ToDecimal(row["Costo"]); } catch { price = 0; }

                string description = dto.Columns.Contains("Descripcion") && row["Descripcion"] != DBNull.Value
                    ? row["Descripcion"].ToString() ?? string.Empty
                    : string.Empty;
                
                var item = PackageObj.Create(id, packageName);
                if(item != null)
                {
                    item.SetInformationAditional(price, description);
                    list.Add(item);
                }
            }
            return list;
        }
    }
}
