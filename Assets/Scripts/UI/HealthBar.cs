using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public Image FillAmount;
    public void GiveFullHealth()
	{
		//ü�¹ٰ� �� �� �� ���·� �ʱ�ȭ
		FillAmount.fillAmount = 1;
	}

	public void SetHealth(float healthPer)
	{
		FillAmount.fillAmount = healthPer;
	}
}
