using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GamePlay : MonoBehaviour
{
    public static GamePlay instance;
    
    private void Awake()
    {
        instance = this;
    }
    public float playTime;
    public VideoPlayer vp;
    void Start()
    {
        Play();
    }
    void Update()
    {
        playTime += Time.deltaTime;
    }

    private void Play()
    {
        GameManager.instance.NextState();
        StartCoroutine(E_Play());
    }

    IEnumerator E_Play()
    {
        NoteManager.instance.StartSpawn();
        yield return new WaitForSeconds(NoteManager.instance.noteFallingTime);
        vp.clip = SongSelector.instance.clip;
        vp.Play();
    }
    public void Stop()
    {
        vp.Stop();
        NoteManager.instance.StopSpawn();
    }
}
