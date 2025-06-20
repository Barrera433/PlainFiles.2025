﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVSWhoutLibraries;

public class ManualCsvHelper
{
    public void WriterCVS (string path, List<string[]>records )
    {
        using var sw = new StreamWriter (path);
        foreach (var record in records)
        {
            var line = string.Join(",", record);
            sw.WriteLine(line);
        }
    }

    public List<string[]> ReadCVS(string path)
    {
        var records = new List<string[]>();
        if (!File.Exists(path))
        {
            return records;
        }

        using var sr = new StreamReader(path);
        string ? line;  
        while ((line = sr.ReadLine()) != null)
        {
            var record = line.Split(',');
            records.Add(record);
        }

        return records;
    }
}
