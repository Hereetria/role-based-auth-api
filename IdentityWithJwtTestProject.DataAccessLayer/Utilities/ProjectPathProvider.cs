using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DataAccessLayer.Utilities
{
    public static class ProjectPathProvider
    {

        public static string GetProjectPath()
        {
            var currentDirectory = new DirectoryInfo(AppContext.BaseDirectory);
            var projectPath = currentDirectory.Parent?.Parent?.Parent?.Parent?.FullName;
            if(projectPath == null)
                throw new ArgumentNullException(nameof(projectPath));
            return projectPath;
        }

        public static string GetApiProjectPath()
        {
            var currentDirectory = new DirectoryInfo(AppContext.BaseDirectory);
            var projectPath = currentDirectory.Parent?.Parent?.Parent?.Parent?.FullName;
            if (projectPath == null)
                throw new NullReferenceException();

            var webApiPath = Path.Combine(projectPath, @"IdentityWithJwtTestProject.WebApi");
            return webApiPath;
        }
    }
}
