using UnityEngine;
using System.Collections;


public class FixFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0,0,5);

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (target != null)
            transform.position = target.position + offset;
	}
}
