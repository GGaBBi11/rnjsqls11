using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public static GamePlay instance;
    
    private void Awake()
    {
        instance = this;
    }
    
    void Start()
    {

    }
    void Update()
    {
        playTime += Time.deltaTime;
    }
}
