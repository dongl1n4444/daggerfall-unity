using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    public static DebugManager Inst;

    public bool blockMonsterAtk;
    public bool monsterAtkHitChance;
    public int mosterAtkHitMod;
    public bool playerAtkHitChance;
    public int playerAtkHitMod;
    public bool debugPlrState;
    public int debugPlrStrength;
    public int debugPlrIntelligence;
    public int debugPlrWillpower;
    public int debugPlrAgility;
    public int debugPlrEndurance;
    public int debugPlrPersonality;
    public int debugPlrSpeed;
    public int debugPlrLuck;

    void Awake()
    {
        Inst = this;
        DontDestroyOnLoad(this);
    }
}
