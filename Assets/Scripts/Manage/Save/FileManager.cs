using System;
using System.IO;
using UnityEngine;

public class FileManager
{
    public static bool WriteFile(string fileName, string dataFile)
    {
        string fullPath = Path.Combine(Application.persistentDataPath, fileName);

        try
        {
            if (!string.IsNullOrWhiteSpace(dataFile))
                File.WriteAllText(fullPath, dataFile);
            else
            {
                //create filestream
                FileStream fileStream = File.Open(fullPath,
                                                FileMode.OpenOrCreate,
                                                FileAccess.ReadWrite,
                                                FileShare.ReadWrite);

                fileStream.Dispose();//async
            }
            //new FileStream(fullPath, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
            return true;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to write to {fullPath} with exception {ex}");
            return false;
        }
    }

    public static string[] GetFileNames(string directoryPath, string fileExtension)
    {
        try
        {
            var fullPath = Path.Combine(Application.persistentDataPath, directoryPath);
            if (Directory.Exists(fullPath))
            {
                string[] fileNames = Directory.GetFiles(fullPath, fileExtension);
                for (int i = 0; i < fileNames.Length; i++)
                {
                    fileNames[i] = Path.GetFileName(fileNames[i]);
                }

                return fileNames;
            }
            else
            {
                Console.WriteLine("Directory does not exist.");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            return null;
        }
    }

    public static bool LoadFromFile(string fileName, out string result)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, fileName);
        if (!File.Exists(fullPath))
        {
            result = null;
            return false;
        }
        try
        {
            Debug.Log(fullPath);
            result = File.ReadAllText(fullPath);
            return !string.IsNullOrEmpty(result);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to read from {fullPath} with exception {ex}");
            result = null;
            return false;
        }
    }

    public static bool MoveFile(string fileName, string newFileName)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, fileName);
        var newFullPath = Path.Combine(Application.persistentDataPath, newFileName);

        try
        {
            if (File.Exists(newFullPath))
            {
                File.Delete(newFullPath);
            }

            if (!File.Exists(fullPath))
            {
                Debug.Log(fullPath);
                return false;
            }

            File.Move(fullPath, newFullPath);
            return true;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to move file from {fullPath} to {newFullPath} with exception {ex}");
            return false;
        }
    }
}
