/*
 * Mark Dobbins
 * Lab 4
 * ITSE 1430
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Nile.Stores.Sql
{
    public class SqlProductDatabase : ProductDatabase
    {
        public SqlProductDatabase (string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override Product AddCore ( Product product )
        {
            using (var connection = CreateConnection ())
            using (var command = new SqlCommand ("AddProduct", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue ("@name", product.Name);
                command.Parameters.AddWithValue ("@price", product.Price);
                command.Parameters.AddWithValue ("@description", product.Description);
                command.Parameters.AddWithValue ("@isDiscontinued", product.IsDiscontinued);

                connection.Open ();
                var result = (decimal)command.ExecuteScalar ();
                product.Id = Convert.ToInt32 (result);
                return product;

            }
        }
        protected override IEnumerable<Product> GetAllCore ()
        {
            using (var connection = CreateConnection ())
            {
                var dSet = new DataSet ();
                using (var command = connection.CreateCommand ())
                {
                    command.CommandText = "GetAllProducts";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    var dAdapter = new SqlDataAdapter () 
                    {
                        SelectCommand = command
                    };
                    dAdapter.Fill (dSet);
                };

                var table = dSet.Tables.OfType<DataTable> ().FirstOrDefault ();
                if (table != null)
                {
                    foreach (var row in table.Rows.OfType<DataRow> ())
                    {
                        var product = new Product () 
                        {
                            Id = (int)row[0],
                            Name = row["Name"] as string,
                            Price = row.Field<decimal> ("Price"),
                            Description = row.Field<string> ("Description"),
                            IsDiscontinued = row.Field<bool> ("IsDiscontinued"),
                        };
                        yield return product;
                    };
                };

            };
        }
       
        protected override Product GetCore ( int id )
        {
            using (var connection = CreateConnection ())
            using (var command = new SqlCommand ("GetProduct", connection))

            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue ("@id", id);

                connection.Open ();
                using (var reader = command.ExecuteReader ())
                {
                    if (reader.Read ())
                    {
                        var price = reader.GetOrdinal ("Price");
                        var discontinued = reader.GetOrdinal ("IsDiscontinued");
                        var product = new Product () 
                        {
                            Id = (int)reader[0],
                            Name = reader["Name"] as string,
                            Description = reader["Description"] as string,
                            Price = (decimal)reader.GetValue (price),
                            IsDiscontinued = reader.GetBoolean (discontinued)
                        };
                        return product;
                    }
                };
            };

            return null;
        }

        protected override void RemoveCore ( int id )
        {
            using (var connection = CreateConnection ())
            using (var command = new SqlCommand ("RemoveProduct", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add ("@id", SqlDbType.Int);
                command.Parameters[0].Value = id;
                connection.Open ();
                command.ExecuteNonQuery ();
            }
        }
        protected override Product UpdateCore ( Product existing, Product newProduct )
        {
            using (var connection = CreateConnection ())
            using (var command = new SqlCommand ("UpdateProduct", connection))
            {
                newProduct.Id = existing.Id;

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue ("@name", newProduct.Name);
                command.Parameters.AddWithValue ("@price", newProduct.Price);
                command.Parameters.AddWithValue ("@description", newProduct.Description);
                command.Parameters.AddWithValue ("@isDiscontinued", newProduct.IsDiscontinued);
                command.Parameters.AddWithValue ("@id", newProduct.Id);
                connection.Open ();
                command.ExecuteNonQuery ();

                return newProduct;
            }
        }
        private SqlConnection CreateConnection ()
        {
            var connection = new SqlConnection (_connectionString);
            return connection;
        }
        private readonly string _connectionString;
    }
}
