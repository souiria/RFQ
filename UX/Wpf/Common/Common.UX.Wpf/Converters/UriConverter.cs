using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Common.UX.Helpers;

namespace Common.UX.Wpf.Converters
{
    public class UriConverter
    {
        public Stream UriToStream(string uri)
        {
            return Application.GetResourceStream(new Uri(uri))?.Stream;
        }

        public List<string> UriFolderToUriFileList(string filetypeFilter)
        {
            FileNamesFromResourcePath filter = new FileNamesFromResourcePath();
            var folderFilter = "Common.UX.Resources.Images.Themes.";

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