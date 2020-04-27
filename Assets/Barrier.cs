using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barrier : MonoBehaviour
{
    public Text barrierHPText;
    public int barrierHP = 2;

    public void decreaseHP()
    {
        barrierHP--;
        barrierHPText.text = barrierHP.ToString();
        if (barrierHP == 0){
            Destroy(barrierHPText);
            Destroy(gameObject);
        }
   
    }

}
