using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K3_TOOLS
{
	public abstract class FileType
	{
		public virtual string FilePath { get; private set; }
		public virtual string FolderName { get; private set; }
		public virtual string FilePrefix { get; private set; }
		protected FileType(string filePath, string folderName, string filePrefix)
		{
			FilePath = filePath;
			FolderName = folderName;
			FilePrefix = filePrefix;
		}
	}
}