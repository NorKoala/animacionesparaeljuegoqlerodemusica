using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileCopyExample : MonoBehaviour
{
    // Source and destination directories
    public string sourceDirectory = "Assets/SourceFolder";
    public string destinationDirectory = "Assets/DestinationFolder";

    void Start()
    {
        CopyFiles(sourceDirectory, destinationDirectory);
    }

    void CopyFiles(string sourceDir, string destDir)
    {
        // Ensure the destination directory exists
        if (!Directory.Exists(destDir))
        {
            Directory.CreateDirectory(destDir);
        }

        // Get the files in the source directory
        string[] files = Directory.GetFiles(sourceDir);

        foreach (string file in files)
        {
            // Get the file name
            string fileName = Path.GetFileName(file);
            // Create the destination file path
            string destFile = Path.Combine(destDir, fileName);
            // Copy the file
            File.Copy(file, destFile, true);
        }

        Debug.Log("Files copied successfully!");
    }
}
