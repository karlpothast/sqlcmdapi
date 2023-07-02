using System.Text;
using System.Threading;
using System.Diagnostics;
using System;

namespace testsqlcmd;

class Program
{
    static void Main(string[] args)
    {
        App app1 = new App();
        String ret = "";
        ret = app1.ExecSQLQuery("");
        Console.WriteLine(ret);
    }

}

class App
{
    public String ExecSQLQuery(String SQLCommandText)
    {
      var process = new Process();
      
      try {

        String str_query = "SELECT GETDATE()";
        String pw = "n3wsdminDockr2022";
        //String databaseName = "master";

        //str_query = SQLCommandText;
        SQLCommandText = "SELECT GETDATE()";
        SQLCommandText = "\"" + str_query + "\"";

        var processStartInfo = new ProcessStartInfo()
        {
            WindowStyle = ProcessWindowStyle.Hidden,
            FileName = $"runsqlcmd.sh",
            //Arguments = $" -d /opt/mssql-tools/bin/sqlcmd -u sa -p " + pw + " -b " + databaseName + " -t " + str_query + "",
            Arguments = $" -d /opt/mssql-tools/bin/sqlcmd -u sa -p " + pw + " -b master -t " + SQLCommandText + "",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false
        };

        process.StartInfo = processStartInfo;
        process.Start();

        var output = process.StandardOutput.ReadToEnd();
        return output;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        var errorOutput = process.StandardError.ReadToEnd();
        return errorOutput;
      }
    }


}