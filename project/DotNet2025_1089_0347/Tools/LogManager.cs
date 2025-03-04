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
        string dirPath= Path.Combine(path, DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString("D2"));
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

        foreach (string dirYear in Directory.GetDirectories(fullPath))
        {
            
            if (yearFromPath(dirYear) < cutoffDate.Year)
            {
                deleteDir(dirYear);
            }
            else
            {
                if(yearFromPath(dirYear) <= DateTime.Now.Year)
                {
                    foreach (string dirMonth in Directory.GetDirectories(fullPath))
                    {
                        if ( cutoffDate.CompareTo(new DateTime(yearFromPath(dirYear), monthFromPath(dirMonth), 1)) < 0)
                            deleteDir(dirMonth);
                    }
                }
            }
        }
    }
    private static int yearFromPath(string dir)
    {

        return (int)(dir.Substring(dir.Length - 5, dir.Length - 1));
    }
    private static int monthFromPath(string dir)
    {
        return (int)(dir.SubString(dir.Length - 3, dir.Length - 1));
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

