using LinguaSeries.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace LinguaSeries.Services
{
    public class DataService
    {
        public List<LearningItem> LoadItems(string path)
        {
            var fullPath = ResolvePath(path);
            using (var stream = File.OpenRead(fullPath))
            {
                var serializer = new DataContractJsonSerializer(typeof(List<LearningItem>));
                return (List<LearningItem>)serializer.ReadObject(stream);
            }
        }

        public T LoadOrDefault<T>(string path, T fallback)
        {
            var fullPath = ResolvePath(path);
            if (!File.Exists(fullPath)) return fallback;
            using (var stream = File.OpenRead(fullPath))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(stream);
            }
        }

        public void Save<T>(string path, T data)
        {
            var fullPath = ResolvePath(path);
            using (var stream = File.Create(fullPath))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                serializer.WriteObject(stream, data);
            }
        }

        private string ResolvePath(string relative)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relative);
        }
    }
}
