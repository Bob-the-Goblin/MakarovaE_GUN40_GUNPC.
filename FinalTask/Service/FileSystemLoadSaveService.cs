

namespace FinalTask.Service
{
    internal class FileSystemLoadSaveService : ISaveLoadService<string>
    {
        readonly string path;
        
        public FileSystemLoadSaveService(string path) 
        { 
        this.path = path ;
        }
        public void SaveData(string data, string fileName)
        {
            var rightPath = Path.Combine(path, fileName);
            try
            {
                if (File.Exists(rightPath))
                {
                    using StreamWriter stream = File.CreateText(rightPath);
                    stream.WriteLine(data);
                }
                else
                {
                    File.Create(rightPath);
                    using StreamWriter stream = File.CreateText(rightPath);
                    stream.WriteLine(data);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public string LoadData(string fileName, out string data)
        {
            var rightPath = Path.Combine(path, fileName);

            if (File.Exists(rightPath))
            {
                try
                    {
                        data = File.ReadLines(rightPath).Last();
                        return data;
                    }
                catch 
                {
                    data = "100";
                    return data;
                }
              
             }
            else
            {
                Console.WriteLine("File not exist \nCreating file...");
                File.Create(rightPath);
                data = "100";
                return data;
            }
               
        }
    }
}
