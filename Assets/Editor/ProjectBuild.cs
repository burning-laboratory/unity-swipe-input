using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    public static class ProjectBuild
    {
        public static void BuildForAndroid()
        {
            var outdir = Environment.CurrentDirectory + "/Builds/Android";
            var outputPath = Path.Combine(outdir, Application.productName + ".apk");

            // Обработка папки
            if (!Directory.Exists(outdir)) Directory.CreateDirectory(outdir);
            if (File.Exists(outputPath)) File.Delete(outputPath);

            // Запускаем проект в один клик
            string[] scenes = {"Assets/BurningLab/SwipeDetector/Examples/Scenes/SwipeInputDemoScene.unity"};
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
}