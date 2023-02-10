using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : Health
{
    [SerializeField] private int _restorePlayerHp;
    public int RestorePlayerHp 
    { 
        get 
        {
            return _restorePlayerHp;
        }
        private set{}
    }
    public void Finished()
    {
        base.TakeHit(_currentHp);
    }
    //TODO:
    // ENEMY HPBAR
}
