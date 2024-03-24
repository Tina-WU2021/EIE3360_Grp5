using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interface_MissionList : MonoBehaviour
{
    public TMP_Text missionList;

    private void Update()
    {
        DisplayActivatedMissions();
    }

    public void DisplayActivatedMissions()
    {
        string activatedMissionsText = "";

        //should switch to the below line when production
        MissionManager missionManager = MissionManager.Instance;
        // MissionManager missionManager = FindObjectOfType<MissionManager>();
        //----------------------------------------------------------------

        List<Mission> missions = new List<Mission>(missionManager.missionsList.Values);

        int currentMissionIndex = -1;

        if (currentMissionIndex == -1)
        {
            missions.Sort((a, b) => a.missionIndex.CompareTo(b.missionIndex));
            currentMissionIndex = missions.FindIndex(mission => mission.activated);
        }
        Debug.Log("currentMissionIndex" + currentMissionIndex);

        foreach (Mission mission in missions)
        {
            string missionDetail = mission.missionDetail;

            if (mission.missionIndex < currentMissionIndex)
            {
                activatedMissionsText +=
                    "<color=#808080>" + "♦ " + missionDetail + "</color>" + "\n" + "\n";
            }
            else if (mission.missionIndex == currentMissionIndex)
            {
                activatedMissionsText +=
                    "<color=#FFFFFF>" + "♦ " + missionDetail + "</color>" + "\n" + "\n";
            }

            Debug.Log("activatedMissionsText" + activatedMissionsText);
        }

        missionList.text = activatedMissionsText;
    }
}
