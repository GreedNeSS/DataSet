using Microsoft.Data.SqlClient;
using System.Data;

Console.WriteLine("***** Saving DataSet Changes to the Database *****");

string connectionStr = "Server=localhost;Database=adonetdb;Trusted_Connection=True;Encrypt=False";
string selectCommandText = "SELECT * FROM Users";

using (SqlConnection connection = new SqlConnection(connectionStr))
{
    SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, connection);
    DataSet set = new DataSet();
    adapter.Fill(set);

    ShowDataSet(set);

    DataRow newRow = set.Tables[0].NewRow();
    //newRow.ItemArray = new object[] { null, 110, "Fred" };
    newRow["Name"] = "Rick";
    newRow["Age"] = 99;
    set.Tables[0].Rows.Add(newRow);

    set.Tables[0].Rows[5]["Name"] = "Kukaracha";

    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
    adapter.Update(set);
    //adapter.Update(set.Tables[0]);
    set.Clear();
    adapter.Fill(set);

    ShowDataSet(set);

    Console.WriteLine();
    Console.WriteLine(builder.GetUpdateCommand().CommandText);
    Console.WriteLine(builder.GetInsertCommand().CommandText);
    Console.WriteLine(builder.GetDeleteCommand().CommandText);
}

void ShowDataSet(DataSet set)
{
    Console.WriteLine("\n=> ShowDataSet():");

    foreach (DataColumn col in set.Tables[0].Columns)
    {
        Console.Write($"{col.ColumnName}\t");
    }

    Console.WriteLine();

    foreach (DataRow row in set.Tables[0].Rows)
    {
        foreach (object cell in row.ItemArray)
        {
            Console.Write($"{cell}\t");
        }

        Console.WriteLine();

    }
}