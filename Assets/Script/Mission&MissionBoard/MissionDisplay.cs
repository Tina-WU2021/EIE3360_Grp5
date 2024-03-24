using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MissionDisplay : MonoBehaviour
{
    public TMP_Text missionText;
    public Button missionMenuExpandButton;

    //for display accross scenes
    private static MissionDisplay instance;
    private bool missionInterfaceActive = false;

    //for record current(MissionInferface return to) scene
    private string previousScene;

    private void Awake()
    {
        // Ensure only one instance of MissionDisplay exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Prevent the MissionDisplay GameObject from being destroyed when loading a new scene
        }
        else
        {
            Destroy(gameObject);
        }
        // Record the initial scene when the MissionDisplay is loaded
        previousScene = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        DisplayActivatedMissions();
    }

    public void DisplayActivatedMissions()
    {
        string activatedMissionsText = "";

        MissionManager missionManager = MissionManager.Instance;

        foreach (Mission mission in missionManager.missionsList.Values)
        {
            if (mission.activated)
            {
                activatedMissionsText += mission.missiondetail + "\n";
            }
        }

        // missionText.text = "Tasks:" + "\n" + activatedMissionsText;
        missionText.text = activatedMissionsText;
    }

    // public void ExpandMissionMenu()
    // {
    //     string currentScene = SceneManager.GetActiveScene().name;
    //     Debug.Log("currentScene" + currentScene);

    //     if (currentScene != "MissionInterface")
    //     {
    //         // Load the MissionInterface scene since the current scene is not MissionInterface
    //         SceneManager.LoadScene("MissionInterface", LoadSceneMode.Additive);
    //     }
    //     else
    //     {
    //         // Go back to the previous scene since the current scene is MissionInterface
    //         SceneManager.LoadScene(previousScene, LoadSceneMode.Additive);
    //     }
    // }

    public void ExpandMissionMenu()
    {
        if (!missionInterfaceActive)
        {
            // Add the MissionInterface scene since it is not active
            SceneManager.LoadScene("MissionInterface", LoadSceneMode.Additive);
            missionInterfaceActive = true;
        }
        else
        {
            // Remove the MissionInterface scene since it is already active
            SceneManager.UnloadSceneAsync("MissionInterface");
            missionInterfaceActive = false;
        }
    }
}
