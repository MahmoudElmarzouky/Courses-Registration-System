namespace Courses_Registration_System.BL.Helper
{
    public static class UploadFileHelper
    {
        private static readonly string DirectoryPath = Directory.GetCurrentDirectory() + "/wwwroot/Files";
        private static string _getFolderPath(string folderName)
        {
            return Path.Combine(DirectoryPath, folderName);
        }
        public static string SaveFile(IFormFile file, string folderName)
        {
            var folderPath = _getFolderPath(folderName);
            var fileName = Guid.NewGuid() + file.FileName;
            var filePath = Path.Combine(folderPath, fileName);

            using var fileStream = new FileStream(filePath, FileMode.Create);
            
            file.CopyTo(fileStream);
            
            return fileName;
        }

        public static void RemoveFile(string folderName, string fileName)
        {
            var filePath = Path.Combine(_getFolderPath(folderName), fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
