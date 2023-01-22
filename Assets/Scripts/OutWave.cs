using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class OutWave : IState
{
    private float maxMobs;
    public GameObject[] mobs;
    public OutWave(float maxMobs, GameObject[] mobs)
    {
        this.maxMobs = maxMobs;
        this.mobs = mobs;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tick()
    {
        
    }

    public void OnEnter()
    {
        //setup moblist
        for (int i = 0; i < maxMobs; i++)
        {
            Object.Instantiate(mobs[i]);
        }
    }

    public void OnExit()
    {
        throw new System.NotImplementedException();
    }
}
