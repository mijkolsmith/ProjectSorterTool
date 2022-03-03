using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K3_TOOLS
{
	public abstract class FileType
	{
		public virtual string FilePath { get; protected set; }
		public virtual string FolderName { get; protected set; }
		protected FileType(string filePath, string folderName)
		{
			FilePath = filePath;
			FolderName = folderName;
		}
		public virtual void SetFolderName(string folderName) { FolderName = folderName; }
		public virtual void SetFilePath(string filePath) { FilePath = filePath; }
	}
}