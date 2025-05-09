﻿using System;
using System.IO;
using UnityEngine;

namespace Zeph1rrGameBase.Scripts.Core.SaveLoadSystem
{
    public abstract class FileSaveLoadSystem: Core.SaveLoadSystem.SaveLoadSystem
    {
        public string SaveDirectory { get; private set; }
        public string FileExtension { get; private set; }

        public FileSaveLoadSystem(string saveDirectory, string fileExtension)
        {
            SaveDirectory = saveDirectory;
            FileExtension = fileExtension;
        }
        
        public abstract override T Load<T>(string key, T defaultData); 
        public abstract override void Save<T>(string key, T data);
        
        public string[] GetSaveFiles()
        {
            if (Directory.Exists(SaveDirectory)) return Directory.GetFiles(SaveDirectory, $"*.{FileExtension}");
            Debug.LogWarning("Save directory not found!");
            return Array.Empty<string>();

        }

        public string GetSaveFileLastWriteTime(string fileName)
        {
            var filePath = Path.Combine(SaveDirectory, fileName);
            if (File.Exists(filePath))
            {
                return File.GetLastWriteTime(filePath).ToString("yyyy-MM-dd HH:mm:ss");
            }
            Debug.LogWarning($"File not found: {filePath}");
            return "File not found";
        }

        public string GetSaveFileName(string fileName)
        {
            var filePath = Path.Combine(SaveDirectory, fileName);
            return Path.GetFileNameWithoutExtension(filePath);
        }

        public void CreateSaveDirectory()
        {
            if (!Directory.Exists(SaveDirectory))
            {
                Directory.CreateDirectory(SaveDirectory);
            }
        }

        public bool IsSaveExists(string playerName)
        {
            return File.Exists(Path.Combine(SaveDirectory, $"{playerName}.save"));
        }

        protected string GetSaveFilePath(string fileName)
        {
            return Path.Combine(SaveDirectory, $"{fileName}.{FileExtension}");
        }
    }
}