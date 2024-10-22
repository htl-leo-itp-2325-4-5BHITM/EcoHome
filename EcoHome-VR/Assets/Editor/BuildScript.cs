using UnityEditor;

public class BuildScript
{
    public static void BuildGame()
    {
        // Specify the scenes included in the build
        string[] scenes = new string[]
        {
            "Assets/Scenes/Challenge - Main Scene.unity",  // Adjust this to your scene paths
            "Assets/Scenes/Linear - Main Scene.unity",
            "Assets/Scenes/Main Menu - Main Scene"
        };

        // Specify the build target and options
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = scenes,
            locationPathName = "../EcoHome-Build/StandaloneWindows64/Build.exe",  // Save the build outside the Unity Project folder
            target = BuildTarget.StandaloneWindows64,  // Adjust for your platform
            options = BuildOptions.None
        };

        // Build the player
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }
}
