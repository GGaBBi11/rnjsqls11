using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    static public NoteManager instance;
    public Transform noteSpawnersTransfrom;
    Dictionary<KeyCode, NoteSpawner> spanwers = new Dictionary<KeyCode, NoteSpawner>();
    public Queue<NoteData> queue = new Queue<NoteData>();
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        noteSpawnersTransfrom = transform.Find("NoteSpawners");
        NoteSpawner[] tmpSpawners = noteSpawnersTransfrom.GetComponentsInChildren<NoteSpawner>();
        foreach (NoteSpawner spawner in tmpSpawners)
        {
            spanwers.Add(spawner.keyCode, spawner);
        }
        SetDataQueue(SongSelector.instance.songData.notes);

    }
    public void SetDataQueue(List<NoteData>notes)
    {
        // ���ٽ� ǥ��
        // �ݷ����� ��� �ΰ��� �Ķ���ͷ� �޾Ƽ� �켱���� ������ ���� �ϰ� ������ �ٲ�
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
                if (queue.Peek().time < GamePlay.instance.palyTime)
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
}
