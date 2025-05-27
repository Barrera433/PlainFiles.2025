using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTextFile;

internal class LogWriter : IDisposable
{

    private readonly StreamWriter _writer;
    private bool AutoFlush;

    public LogWriter(string path)
    {
        _writer = new StreamWriter(path, append: true);
        {
            AutoFlush = true;
        }
        ;
    }

    public void WriteLog(string level, string message)
    {
        var tiemstamp = DateTime.Now.ToString("s");// Iso 8691 format
        _writer.WriteLine($"{tiemstamp}: [{level}] {message}");
    }

    public void Dispose()
    {
        _writer?.Dispose();
    }

    internal void WriteLog(string v)
    {
        throw new NotImplementedException();
    }
}

