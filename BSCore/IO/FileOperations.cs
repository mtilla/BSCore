using System;
using System.IO;
using System.Threading;

namespace BSCore.IO
{
    public static class FileOperations
    {

        /// <summary>
        /// Move a file to a new location
        /// </summary>
        /// <param name="sourceFile">Full path of source file</param>
        /// <param name="destinationFolder">Destination folder, ex filename.</param>
        public static void Move(String sourceFile, string destinationFolder)
        {
            // Copy first, delete afterwards.
            string fileName = Path.GetFileName(sourceFile);
            if (fileName != null)
            {
                string destFile = Path.Combine(destinationFolder, fileName);
                if (FileIsReady(sourceFile))
                {
                    //System.IO.File.Copy(sourceFile, destFile, true);
                    File.Move(sourceFile, destFile);
                }
            }
        }

        /// <summary>
        /// Determine if file is in use and wait for it until it is completed.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool FileIsReady(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                    using (File.OpenRead(filePath))
                    {
                        return true;
                    }
                else
                    return false;
            }
            #pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
            #pragma warning restore CS0168 // Variable is declared but never used
            {
                Thread.Sleep(1000);
                return FileIsReady(filePath);
            }
        }

        public static void BackupFile(string filepath)
        {
            throw new NotImplementedException();
        }
    }
}
