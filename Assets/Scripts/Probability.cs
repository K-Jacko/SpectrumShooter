using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Probability : MonoBehaviour
{
    public float[] prob;
    
    private int numOfTiers = 3;
    private float[] TierWeights;
    private float startMinTier = 0;
    private float startMaxTier = 1;
    private float startPeakTier = 2;

    private float endMinTier = 1;
    private float endMaxTier = 3;
    private float endPeakTier = 2;
    private float maxWeight = 10;

    public float minT;
    public float maxT;
    public float peakT;
    public float Weight;

    private void Start()
    {
        TierWeights = new float[(int)SceneDirector.Instance.maxMobs];
        prob = new float[(int)SceneDirector.Instance.maxMobs];
    }

    // Update is called once per frame
    void Update()
    {
        CalculateProbability();
    }
    
    void CalculateProbability()
    {
        var time = (float)SceneDirector.Instance.waveTimer.Elapsed.TotalSeconds;
        minT += 10 * ((endMinTier - startMinTier) / (time* 2 ));
        maxT += 10 * ((endMaxTier - startMaxTier) / (time * 2));
        peakT += 10 * ((endPeakTier - startPeakTier) / (time * 2));


        for (int T = 0; T < numOfTiers; T++)
        {
            if (T < minT)
                Weight = 0;
            if (T > maxT)
                Weight = 0;
            if (minT <= T & T < peakT)
            {
                Weight = 1 + (maxWeight - 1) / (peakT - minT) * (T - minT);
            }

            if (peakT <= T & T < maxT)
            {
                Weight = 1 + (maxWeight - 1) / (peakT - maxT) * (T - maxT);
            }

            TierWeights[T] = Weight;
            prob[T] = Weight / TierWeights.Sum();
        }
    }

    public int PickMob()
    {
        var p = Random.Range(0f, 1f);
        float sumProb = 0;
        for (int i = 0; i < numOfTiers; i++)
        {
            sumProb += prob[i];
            if (sumProb >= p)
            {
                return i;
            }
        }

        return 0;
    }
}
