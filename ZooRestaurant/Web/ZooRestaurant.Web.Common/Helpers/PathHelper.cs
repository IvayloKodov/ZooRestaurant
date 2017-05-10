namespace ZooRestaurant.Web.Common.Helpers
{
    using System;
    using System.IO;
    using System.Reflection;

    public static class PathHelper
    {
        public static string MapPath(string filePath,Assembly assembly)
        {
            var absolutePath = new Uri(assembly.CodeBase).AbsolutePath;
            var directoryName = Path.GetDirectoryName(absolutePath);
            var path = Path.Combine(directoryName, filePath.TrimStart('~').Replace('/', '\\'));

            return path;
        }
    }
}