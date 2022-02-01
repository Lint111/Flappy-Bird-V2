using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTriggerEffect : MonoBehaviour
{
    private ScoreHandeler scoreHandeler;

    private void Start() 
    {
        scoreHandeler = GameObject.Find("Canvas").GetComponent<ScoreHandeler>();        
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(!other.gameObject.CompareTag("Player")){return;}
        scoreHandeler.AddScore();        
    }
}
