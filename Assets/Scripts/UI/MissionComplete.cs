using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MissionComplete : MonoBehaviour
{
	[Header("Mission GUIs")]
	public TextMeshProUGUI Mission_1;
	public TextMeshProUGUI Mission_2;
	public TextMeshProUGUI Mission_3;
	public TextMeshProUGUI Mission_4;

	private bool mission_1_Completed = false;
	private bool mission_2_Completed = false;
	private bool mission_3_Completed = false;
	private bool mission_4_Completed = false;

	public static MissionComplete Instance;

	public void Init()
	{
		Instance = this;
	}

	public void UpdateMissionComplete(int index, bool result)
	{
		switch (index)
		{
			case 1:
				if (result)
				{
					mission_1_Completed = result;
					Mission_1.text = "1. Key Picked Up";
					Mission_1.color = Color.green;
				}
				break;
			case 2:
				if (result)
				{
					mission_2_Completed = result;
					Mission_2.text = "2. Computer is offline";
					Mission_2.color = Color.green;
				}
				break;
			case 3: 
				if (result)
				{
					mission_3_Completed = result;
					Mission_3.text = "3. Generator is offline";
					Mission_3.color = Color.green;
				}
				break;
			case 4:
				if (result)
				{
					mission_4_Completed = result;
					Mission_4.text = "4. Mission Completed";
					Mission_4.color = Color.green;
				}
				break;
		}
	}
}
