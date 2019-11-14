using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itse1430.MovieLib.SqlServer
{
    /// <summary> Provides a movie database backed by SQL. </summary>
    public class SqlMovieDatabase : MovieDatabase
    {
        public SqlMovieDatabase (string connectionstring)
        {
            _connectionString = connectionstring;
        }
        protected override Movie AddCore ( Movie movie )
        {
            using (var conn = CreateConnection ())
            using (var cmd = new SqlCommand ("AddMovie", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue
                //cmd.Parameters.Add ("@id", SqlDbType.Int);
                var parmName = new SqlParameter ("@name", movie.Title);
                cmd.Parameters.Add (parmName);
                cmd.Parameters.AddWithValue ("@rating", movie.Rating);
                cmd.Parameters.AddWithValue ("@description", movie.Description);
                cmd.Parameters.AddWithValue ("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue ("@runLength", movie.RunLength);
                cmd.Parameters.AddWithValue ("@hasSeen", movie.HasSeen);

                conn.Open ();
                //movie.Id = (int)cmd.ExecuteScalar ();
                var result = (decimal)cmd.ExecuteScalar ();
                movie.Id = Convert.ToInt32 (result);
                return movie;

            }
        }

        protected override IEnumerable<Movie> GetAllCore ()
        {
            //create a connection and open
            using (var conn = CreateConnection ())
            {
                //create a command - option 1
                //var cmd = new SqlCommand ("GetAllMovies", conn);
                //var cmd = new SqlCommand ("GetAllMovies") { Connection = conn };
                var ds = new DataSet ();

                using (var cmd = conn.CreateCommand ())
                {
                    cmd.CommandText = "GetMovies";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var da = new SqlDataAdapter () {
                        SelectCommand = cmd
                    };

                    
                    da.Fill (ds);

                    
                    //cmd.ExecuteScalar ();
                };

                var table = ds.Tables.OfType<DataTable> ().FirstOrDefault ();
                if (table != null)
                {
                    foreach (var row in table.Rows.OfType<DataRow> ())
                    {
                        var movie = new Movie () {
                            Id = (int)row[0],
                            Title = row["Name"] as string,
                            Description = row.Field<string> ("Description"),
                            Rating = row.Field<string> ("Rating"),
                            RunLength = row.Field<int> ("RunLength"),
                            ReleaseYear = row.Field<int> ("ReleaseYear"),
                            HasSeen = row.Field<bool> ("Hasseen"),
                        };
                        yield return movie;
                    };
                };
                
            };
                //return Enumerable.Empty<Movie> ();
        }

        protected override Movie GetByNameCore ( string name )
        {
            using (var conn = CreateConnection ())
            using (var cmd = new SqlCommand ("FindByName", conn))

            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue ("@name", name);

                conn.Open ();
                using (var reader = cmd.ExecuteReader ())
                {
                    //multiple tables
                    //reader.NextResult()
                    if (reader.Read ())
                    {
                        var releaseYearIndex = reader.GetOrdinal ("ReleaseYear"); //this is just to show
                        var hasSeenIndex = reader.GetOrdinal ("HasSeen");
                        var movie = new Movie () {
                            Id = (int)reader[0],
                            Title = reader["Name"] as string,
                            Description = !reader.IsDBNull(2) ? reader.GetString (2) : "",
                            Rating = reader.GetFieldValue<string> (3),
                            RunLength = (int)reader.GetValue (5),
                            ReleaseYear = reader.GetInt32 (releaseYearIndex),
                            HasSeen = reader.GetBoolean (hasSeenIndex)
                        };
                        return movie;
                    }
                };
            };

            return null;
        }

        protected override Movie GetCore ( int id )
        {
            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand("GetMovie", conn))

            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue ("@id", id);

                conn.Open ();
                using (var reader = cmd.ExecuteReader())
                {
                    //multiple tables
                    //reader.NextResult()
                    if (reader.Read())
                    {
                        var releaseYearIndex = reader.GetOrdinal ("ReleaseYear"); //this is just to show
                        var hasSeenIndex = reader.GetOrdinal ("HasSeen");
                        var movie = new Movie () {
                            Id = (int)reader[0],
                            Title = reader["Name"] as string,
                            Description = !reader.IsDBNull (2) ? reader.GetString (2) : "",
                            Rating = reader.GetFieldValue<string> (3),
                            RunLength = (int)reader.GetValue (5),
                            ReleaseYear = reader.GetInt32 (releaseYearIndex),
                            HasSeen = reader.GetBoolean (hasSeenIndex)
                        };
                        return movie;
                    }
                };
            };

            return null;
        }

        protected override void RemoveCore ( int id )
        {
            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand("DeleteMovie", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue
                cmd.Parameters.Add ("@id", SqlDbType.Int);
                cmd.Parameters[0].Value = id;

                conn.Open();
                cmd.ExecuteNonQuery ();
            }
        }
        protected override Movie UpdateCore ( int id, Movie movie ) //changed newMovie to movie
        {
            using (var conn = CreateConnection ())
            using (var cmd = new SqlCommand ("UpdateMovie", conn))
            {
                //FIX: Set ID
                movie.Id = id;

                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue
                //cmd.Parameters.Add ("@id", SqlDbType.Int);
                var parmName = new SqlParameter ("@name", movie.Title);
                cmd.Parameters.Add (parmName);
                cmd.Parameters.AddWithValue ("@rating", movie.Rating);
                cmd.Parameters.AddWithValue ("@description", movie.Description);
                cmd.Parameters.AddWithValue ("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue ("@runLength", movie.RunLength);
                cmd.Parameters.AddWithValue ("@hasSeen", movie.HasSeen);
                cmd.Parameters.AddWithValue ("@id", movie.Id);

                conn.Open ();
                cmd.ExecuteNonQuery ();

                return movie;

            }
        }

        private SqlConnection CreateConnection()
        {
            var conn = new SqlConnection (_connectionString);
            //conn.Open ();
            return conn;
        }
        private readonly string _connectionString;
    }
}
