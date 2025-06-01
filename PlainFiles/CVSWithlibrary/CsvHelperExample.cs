using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVSWithlibrary;

public class CsvHelperExample
{

    public void WriteCsv(string path, IEnumerable<Person> people)
    {
        using var sw = new StreamWriter(path);
        using var cw = new CsvWriter(sw, System.Globalization.CultureInfo.InvariantCulture);
        cw.WriteRecords(people);
    }

    public IEnumerable<Person> Read(string path)
    {
        if (!File.Exists(path))
        {
            return Enumerable.Empty<Person>();
        }
        using var sr = new StreamReader(path);
        using var cr = new CsvReader(sr, System.Globalization.CultureInfo.InvariantCulture);
        return cr.GetRecords<Person>().ToList();
    }

}