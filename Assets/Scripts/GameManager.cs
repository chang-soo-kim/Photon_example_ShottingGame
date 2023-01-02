using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameManager() {}

    private static GameManager inst;

    public static GameManager Inst
    {
        get
        {
            if (inst == null)
            {
                inst = FindObjectOfType<GameManager>();
                if(inst == null)
                {
                    inst = new GameObject("GameManager").AddComponent<GameManager>();
                }
            }
            return inst;
        }
    }

   //public bool gameOver = false;

  
}
