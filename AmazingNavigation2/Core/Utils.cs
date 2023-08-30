using System;
using System.Management.Automation;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading.Tasks;

namespace AmazingNavigation2.Core;

public class Utils
{
    public static bool ModifyProperty(object? obj, string propertyName, object newValue)
    {
        Type? type = obj?.GetType();
        Type typeNewValue = newValue.GetType();
        PropertyInfo? property = type?.GetProperty(propertyName);
        if (property != null && property.CanWrite)
        {
            if (property.PropertyType != newValue.GetType()) return false;
            property.SetValue(obj, newValue);
            return true;
        }
        return false;
    }
    
    public static string HumanReadableFileSizes(double fileSize)
    {
        string[] sizes = { "B", "KB", "MB", "GB", "TB" };
        int order = 0;
        while (fileSize >= 1024 && order < sizes.Length - 1) {
            order++;
            fileSize /= 1024;
        }

        // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
        // show a single decimal place, and no space.
        return $"{fileSize:0.##}{sizes[order]}";
    }
    private static int FreeTcpPort()
    {
        TcpListener l = new TcpListener(IPAddress.Loopback, 0);
        l.Start();
        int port = ((IPEndPoint)l.LocalEndpoint).Port;
        l.Stop();
        return port;
    }

    public static int OpenPort()
    {
        try
        {
            PowerShell ps = PowerShell.Create();
            int port = FreeTcpPort();
            string applicationPath = Environment.CurrentDirectory;
            string psCommand = $"New-NetFirewallRule" +
                               $"-DisplayName \"Simple Socket Implementation\"" +
                               $"-Program {applicationPath}" +
                               $"-Direction Inbound -LocalPort {port}" +
                               $"-Protocol TCP -Action Allow";
            ps.Commands.AddScript(psCommand);
            ps.Invoke();
            return port;
        }
        catch (Exception e)
        {
            throw new Exception($"Encountered an error\n{e}");
        }
    }

}