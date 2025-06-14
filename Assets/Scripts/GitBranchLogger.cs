using UnityEngine;
using System.Diagnostics;

public class GitBranchLogger : MonoBehaviour
{
    void Awake()
    {
#if UNITY_EDITOR
        string branchName = GetCurrentGitBranch();
        UnityEngine.Debug.Log("🌿 現在のブランチ: " + branchName);
#endif
    }

    string GetCurrentGitBranch()
    {
        try
        {
            var psi = new ProcessStartInfo("git", "rev-parse --abbrev-ref HEAD")
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = Application.dataPath + "/.."
            };

            var process = Process.Start(psi);
            string output = process.StandardOutput.ReadLine();
            process.WaitForExit();
            return output;
        }
        catch
        {
            return "ブランチ不明";
        }
    }
}
