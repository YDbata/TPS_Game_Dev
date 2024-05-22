using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
	[Header("All Menus")]
	public GameObject PauseMenuUI;
	public GameObject EndGameMenuUI;
	public GameObject ObjectivesMenuUI;
	public MissionComplete missionComplete;

	public static bool GameisStopped = false;
	public static bool ShootButtonClicked = false;
	public static bool InteractionButtonClicked = false;

	private void Awake()
	{
		missionComplete.Init();
        DontDestroyOnLoad(gameObject);
	}

	public void Pause()
	{
		PauseMenuUI.SetActive(true);
		Time.timeScale = 0;
		//Cursor.lockState = CursorLockMode.None;
		GameisStopped = true;
	}

	public void Resume()
	{
		PauseMenuUI.SetActive(false);
		Time.timeScale = 1;
		//Cursor.lockState = CursorLockMode.Locked;
		GameisStopped = false;
	}

	public void ReStart()
	{
		SceneManager.LoadScene("MainGame");
	}

	public void LoadMenu()
	{
		SceneManager.LoadScene("Menu");
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
