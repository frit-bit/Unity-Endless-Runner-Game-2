using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    [Header("Segments Setup")]
    public List<Segment> segments;     // List of different segments (prefab + length)

    [Header("Player")]
    public Transform player;           // Player Transform
    public int piecesOnScreen = 5;     // How many pieces ahead

    private float spawnZ = 0f;
    private int lastSegmentIndex = 0;
    private List<GameObject> activeSegments = new List<GameObject>();

  
    void Start()
    {
        for (int i = 0; i < piecesOnScreen; i++)
            SpawnSegment();
    }
   
    void Update()
    {
        if (player.position.z > (spawnZ - piecesOnScreen * AverageLength() + 40))
        {
            SpawnSegment();
            DeleteOldSegment();
        }
    }

    void SpawnSegment()
    {
        Segment segmentData = segments[RandomSegmentIndex()];
        GameObject go = Instantiate(segmentData.segmentObject, Vector3.forward * spawnZ, Quaternion.identity);
        activeSegments.Add(go);

        spawnZ += segmentData.length; // Move forward by this segment’s length
    }

    void DeleteOldSegment()
    {
        Destroy(activeSegments[0]);
        activeSegments.RemoveAt(0);
    }

    int RandomSegmentIndex()
    {
        if (segments.Count <= 1) return 0;

        int index;
        do { index = Random.Range(0, segments.Count); }
        while (index == lastSegmentIndex);

        lastSegmentIndex = index;
        return index;
    }

    float AverageLength()
    {
        if (segments.Count == 0) return 20f;
        float total = 0f;
        foreach (Segment s in segments)
            total += s.length;
        return total / segments.Count;
    }
}
[System.Serializable]
public class Segment
{
    public GameObject segmentObject;
    public float length;
   
}