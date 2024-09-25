using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Common.UX.Helpers
{
    //TODO: Confirm if still required
    public class FileNamesFromResourcePath
    {
        public IEnumerable<string> GetFilesInResourcePath(string folderFilter, string filetypeFilter)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            string[] manifestResources = executingAssembly.GetManifestResourceNames();

            string directory = Path.GetDirectoryName(executingAssembly.Location);
            Directory.GetFiles(directory ?? throw new InvalidOperationException());

            return manifestResources
                .Where(res => res.StartsWith(folderFilter)
                              && res.EndsWith(filetypeFilter));
        }
    }
}
