using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using SEWSE.H1.UX.Resource.Core.Helpers;

namespace SEWSE.H1.UX.Infrastructure.Core.Converters
{
    public class UriConverter
    {
        public Stream UriToStream(string uri)
        {
            return Application.GetResourceStream(new Uri(uri)).Stream;
        }

        public List<string> UriFolderToUriFileList(string filetypeFilter)
        {
            FileNamesFromResourcePath filter = new FileNamesFromResourcePath();
            string folderFilter = "SEWSE.H1.UX.Resource.Images.Themes.";

            IEnumerable<string> resourceFiles = filter.GetFilesInResourcePath(folderFilter, filetypeFilter);

            List<string> uriFiles = new List<string>();

            foreach (string filePath in resourceFiles)
            {
                uriFiles.Add(filePath.Replace(folderFilter, ""));
            }

            return uriFiles;
        }
    }
}