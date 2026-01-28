#if UNITY_EDITOR

using System.Collections.Generic;
using System.IO;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

class BuildProcessor : IPreprocessBuildWithReport
{
    public int callbackOrder { get { return 0; } }
    public void OnPreprocessBuild(BuildReport report)
    {
        Debug.LogWarning("OnPreprocessBuild");

        SaveStreamingAssetPaths();
        SaveStreamingAssetFolders("soundpacks");
    }

    private void SaveStreamingAssetPaths(string directory = "", string file_name = "StreamingAssetPaths")
    {
        List<string> paths = StreamingAssetsExtension.GetPathsRecursively(directory); // Gets list of files from StreamingAssets/directory

        // You could also save paths of files in Resources
        // List<string> paths = ResourcesExtension.GetPathsRecursively(directory); // Gets list of files from Resources/directory

        string txtPath = Path.Combine(Application.dataPath, "Resources", file_name + ".txt"); // writes the list of file paths to /Assets/Resources/
        if (File.Exists(txtPath))
        {
            File.Delete(txtPath);
        }
        using (FileStream fs = File.Create(txtPath)) { }
        using (StreamWriter writer = new StreamWriter(txtPath, false))
        {
            foreach (string path in paths)
            {
                writer.WriteLine(path);
            }
        }
    }
    private void SaveStreamingAssetFolders(string directory = "", string file_name = "StreamingAssetFolders")
    {
        List<string> folders = StreamingAssetsExtension.GetFoldersRecursively(directory); // Gets list of files from StreamingAssets/directory

        string txtFolder = Path.Combine(Application.dataPath, "Resources", file_name + ".txt"); // writes the list of file paths to /Assets/Resources/
        if (File.Exists(txtFolder))
        {
            File.Delete(txtFolder);
        }
        using (FileStream fs = File.Create(txtFolder)) { }
        using (StreamWriter writer = new StreamWriter(txtFolder, false))
        {
            foreach (string folder in folders)
            {
                writer.WriteLine(folder);
            }
        }


    }
}

#endif
