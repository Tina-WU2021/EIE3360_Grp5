// using TMPro;
// using UnityEngine;

// public class MissionDisplay : MonoBehaviour
// {
//     public TMP_Text missionText;

//     private void Start()
//     {
//         // Get reference to the MissionManager instance
//         MissionManager missionManager = MissionManager.Instance;

//         if (missionManager != null)
//         {
//             // Subscribe to the mission completion event
//             missionManager.OnMissionComplete += UpdateMissionDisplay;

//             // Set the initial mission display
//             UpdateMissionDisplay();
//         }
//         else
//         {
//             Debug.Log("MissionManager not found in the scene.");
//         }
//     }

//     private void OnDestroy()
//     {
//         // Get reference to the MissionManager instance
//         MissionManager missionManager = MissionManager.Instance;

//         if (missionManager != null)
//         {
//             // Unsubscribe from the mission completion event
//             missionManager.OnMissionComplete -= UpdateMissionDisplay;
//         }
//     }

//     private void UpdateMissionDisplay()
//     {
//         // Get reference to the MissionManager instance
//         MissionManager missionManager = MissionManager.Instance;

//         if (missionManager != null)
//         {
//             int currentMissionIndex = missionManager.currentMissionIndex;

//             if (currentMissionIndex < missionManager.missions.Count)
//             {
//                 Mission currentMission = missionManager.missions[currentMissionIndex];

//                 // Update the mission text
//                 missionText.SetText("Current Mission: " + currentMission.name);
//             }
//             else
//             {
//                 // All missions completed
//                 Debug.Log("All missions completed!");
//             }
//         }
//         else
//         {
//             Debug.Log("MissionManager not found in the scene.");
//         }
//     }
// }
