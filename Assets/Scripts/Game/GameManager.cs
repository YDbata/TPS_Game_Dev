using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    None,
    Login,
    WaitUntilResourcesLoaded,
    Home,
    Tutorial
}


public class GameManager : SingletonMonoBase<GameManager>
{
    [field: SerializeField] public bool isTesting { get; private set; }
    public GameState state{
        get => _state;
        set
        {
            if (value == _state)
                return;

            _state = value;
        }
    }

    [SerializeField] private GameState _state;
    
    override protected void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Workflow();
    }

    private void Workflow()
    {
        switch (_state)
        {
            case GameState.None:
                break;
            case GameState.Login:
                SceneManager.LoadScene("Login");
                _state++;
                break;
            case GameState.WaitUntilResourcesLoaded:
                SceneManager.LoadScene("Home");
                _state++;
                break;
            case GameState.Home:
                break;
            case GameState.Tutorial:
                SceneManager.LoadScene("Tutorial");
                break;
            default:
                break;
        }
    }
}
