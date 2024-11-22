using System;
using UnityEngine;


[RequireComponent(typeof(InputData))]
public class Level_Manager : MonoBehaviour
{
    private static Level_Manager _instance;

    /*
     *  This improves the Singleton by ensuring only one instance exists across scenes, preventing multiple instances from being created.
     */
    public static Level_Manager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<Level_Manager>();
            }
            return _instance;
        }
    }

    public Level Level_stage;

    public static event Action<Level> OnLevelChanged;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateLevel(Level.Level_1);
    }

    // Update is called once per frame
    void Update(){}

    public void UpdateLevel(Level newLevel)
    {
        switch (newLevel) {
            case Level.Level_1:
                this.Level_stage = Level.Level_1;
                break;
            case Level.Level_2:
                this.Level_stage = Level.Level_2;
            break;    
            case Level.Level_3:
                this.Level_stage = Level.Level_3;
            break;  
            case Level.Level_4:
                this.Level_stage = Level.Level_4;
            break;      
            case Level.Level_5:
                this.Level_stage = Level.Level_5;
            break;     
            case Level.Level_6:
                this.Level_stage = Level.Level_6;
            break;                           
            default:
                throw new ArgumentOutOfRangeException(nameof(newLevel), newLevel, null);
        }

        OnLevelChanged?.Invoke(newLevel);
    }
}

public enum Level {
    Level_1,
    Level_2,
    Level_3,
    Level_4,
    Level_5,
    Level_6
}