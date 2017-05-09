namespace ZooRestaurant.Web.Common.Helpers
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Web;
    using System.Web.Hosting;

    public static class PathHelper
    {
        public static string MapPath(string filePath,Assembly assembly)
        {
            //if (HttpContext.Current != null)
            //    return HostingEnvironment.MapPath(filePath);

            var absolutePath = new Uri(assembly.CodeBase).AbsolutePath;
            var directoryName = Path.GetDirectoryName(absolutePath);
            var path = Path.Combine(directoryName, filePath.TrimStart('~').Replace('/', '\\'));

            return path;
        }
    }
}