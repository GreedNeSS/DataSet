using Microsoft.Data.SqlClient;
using System.Data;

Console.WriteLine("***** SqlDataAdapter And DataSet *****");

string connectString = "Server=localhost;Database=adonetdb;Trusted_Connection=True;Encrypt=False";
string sql = "SELECT * FROM Users";

using (SqlConnection connection = new SqlConnection(connectString))
{
    DataSet ds = new DataSet();
    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
    adapter.Fill(ds);

    foreach (DataTable table in ds.Tables)
    {
        foreach (DataColumn column in table.Columns)
        {
            Console.Write($"{column.ColumnName}\t");
        }

        Console.WriteLine();

        foreach (DataRow row in table.Rows)
        {
            foreach (object cell in row.ItemArray)
            {
                Console.Write($"{cell}\t");
            }

            Console.WriteLine();
        }
    }
}

Console.ReadLine();