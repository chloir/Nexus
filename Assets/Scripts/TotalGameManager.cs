using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Security.Cryptography;

public class TotalGameManager : MonoBehaviour
{
    private int destroyedEnemy = 0;

    public void AddDestroyedEnemy(int diff)
    {
        destroyedEnemy += diff;
    }

    public int GetDestroyedEnemy()
    {
        return destroyedEnemy;
    }
}
