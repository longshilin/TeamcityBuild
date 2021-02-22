using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class AutoBuild
{
    [MenuItem("Build/BuildApk")]
    public static void BuildApk()
    {
        TestBuild.BuildApk();
    }
}

public class TestBuild
{
    public static void BuildApk()
    {
        // PlayerSettings.Android.keystoreName = "文件完整路径";
        // PlayerSettings.Android.keystorePass = "密码";
        // PlayerSettings.Android.keyaliasName = "别名";
        // PlayerSettings.Android.keyaliasPass = "别名密码";

        var outdir = Environment.CurrentDirectory + "/BuildOutPutPath/Android";
        var outputPath = Path.Combine(outdir, Application.productName + ".apk");
//文件夹处理
        if (!Directory.Exists(outdir)) Directory.CreateDirectory(outdir);
        if (File.Exists(outputPath)) File.Delete(outputPath);

//开始项目一键打包
        string[] scenes = new[] {"Assets/Scenes/SampleScene.unity"};
        BuildPipeline.BuildPlayer(scenes, outputPath, BuildTarget.Android, BuildOptions.None);
        if (File.Exists(outputPath))
        {
            Debug.Log("Build Success :" + outputPath);
        }
        else
        {
            Debug.LogException(new Exception("Build Fail! Please Check the log! "));
        }
    }
}