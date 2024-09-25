using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SEWSE.H1.UX.Resource.Core.Helpers
{
    public class FileNamesFromResourcePath
    {
        public IEnumerable<string> GetFilesInResourcePath(string folderFilter, string filetypeFilter)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            string[] manifestResources = executingAssembly.GetManifestResourceNames();

            string directory = Path.GetDirectoryName(executingAssembly.Location);
            string[] directoryFiles = Directory.GetFiles(directory);

            return manifestResources
                .Where(res => res.StartsWith(folderFilter)
                    && res.EndsWith(filetypeFilter));
        }
    }
}
