using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] private GameObject _PlayerPrefabs;
    [HideInInspector] public GameObject _Player;
    
    public int m_NumRoundsToWin = 5;        
    public float m_StartDelay = 3f;         
    public float m_EndDelay = 3f;           
    public CameraControl m_CameraControl;   
    public Text m_MessageText;              
    public GameObject m_TankPrefab;         
    private List<TankManager> m_Tanks = new List<TankManager>();           
    
    private int m_RoundNumber;             
    private TankManager m_RoundWinner;
    private TankManager m_GameWinner;

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
            m_Tanks.Add(tmp);
        }

        SpawnAllTanks();

        GameLoop();
    }
    
    private void SpawnAllTanks()
    {
        for (int i = 0; i < m_Tanks.Count; i++)
        {
            m_Tanks[i]._Instance =
                Instantiate(m_TankPrefab, m_Tanks[i]._SpawnPoint.position, m_Tanks[i]._SpawnPoint.rotation);
            m_Tanks[i].Setup();
            
            EnemyManager.Instance.EnemyInstance.Add(m_Tanks[i]._Instance);
        }
    }

    async void GameLoop()
    {
        await RoundStarting();
        await RoundPlaying();
        await RoundEnding();

        if (m_GameWinner != null)
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
        
        m_CameraControl.SetStartPositionAndSize();
        
        m_RoundNumber++;
        m_MessageText.text = "ROUND " + m_RoundNumber;

        await UniTask.Delay(TimeSpan.FromSeconds(m_StartDelay));
    }

    private async UniTask RoundPlaying()
    {
        EnableTankControl();
        
        m_MessageText.text = string.Empty;

        while (!IsPlayerDead())
        {
            await UniTask.Yield();
        }
    }
    
    private async UniTask RoundEnding()
    {
        DisableTankControl();
        
        m_RoundWinner = null;

        m_RoundWinner = GetRoundWinner();

        if (m_RoundWinner != null)
        {
            m_RoundWinner._Wins++;
        }

        m_GameWinner = GetGameWinner();

        string message = EndMessage();
        m_MessageText.text = message;

        await UniTask.Delay(TimeSpan.FromSeconds(m_EndDelay));
    }

    private bool IsPlayerDead()
    {
        return false;
        return _Player.activeSelf;
    }
    
    private TankManager GetRoundWinner()
    {
        for (int i = 0; i < m_Tanks.Count; i++)
        {
            if (m_Tanks[i]._Instance.activeSelf)
                return m_Tanks[i];
        }

        return null;
    }
    
    private TankManager GetGameWinner()
    {
        for (int i = 0; i < m_Tanks.Count; i++)
        {
            if (m_Tanks[i]._Wins == m_NumRoundsToWin)
                return m_Tanks[i];
        }

        return null;
    }

    private string EndMessage()
    {
        string message = "DRAW!";

        if (m_RoundWinner != null)
            message = m_RoundWinner._ColoredPlayerText + " WINS THE ROUND!";

        message += "\n\n\n\n";

        for (int i = 0; i < m_Tanks.Count; i++)
        {
            message += m_Tanks[i]._ColoredPlayerText + ": " + m_Tanks[i]._Wins + " WINS\n";
        }

        if (m_GameWinner != null)
            message = m_GameWinner._ColoredPlayerText + " WINS THE GAME!";

        return message;
    }

    private void ResetAllTanks()
    {
        for (int i = 0; i < m_Tanks.Count; i++)
        {
            m_Tanks[i].Reset();
        }
    }

    private void EnableTankControl()
    {
        for (int i = 0; i < m_Tanks.Count; i++)
        {
            m_Tanks[i].EnableControl();
        }
    }

    private void DisableTankControl()
    {
        for (int i = 0; i < m_Tanks.Count; i++)
        {
            m_Tanks[i].DisableControl();
        }
    }
}