using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    static public NoteManager instance;
    static public float noteFallingSpeed = 3f;

    Transform noteSpawnersTransfrom;
    Transform noteHittersTransform;
    public float noteFallingDistance
    {
        get { return noteSpawnersTransfrom.position.y - noteHittersTransform.position.y; }
    }

    public float noteFallingTime
    {
        get { return noteFallingDistance / noteFallingSpeed; }
    }

    Dictionary<KeyCode, NoteSpawner> spanwers = new Dictionary<KeyCode, NoteSpawner>();
    public Queue<NoteData> queue = new Queue<NoteData>();
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        noteSpawnersTransfrom = transform.Find("NoteSpawners");
        noteHittersTransform = transform.Find("NoteHitters");
        NoteSpawner[] tmpSpawners = noteSpawnersTransfrom.GetComponentsInChildren<NoteSpawner>();
        foreach (NoteSpawner spawner in tmpSpawners)
        {
            spanwers.Add(spawner.keyCode, spawner);
        }
        SetDataQueue(SongSelector.instance.songData.notes);

    }
    public void SetDataQueue(List<NoteData>notes)
    {
        // 람다식 표현
        // 콜렉션의 요소 두개를 파라미터로 받아서 우선순위 연산을 진행 하고 순서를 바꿈
        notes.Sort((x,y)=>x.time.CompareTo(y.time));
        foreach(NoteData note in notes)
            queue.Enqueue(note);
    }
    public void StartSpawn()
    {
        if (queue.Count > 0)
            StartCoroutine(E_SpawnNotes());
    }
    IEnumerator E_SpawnNotes()
    {
        while(queue.Count > 0)
        {
            for (int i = 0; i < queue.Count; i++)
            {
                if (queue.Peek().time < GamePlay.instance.playTime)
                {
                    NoteData data = queue.Dequeue();
                    spanwers[data.keycode].SpawnNote();
                }
                else
                    break;
            }
            yield return null;
        }
    }

    public void StopSpawn()
    {
        StopAllCoroutines();
    }
}
