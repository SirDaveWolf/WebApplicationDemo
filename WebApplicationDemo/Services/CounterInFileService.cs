using Newtonsoft.Json;
using WebApplicationDemo.Exceptions;
using WebApplicationDemo.Models;
using WebApplicationDemo.Services.Interfaces;

namespace WebApplicationDemo.Services
{
    public class CounterInFileService : ICounterService
    {
        private const string _filename = "counter.txt";
        private string _filePath;

        public CounterInFileService() 
        {
            _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WebApplicationDemo", _filename);
            MakeSureThatTheDirectoryAndFileExistsOnTheHarddrive();
        }

        public int GetCounter()
        {
            try
            {
                var jsonString = File.ReadAllText(_filePath);
                var counterInFileModel = JsonConvert.DeserializeObject<CounterInFileModel>(jsonString);

                return counterInFileModel!.Counter;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                throw new FileSystemException();
            }
        }

        public void Increment()
        {
            try
            {
                var jsonString = File.ReadAllText(_filePath);
                var counterInFileModel = JsonConvert.DeserializeObject<CounterInFileModel>(jsonString);

                counterInFileModel!.Counter++;

                jsonString = JsonConvert.SerializeObject(counterInFileModel);
                File.WriteAllText(_filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new FileSystemException();
            }
        }

        private void MakeSureThatTheDirectoryAndFileExistsOnTheHarddrive()
        {
            var directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WebApplicationDemo");
            if(Directory.Exists(directory) == false)
            {
                Directory.CreateDirectory(directory);
            }

            if(File.Exists(_filePath) == false)
            {
                using (var fileStream = File.Create(_filePath))
                {
                    using (var writeStream = new StreamWriter(fileStream))
                    {
                        var counterInFileModel = new CounterInFileModel();
                        var jsonString = JsonConvert.SerializeObject(counterInFileModel);

                        writeStream.WriteLine(jsonString);
                        writeStream.Flush();
                    }
                }
            }
        }
    }
}
