using System.Text;
using System.Threading;
using System.Diagnostics;
using System;

namespace Api.SQL;

public class SqlCmdWrapper
{
  public String ExecSQLQuery(String Username, String Password, String Database, String SQLCommandText)
  {
    var process = new Process();
    
    try {

      SQLCommandText = "\"" + SQLCommandText + "\"";

      var processStartInfo = new ProcessStartInfo()
      {
          WindowStyle = ProcessWindowStyle.Hidden,
          FileName = $"runsqlcmd.sh",
          Arguments = $" -d /opt/mssql-tools/bin/sqlcmd -u " + Username + " -p " + Password + " -b " + Database + " -t " + SQLCommandText + "",
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

