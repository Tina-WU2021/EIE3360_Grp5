using System;
using UnityEngine;

public class TransSceneMissionManager : MonoBehaviour
{
    private static TransSceneMissionManager instance;
    private MissionManager missionManager;
    private MissionDisplay missionDisplay;

    // Event for mission completion
    public event Action OnMissionComplete;

    private void Awake()
    {
        // Ensure only one instance of TransSceneMissionManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Get references to MissionManager and MissionDisplay
        missionManager = FindObjectOfType<MissionManager>();
        missionDisplay = FindObjectOfType<MissionDisplay>();

        // Subscribe to mission completion event
        //missionManager.OnMissionComplete += HandleMissionComplete;
    }

    private void OnDestroy()
    {
        // Unsubscribe from mission completion event
        //missionManager.OnMissionComplete -= HandleMissionComplete;
    }

    private void Start()
    {
        // Set the initial mission display
        UpdateMissionDisplay();
    }

    // Event handler for mission completion
    private void HandleMissionComplete()
    {
        // Invoke the mission completion event
        OnMissionComplete?.Invoke();
    }

    public void UpdateMissionDisplay()
    {
        // if (missionDisplay != null)
        // {
        //     missionDisplay.UpdateMissionDisplay();
        // }
    }
}
