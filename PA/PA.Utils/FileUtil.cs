namespace PA.Utils
{
    public static class FileUtil
    {
        public static List<string> ReadAllLinesOfAllFiles(string folderPath)
        {
            try
            {
                List<string> testLines = new List<string>();
                if (IsDirecotryExists(folderPath))
                {
                    string[] files = Directory.GetFiles(folderPath);
                    foreach (var file in files)
                    {
                        testLines.AddRange(ReadAllLinesOfTextFile(file));
                    }
                }
                return testLines;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string[] ReadAllLinesOfTextFile(string filePath)
        {
            try
            {
                string[] testLines = new string[0];
                if (IsFileExists(filePath))
                {
                    testLines = File.ReadAllLines(filePath);
                }
                return testLines;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool IsDirecotryExists(string dirPath)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
                return dirInfo.Exists;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool IsFileExists(string filePath)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(filePath);
                return fileInfo.Exists;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}