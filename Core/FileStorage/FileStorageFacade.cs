using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;
using Newtonsoft.Json.Linq;

namespace Medea.Core.FileStorage
{
    public class FileStorageFacade
    {
        public IEnumerable<string> List(string pattern)
        {
            var matcher = new Matcher();

            matcher.AddInclude(pattern);

            PatternMatchingResult result = matcher.Execute(
                new DirectoryInfoWrapper(
                    new DirectoryInfo(".")));

            return result.Files.Select(f => f.Path);
        }

        public IEnumerable<JToken> Read(string path, FileStorageFormat format)
        {
            switch (format)
            {
                case FileStorageFormat.RAW:
                    yield return new JValue(File.ReadAllText(path));
                    yield break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
