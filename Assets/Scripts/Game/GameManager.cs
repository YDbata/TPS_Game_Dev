using System;
using System.Collections;
using System.Collections.Generic;
using TPSGame.Data;
using TPSGame.Data.Mock;
using TPSGame.Singleton;
using TPSGame.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState
{
    None,
    Login,
    LoadResources,
    WaitUntilResourcesLoaded,
    Home,
    BattleLoaded,
    Battle,
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

    [Header("Fade")] public Image fadeImg;
    [SerializeField] private float fadeDuration = 2;
    public AnimationCurve fadeCurve;
    
    public IUnitOfWork unitOfWork { get; private set; }
    
    [Header("CurState")]
    [SerializeField] private GameState _state;
    
    override protected void Awake()
    {
        base.Awake();
        Cursor.visible = false;
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
            case GameState.LoadResources:
                if (isTesting)
                    unitOfWork = new MockUnitOfWork();
                else
                    unitOfWork = null;//new UnitOfWork();
                //UIManager.instance.Register(UIBase);
                _state++;
                break;
            case GameState.WaitUntilResourcesLoaded:
                SceneManager.LoadScene("Home");
                _state++;
                break;
            case GameState.Home:
                break;
            case GameState.BattleLoaded:
                //StartCoroutine(Fade(0, 1,fadeDuration));
                SceneManager.LoadScene("Battle");
                //StartCoroutine(Fade(1, 0, 0.5f));
                _state++;
                break;
            case GameState.Battle:
                
                break;
            case GameState.Tutorial:
                break;
            default:
                break;
        }
    }

    private IEnumerator Fade(float start, float end, float fadeTime)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;
            Color color = fadeImg.color;
            color.a = Mathf.Lerp(start, end, fadeCurve.Evaluate(percent));
            Debug.Log(color.a);
            fadeImg.color = color;

            yield return null;
        }
    }
}
