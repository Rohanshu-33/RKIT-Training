using System;
using System.Data;

namespace CSharp_Basics
{
    internal class DataTableDemo
    {
        internal static void DataTableMethod()
        {
            DataTable table = new DataTable();
            table.Columns.Add("id", typeof(int));
            table.Columns.Add("name", typeof(string));
            table.Columns.Add("salary", typeof(float));

            table.Rows.Add(1, "Rohanshu", 75000.25F);
            table.Rows.Add(2, "Meet", 60000.70F);
            table.Rows.Add(3, "Navneet", 55000.55F);

            //foreach (DataRow row in table.Rows)
            //{
            //    Console.WriteLine(row["id"] + " " + row["name"] + " " + row["salary"]);
            //}

            // Queries:

            // Select
            //DataRow[] rows = table.Select("id > 1");
            //foreach (DataRow row in rows)
            //{
            //    Console.Write(row["id"] + " ");
            //}

            // Update
            //table.Rows[1]["salary"] = 95000.00F;
            //foreach (DataRow row in table.Rows)
            //{
            //    Console.WriteLine(row["id"] + " " + row["name"] + " " + row["salary"]);
            //}

            // Delete
            table.Rows[1].Delete(); // still not deleted.
            // rowstate is flagged as deleted and is hidden when iterated.
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine("Row State: " + row.RowState + " " + row["id"] + " " + row["name"] + " " + row["salary"]);
            }

            // Save current state
            table.AcceptChanges(); // actual deletion or modification of data
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine("Row States: " + row.RowState + " " + row["id"] + " " + row["name"] + " " + row["salary"]);
            }

            // modifying a row for demonstrating rejectchanges.
            table.Rows[0]["name"] = "rohan";
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine("Row States: " + row.RowState + " " + row["id"] + " " + row["name"] + " " + row["salary"]);
            }


            table.RejectChanges(); // reverts the changes done after the last AcceptChange call.
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine("Row States: " + row.RowState + " " + row["id"] + " " + row["name"] + " " + row["salary"]);
            }

            

            // Memory cleaning
            //table.Clear();  // Empty the table
            //table.Dispose(); // Release resources held by table and
            // makes the table ready for Garbage Collection

            table.PrimaryKey = new DataColumn[] { table.Columns["id"] };
            // for composite primary key, add fiels comma separated above.

            DataRow foundRow = table.Rows.Find(1);
            if (foundRow != null)
            {
                Console.WriteLine($"Found: {foundRow["name"]} {foundRow["salary"]}");
            }
            
            //table.Rows.Add(1, "abc", 55.55F); // ConstraintException Raised

            //DataTable tble2 = table.Clone(); // only structure, no data.

            // DataSet, TableName
        }
    }
}
