using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin_EffectManager : MonoBehaviour
{
    public GameObject dolphin_ringPass_Effect;
    public GameObject dolphin_eat_Effect;
    public GameObject fish_dead_Effect;

    private void Start()
    {
        
    }

    public GameObject GetRingPass_Effect()
    {
        return dolphin_ringPass_Effect;
    }
    public GameObject GetEat_Effect()
    {
        return dolphin_eat_Effect;
    }
    public GameObject GetDead_Effect()
    {
        return fish_dead_Effect;
    }
}
