using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools;

public static class LogManager
{
    private static string path = "Log";
    public static string CurPathFolder()
    {
        string dirPath = Path.Combine(path, DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString("D2"));
        //$"{path}\\{DateTime.Now.Year}\\{DateTime.Now.Month}";
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        return dirPath;
    }
    public static string CurPathFile()
    {
        return Path.Combine(CurPathFolder(), DateTime.Now.Day.ToString());
    }
    public static void WriteLog(string project, string funcName, string message)
    {
        string log = $"{DateTime.Now.TimeOfDay}\t{project}.{funcName}:\t{message}";
        StreamWriter sw = new StreamWriter(new FileStream(CurPathFile(), FileMode.Append, FileAccess.Write));
        sw.WriteLine(log);
        sw.Close();
    }
    public static void ClearLOg()
    {

        DateTime cutoffDate = DateTime.Now.AddMonths(-2);

        foreach (string dirYear in Directory.GetDirectories(path))
        {
            DirectoryInfo dirYInfo = new DirectoryInfo(dirYear);
            if (dirYInfo.CreationTime.Year < cutoffDate.Year)
            {
                deleteDir(dirYear);
            }
            else
            {
                foreach (string dirMonth in Directory.GetDirectories(dirYear))
                {
                    DirectoryInfo dirMInfo = new DirectoryInfo(dirMonth);
                    if (dirMInfo.CreationTime < cutoffDate)
                        deleteDir(dirMonth);
                }
            }
        }
    }

    private static void deleteDir(string dir)
    {
        try
        {
            Directory.Delete(dir, true);
            Console.WriteLine($"Deleted directory: {dir}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

}

