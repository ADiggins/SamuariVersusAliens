using UnityEngine;
using System.Collections;

public class NinjaBasicController : MonoBehaviour
{
    public SFGCharacterMotor myMotor;
    public float flipInterval;

    private float flipClock;

	// Use this for initialization
	void Start ()
    {
        myMotor = GetComponent<SFGCharacterMotor>();
        flipClock = flipInterval;
        myMotor.hVector.x = 0.5f;        
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        HandleClock();
    }

    void HandleClock()
    {
        if(flipClock > 0)
        {
            flipClock -= Time.deltaTime;
        }
        else
        {
            myMotor.hVector.x *= -1;
            flipClock = flipInterval;
        }
    }
}
