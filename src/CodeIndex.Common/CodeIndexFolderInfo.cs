using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeIndex.Common
{
    public class CodeIndexFolderInfo
    {
        public string CodeIndexFolder { get; set; }

        public string HintIndexFolder { get; set; }

        public CodeIndexFolderInfo()
        {
        }

        public CodeIndexFolderInfo(string codeIndexFolder, string hintIndexFolder)
        {
            this.CodeIndexFolder = codeIndexFolder;
            this.HintIndexFolder = hintIndexFolder;
        }
    }
}