using System.Collections.Generic;
using SA.Android.Utilities;
using SA.iOS.Utilities;
using SA.CrossPlatform.UI;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace SA.CrossPlatform
{
    public static class UM_SamplesManager
    { 
        private static readonly List<string> s_ExampleScenes= new List<string>
        {
            UM_Settings.WelcomeSamplesScenePath,
            UM_Settings.InAppSamplesScenePath,
            UM_Settings.GameServicesSamplesScenePath,
            UM_Settings.SharingSamplesScenePath,
            UM_Settings.NotificationsSamplesScenePath,
            UM_Settings.CameraAndGallerySamplesScenePath,
            UM_Settings.MedialPlayerSamplesScenePath,
            UM_Settings.FirebaseSamplesScenePath,
            UM_Settings.GIFSamplesScenePath,
        };

        public static void OpenWelcomeScene()
        {
            EditorSceneManager.OpenScene(UM_Settings.WelcomeSamplesScenePath, OpenSceneMode.Single);
        }

        public static void BuildWelcomeScene()
        {
            #if SA_DEVELOPMENT_PROJECT
            AN_TestManager.ApplyExampleConfig();
            ISN_TestManager.ApplyExampleConfig();
            #endif

            PlayerSettings.productName = "Ultimate Mobile";
            var playerOptions = new BuildPlayerOptions();
            playerOptions.scenes = s_ExampleScenes.ToArray();

            switch (EditorUserBuildSettings.activeBuildTarget)
            {
                case BuildTarget.iOS:
                    playerOptions.target = BuildTarget.iOS;
                    playerOptions.locationPathName = "ultimate_mobile_plugin";
                    break;
                case BuildTarget.Android:
                    playerOptions.target = BuildTarget.Android;
                    playerOptions.locationPathName = "ultimate_mobile_plugin.apk";
                    break;
                default:
                    UM_DialogsUtility.ShowMessage("Wrong Platform", "Make sure current editor platform set to iOS or Android");
                    break;
            }
          
            playerOptions.options = BuildOptions.Development | BuildOptions.AutoRunPlayer;
            BuildPipeline.BuildPlayer(playerOptions);
        }


        public static void IncludeToBuildSettings()
        {
            var missingScenes = new List<string>(s_ExampleScenes);

            foreach (var buildSettingsScene in  EditorBuildSettings.scenes)
            {
                if (s_ExampleScenes.Contains(buildSettingsScene.path))
                {
                    missingScenes.Remove(buildSettingsScene.path);
                }
            }
            
            var includes = new List<EditorBuildSettingsScene>();
            foreach (var missingScene in missingScenes)
            {
                var buildSettingsScene = new EditorBuildSettingsScene(missingScene, true);
                includes.Add(buildSettingsScene);
            }
            includes.AddRange(EditorBuildSettings.scenes);
            EditorBuildSettings.scenes = includes.ToArray();
        }
        
        public static void ExcludeFromSettings()
        {
            var includes = new List<EditorBuildSettingsScene>();

            foreach (var buildSettingsScene in  EditorBuildSettings.scenes)
            {
                if (!s_ExampleScenes.Contains(buildSettingsScene.path))
                {
                    includes.Add(buildSettingsScene);
                }
            }
            EditorBuildSettings.scenes = includes.ToArray();
        }
        
       
    }
}