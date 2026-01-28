using UnityEngine;

/// <summary>
/// Class <c>StreamingAssetsPath</c> gives different paths for different plattforms
/// </summary>
public static class StreamingAssetsPath
{

    /// <summary>
    /// Method <c>StreamingAssetPathForWWW</c> streamingassettspath for www for different os
    /// </summary>
    public static string StreamingAssetPathForWWW()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
        //Debug.Log("file://" + Application.dataPath + "/StreamingAssets/");
        return "file://" + Application.dataPath + "/StreamingAssets/";
#endif
#if UNITY_ANDROID
        return "jar:file://" + Application.dataPath + "!/assets/";
#endif
#if UNITY_IOS
            return "file://" + Application.dataPath + "/Raw/";
#endif
        throw new System.NotImplementedException("Check the ifdefs above.");
    }

    /// <summary>
    /// Method <c>v</c> streamingassets path for everything but android
    /// </summary>
    public static string StreamingAssetPathForFileOpen()
    {
#if !UNITY_EDITOR && UNITY_ANDROID
            throw new System.NotImplementedException( "You cannot open files on Android. Must use WWW");
#endif
        Debug.Log("Application.streamingAssetsPath:" + Application.streamingAssetsPath);
        return Application.streamingAssetsPath + "/";
    }
}
