using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebEnacal2.Models
{
    public class CaninosDAL
    {
        string cadena = "Server=DESKTOP-P24U9SO; Initial Catalog=dbCanino; User ID=sa; Password=admin123; Trusted_Connection=false";

        public async Task<Canino> CreateMetodo(Canino p)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(cadena))
                {
                    SqlCommand cmd = cnn.CreateCommand();
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "AddCanino";
                    cmd.Parameters.Add("@NombreCanino", SqlDbType.VarChar, 50).Value = p.NombreCanino;
                    cmd.Parameters.Add("@Raza", SqlDbType.VarChar, 30).Value = p.Raza;
                    cmd.Parameters.Add("@EdadCanina", SqlDbType.Int).Value = p.EdadCanina;
                    Task<int> mcResult = cmd.ExecuteNonQueryAsync();
                    await Task.WhenAll(mcResult);
                    return p;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Canino> EditMetodo(int id, Canino p)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(cadena))
                {
                    SqlCommand cmd = cnn.CreateCommand();
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "UpdateCanino";
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@NombreCanino", SqlDbType.VarChar, 50).Value = p.NombreCanino;
                    cmd.Parameters.Add("@Raza", SqlDbType.VarChar, 30).Value = p.Raza;
                    cmd.Parameters.Add("@EdadCanina", SqlDbType.Int).Value = p.EdadCanina;
                    Task<int> mcResult = cmd.ExecuteNonQueryAsync();
                    await Task.WhenAll(mcResult);
                    return p;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> DeleteMetodo(int id)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(cadena))
                {
                    SqlCommand cmd = cnn.CreateCommand();
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DeleteCanino";
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    Task<int> mcResult = cmd.ExecuteNonQueryAsync();
                    await Task.WhenAll(mcResult);
                    return id;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
