#if UNITY_IOS
using System.Runtime.InteropServices;
using System;
#else
using UnityEngine;
#endif


/// <summary>
/// https://github.com/ChrisMaire/unity-native-sharing
/// </summary>
public static class NativeShare
{
    /// <summary>
    /// Shares on file maximum
    /// </summary>
    /// <param name="body"></param>
    /// <param name="filePath">The path to the attached file</param>
    /// <param name="url"></param>
    /// <param name="subject"></param>
    /// <param name="mimeType"></param>
    /// <param name="chooser"></param>
    /// <param name="chooserText"></param>
    public static void Share(string body, string filePath = null, string url = null, string subject = "", string mimeType = "text/*", bool chooser = false, string chooserText = "Select sharing app")
    {
        ShareMultiple(body, filePath, url, subject, mimeType, chooser, chooserText);
    }

    /// <summary>
    /// Shares multiple files at once
    /// </summary>
    /// <param name="body"></param>
    /// <param name="filePaths">The paths to the attached files</param>
    /// <param name="url"></param>
    /// <param name="subject"></param>
    /// <param name="mimeType"></param>
    /// <param name="chooser"></param>
    /// <param name="chooserText"></param>
    public static void ShareMultiple(string body, string filePaths = null, string url = null, string subject = "", string mimeType = "text/*", bool chooser = false, string chooserText = "Select sharing app")
    {
#if UNITY_ANDROID
        ShareAndroid(body, subject, url, filePaths, mimeType, chooser, chooserText);
#elif UNITY_IOS
		ShareIOS(body, subject, url, filePaths);
#else
        Debug.Log("No sharing set up for this platform.");
        Debug.Log("Subject: " + subject);
        Debug.Log("Body: " + body);
#endif
    }

#if UNITY_ANDROID
    public static void ShareAndroid(string body, string subject, string url, string filePaths, string mimeType, bool chooser, string chooserText)
    {
        AndroidJavaClass androidJavaClass = new AndroidJavaClass("android.content.Intent");
        AndroidJavaObject androidJavaObject = new AndroidJavaObject("android.content.Intent", new object[0]);
        androidJavaObject.Call<AndroidJavaObject>("setAction", new object[]
        {
            androidJavaClass.GetStatic<string>("ACTION_SEND")
        });
        AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("android.net.Uri");
        AndroidJavaObject androidJavaObject2 = androidJavaClass2.CallStatic<AndroidJavaObject>("parse", new object[]
            {
                "file://" + filePaths
            });
        androidJavaObject.Call<AndroidJavaObject>("putExtra", new object[]
        {
                androidJavaClass.GetStatic<string>("EXTRA_STREAM"),
                androidJavaObject2
        });

        androidJavaObject.Call<AndroidJavaObject>("setType", new object[]
        {
            mimeType
        });
        androidJavaObject.Call<AndroidJavaObject>("putExtra", new object[]
        {
            androidJavaClass.GetStatic<string>("EXTRA_TEXT"),
            body
        });
        AndroidJavaClass androidJavaClass3 = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject @static = androidJavaClass3.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject androidJavaObject3 = androidJavaClass.CallStatic<AndroidJavaObject>("createChooser", new object[]
        {
            androidJavaObject,
            subject
        });
        @static.Call("startActivity", new object[]
        {
            androidJavaObject3
        });
    }
#endif

#if UNITY_IOS
	public struct ConfigStruct
	{
		public string title;
		public string message;
	}

	[DllImport ("__Internal")] private static extern void showAlertMessage(ref ConfigStruct conf);

	public struct SocialSharingStruct
	{
		public string text;
		public string subject;
		public string filePaths;
	}

	[DllImport ("__Internal")] private static extern void showSocialSharing(ref SocialSharingStruct conf);

	public static void ShareIOS(string title, string message)
	{
		ConfigStruct conf = new ConfigStruct();
		conf.title  = title;
		conf.message = message;
		showAlertMessage(ref conf);
	}

	public static void ShareIOS(string body, string subject, string url, string[] filePaths)
	{
		SocialSharingStruct conf = new SocialSharingStruct();
		conf.text = body;
		string paths = string.Join(";", filePaths);
		if (string.IsNullOrEmpty(paths))
			paths = url;
		else if (!string.IsNullOrEmpty(url))
			paths += ";" + url;
		conf.filePaths = paths;
		conf.subject = subject;

		showSocialSharing(ref conf);
	}
#endif
}
