/*
Script for Simple Fighting Game
By IGDA Macquarie University

*/

using UnityEngine;
using System.Collections;

public class ScalableLego : MonoBehaviour
{
    public GameObject [] beginPieces;
    public GameObject[] midPieces;
    public GameObject [] endPieces;

    public int size;
    public Vector3 beginPieceDelta = new Vector3(0, 5, 0);
    public Vector3 midPieceDelta = new Vector3(0, 5, 0);
    public Vector3 endPieceDelta = new Vector3(0, 5, 0);

    // Use this for initialization
    void Start ()
    {
        Generate();
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public static GameObject RandomSpawn(ref GameObject [] list, Vector3 pos, Transform parent)
    {
        int spawnIndex = Random.Range(0, list.Length);
        GameObject newPiece = Instantiate(list[spawnIndex], pos, Quaternion.identity) as GameObject;

        if (parent != null)
            newPiece.transform.parent = parent;

        return newPiece;
    }

    [ContextMenu("Generate")]   
    public void Generate()
    {
        KillChildren();

        GameObject piece;
        Vector3 spawnPos = transform.position + beginPieceDelta;
        piece = RandomSpawn(ref beginPieces, spawnPos, transform);

        for (int i = 0; i < size; i++)
        {
            spawnPos += midPieceDelta;
            piece = RandomSpawn(ref midPieces, spawnPos, transform);
           
        }

        spawnPos += endPieceDelta;
        piece = RandomSpawn(ref endPieces, spawnPos, transform);
    }

    [ContextMenu("Clear")]
    public void KillChildren()
    {
        
        while(transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }

}
