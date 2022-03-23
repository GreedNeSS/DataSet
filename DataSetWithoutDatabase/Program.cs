using System.Data;

Console.WriteLine("***** DataSet without database *****");

DataSet ds = new DataSet("UsersSet");
DataTable dt = new DataTable("Users");
ds.Tables.Add(dt);

DataColumn idColumn = new DataColumn("Id", Type.GetType("System.Int32"));
idColumn.Unique = true;
idColumn.AllowDBNull = false;
idColumn.AutoIncrement = true;
idColumn.AutoIncrementSeed = 1;
idColumn.AutoIncrementStep = 1;

DataColumn nameColumn = new DataColumn("Name", typeof(string));
DataColumn ageColumn = new DataColumn("Age", typeof(int));
ageColumn.DefaultValue = 1;

dt.Columns.Add(idColumn);
dt.Columns.Add(nameColumn);
dt.Columns.Add(ageColumn);

dt.PrimaryKey = new DataColumn[] { dt.Columns["Id"] };

DataRow row = dt.NewRow();
row.ItemArray = new object[] { null, "Ruslan", 30 };
dt.Rows.Add(row);
dt.Rows.Add(new object[] { null, "Marcus", 45 });

foreach (DataColumn column in dt.Columns)
{
    Console.Write($"{column.ColumnName}\t");
}
Console.WriteLine();

foreach (DataRow r in dt.Rows)
{
    foreach (object cell in r.ItemArray)
    {
        Console.Write(cell + "\t");
    }
    Console.WriteLine();
}