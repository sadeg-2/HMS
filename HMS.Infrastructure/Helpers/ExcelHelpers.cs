using ClosedXML.Excel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HMS.Infrastructure.Helpers
{
    public class ExcelColumn
    {
        public ExcelColumn(string name)
        {
            Name = name;
            Order = 0;
        }

        public ExcelColumn(string name, int order)
        {
            Name = name;
            Order = order;
        }

        public string Name { get; set; }
        public int Order { get; set; }
    }

    public class ExcelRow
    {
        public Dictionary<string, string> Values { get; set; }
    }

    public static class ExcelHelpers
    {
        private static readonly List<string> BaseExcludedColumns = new List<string>
        {
            "Id",
            "IsDeleted",
            "CreatedBy",
            "UpdatedBy",
            "UpdatedAt"
        };

        public static byte[] ToExcel(Dictionary<string, ExcelColumn> cols, List<ExcelRow> rows)
        {
            using var workbook = new XLWorkbook();
            workbook.Worksheets.Add("Report");
            var worksheet = workbook.Worksheets.Single(e => e.Name.Equals("Report"));

            worksheet.Cell(1, 1).Value = "#";
            var colNumber = 2;
            foreach (var col in cols.OrderBy(e => e.Value.Order))
            {
                worksheet.Cell(1, colNumber++).Value = col.Value.Name;
            }

            var i = 2;
            foreach (var row in rows)
            {
                colNumber = 2;
                worksheet.Cell(i, 1).Value = i - 1;

                foreach (var col in cols.OrderBy(e => e.Value.Order))
                {
                    if (row.Values.ContainsKey(col.Value.Name))
                    {
                        worksheet.Cell(i, colNumber++).Value = row.Values[col.Value.Name];
                    }
                    else if (row.Values.ContainsKey(col.Key))
                    {
                        worksheet.Cell(i, colNumber++).Value = row.Values[col.Key];
                    }
                }

                ++i;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();

            return content;
        }

      
    }
}
