using ClosedXML.Excel;
using System;
using System.Collections.Generic;

namespace test_read_from_excel_file
{
    public class Student
    {
        public string Name { get; set; }
        public string Age { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            string projectDir = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", ".."));
            string filePath = System.IO.Path.Combine(projectDir, "files", "test.xlsx");

            if (!System.IO.File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                Console.ReadKey();
                return;
            }

            var list = new List<Student>();

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1);
                var rows = worksheet.RangeUsed().RowsUsed();

                bool isFirstRow = true;
                foreach (var row in rows)
                {
                    if (isFirstRow) { isFirstRow = false; continue; } // skip header

                    var student = new Student
                    {
                        Name = row.Cell(1).GetString(),
                        Age  = row.Cell(2).GetString()
                    };
                    list.Add(student);
                }
            }

            foreach (var s in list)
                Console.WriteLine($"Name: {s.Name}, Age: {s.Age}");

            Console.ReadKey();
        }
    }
}
