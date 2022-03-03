using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K3_TOOLS
{
	public class FileType
	{
		public virtual string FilePath { get; private set; }
		public virtual string FolderName { get; protected set; }

		public void SetFolderName(string name) { FolderName = name; }
		public void SetFilePath(string path) { FilePath = path; }
	}
}
