using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Fields
    public static GameManager Instance;
    
    [SerializeField] private GameObject _PlayerPrefabs;
    [HideInInspector] public GameObject _Player;
    
    public int _NumRoundsToWin = 5;        
    public float _StartDelay = 3f;         
    public float _EndDelay = 3f;           
    public CameraControl _CameraControl;   
    public Text _MessageText;              
    public GameObject _TankPrefab;         
    private List<TankManager> _Tanks = new List<TankManager>();           
    
    private int _RoundNumber;             
    private TankManager _RoundWinner;
    private TankManager _GameWinner;
    #endregion

    private void Awake()
    {
        Instance = this;
        _Player = Instantiate(_PlayerPrefabs);
    }

    private void Start()
    {
        List<Transform> enemyTransformList = EnemyManager.Instance.SpawnPointPositions;
        foreach (var item in enemyTransformList)
        {
            TankManager tmp = new TankManager();
            tmp._SpawnPoint = item;
            _Tanks.Add(tmp);
        }

        SpawnAllTanks();

        GameLoop();
    }
    
    private void SpawnAllTanks()
    {
        for (int i = 0; i < _Tanks.Count; i++)
        {
            _Tanks[i]._Instance =
                Instantiate(_TankPrefab, _Tanks[i]._SpawnPoint.position, _Tanks[i]._SpawnPoint.rotation);
            _Tanks[i].Setup();
            
            EnemyManager.Instance.EnemyInstanceList.Add(_Tanks[i]._Instance);
        }
    }

    async void GameLoop()
    {
        await RoundStarting();
        await RoundPlaying();
        await RoundEnding();

        if (_GameWinner != null)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            GameLoop();
        }
    }

    private async UniTask RoundStarting()
    {
        ResetAllTanks();
        DisableTankControl();
        
        _CameraControl.SetStartPositionAndSize();
        
        _RoundNumber++;
        _MessageText.text = "ROUND " + _RoundNumber;

        await UniTask.Delay(TimeSpan.FromSeconds(_StartDelay));
    }

    private async UniTask RoundPlaying()
    {
        EnableTankControl();
        
        _MessageText.text = string.Empty;

        while (!IsPlayerDead())
        {
            await UniTask.Yield();
        }
    }
    
    private async UniTask RoundEnding()
    {
        DisableTankControl();
        
        _RoundWinner = null;

        _RoundWinner = GetRoundWinner();

        if (_RoundWinner != null)
        {
            _RoundWinner._Wins++;
        }

        _GameWinner = GetGameWinner();

        string message = EndMessage();
        _MessageText.text = message;

        await UniTask.Delay(TimeSpan.FromSeconds(_EndDelay));
    }

    private bool IsPlayerDead()
    {
        // TODO: Detect the dead event
        return false;
    }
    
    private TankManager GetRoundWinner()
    {
        for (int i = 0; i < _Tanks.Count; i++)
        {
            if (_Tanks[i]._Instance.activeSelf)
                return _Tanks[i];
        }

        return null;
    }
    
    private TankManager GetGameWinner()
    {
        for (int i = 0; i < _Tanks.Count; i++)
        {
            if (_Tanks[i]._Wins == _NumRoundsToWin)
                return _Tanks[i];
        }

        return null;
    }

    private string EndMessage()
    {
        string message = "DRAW!";

        if (_RoundWinner != null)
            message = _RoundWinner._ColoredPlayerText + " WINS THE ROUND!";

        message += "\n\n\n\n";

        for (int i = 0; i < _Tanks.Count; i++)
        {
            message += _Tanks[i]._ColoredPlayerText + ": " + _Tanks[i]._Wins + " WINS\n";
        }

        if (_GameWinner != null)
            message = _GameWinner._ColoredPlayerText + " WINS THE GAME!";

        return message;
    }

    private void ResetAllTanks()
    {
        for (int i = 0; i < _Tanks.Count; i++)
        {
            _Tanks[i].Reset();
        }
    }

    private void EnableTankControl()
    {
        for (int i = 0; i < _Tanks.Count; i++)
        {
            _Tanks[i].EnableControl();
        }
    }

    private void DisableTankControl()
    {
        for (int i = 0; i < _Tanks.Count; i++)
        {
            _Tanks[i].DisableControl();
        }
    }
}