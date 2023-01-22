using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class SceneDirector : MonoBehaviour
{
    // Press button to start
    // Pattern launch animation 
    // Wave out prep wave in 
    // Pick list of mobs based on probablility
    // Wave in
    // mob spawns with random color 
    // half way through spawning the wave pattern starts 
    // after pattern completes gun activates
    // kill
    public static SceneDirector Instance;
    private GameObject[] mobs;
    private StateMachine stateMachine;
    public Stopwatch waveTimer;
    public int maxMobs = 3;
    
    void Start()
    {
        Instance = this;
        LoadMobs();
        InitWaveTimer();
        InitProbability();
        InitStateMachine();
    }

    void LoadMobs()
    {
        mobs = new GameObject[maxMobs];
        var allMobs = Resources.LoadAll("Mobs");
        
    }
    void InitProbability()
    {
        var probability = gameObject.AddComponent<Probability>();
        
    }
    void InitWaveTimer()
    {
        waveTimer = Stopwatch.StartNew();
    }
    void InitStateMachine()
    {
        stateMachine = new StateMachine();
        var InWave = new InWave(waveTimer);
        var OutWave = new OutWave(maxMobs, mobs);
        stateMachine.AddAnyTransition(InWave, () => waveTimer.Elapsed.Seconds >= 5);
        stateMachine.SetState(OutWave);
    }
    // Update is called once per frame
    void Update()
    {
        stateMachine.Tick();
    }
}
