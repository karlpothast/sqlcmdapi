using System.Text;
using System.Threading;
using System.Diagnostics;
using System;

namespace Api.SQL;

public class SqlCmdWrapper
{
  public String ExecSQLQuery(String SQLCommandText)
  {
    var process = new Process();
    
    try {

      String pw = "n3wsdminDockr2022";
      SQLCommandText = "\"" + SQLCommandText + "\"";
      String databaseName = "newdb";

      var processStartInfo = new ProcessStartInfo()
      {
          WindowStyle = ProcessWindowStyle.Hidden,
          FileName = $"runsqlcmd.sh",
          Arguments = $" -d /opt/mssql-tools/bin/sqlcmd -u sa -p " + pw + " -b " + databaseName + " -t " + SQLCommandText + "",
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

