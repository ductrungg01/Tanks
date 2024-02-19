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

    public float _StartDelay = 3f;
    public float _EndDelay = 3f;
    public CameraControl _CameraControl;
    public Text _MessageText;
    [FormerlySerializedAs("_TankPrefab")] public GameObject _EnemyTankPrefab;
    private List<TankManager> _EnemyTanks = new List<TankManager>();

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
            _EnemyTanks.Add(tmp);
        }

        SpawnAllTanks();

        GameLoop();
    }

    private void SpawnAllTanks()
    {
        for (int i = 0; i < _EnemyTanks.Count; i++)
        {
            _EnemyTanks[i]._Instance =
                Instantiate(_EnemyTankPrefab, _EnemyTanks[i]._SpawnPoint.position, _EnemyTanks[i]._SpawnPoint.rotation);
            _EnemyTanks[i].Setup();

            EnemyManager.Instance.EnemyInstanceList.Add(_EnemyTanks[i]._Instance);
        }
    }

    async void GameLoop()
    {
        await RoundStarting();
        await RoundPlaying();
        await RoundEnding();

        if (IsPlayerDead())
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

        _MessageText.text = "READY...";

        await UniTask.Delay(TimeSpan.FromSeconds(_StartDelay));
    }

    private async UniTask RoundPlaying()
    {
        EnableTankControl();

        _MessageText.text = string.Empty;

        while (!IsPlayerDead() && !NoEnemyLeft())
        {
            await UniTask.Yield();
        }
    }
    
    private async UniTask RoundEnding()
    {
        DisableTankControl();

        string message = EndMessage();
        _MessageText.text = message;

        await UniTask.Delay(TimeSpan.FromSeconds(_EndDelay));
    }

    private bool IsPlayerDead()
    {
        return this._Player.activeSelf == false;
    }

    private bool NoEnemyLeft()
    {
        foreach (var enemy in _EnemyTanks)
        {
            if (enemy._Instance.activeSelf == true) return false;   
        }

        return true;
    }

    private string EndMessage()
    {
        return (IsPlayerDead() ? "Game over!" : "You're winner!!!");
    }

    private void ResetAllTanks()
    {
        Destroy(this._Player);
        _Player = Instantiate(_PlayerPrefabs);
        
        for (int i = 0; i < _EnemyTanks.Count; i++)
        {
            _EnemyTanks[i].Reset();
        }
    }

    private void EnableTankControl()
    {
        for (int i = 0; i < _EnemyTanks.Count; i++)
        {
            _EnemyTanks[i].EnableControl();
        }
    }

    private void DisableTankControl()
    {
        for (int i = 0; i < _EnemyTanks.Count; i++)
        {
            _EnemyTanks[i].DisableControl();
        }
    }
}