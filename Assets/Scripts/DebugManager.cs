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

    void Awake()
    {
        Inst = this;
        DontDestroyOnLoad(this);
    }
}
