using UnityEngine;
using System.Collections;

public class SPlatformerCharacterController : MonoBehaviour
{

    public KeyCode dirFlip = KeyCode.Q;
    public KeyCode jumpKey = KeyCode.W;
    public KeyCode attack = KeyCode.O;
    public KeyCode throwAttack = KeyCode.P;


    public SFGCharacterMotor myMotor;
    public bool autoAssign = false;

    [System.Serializable]
    public class AxisRestrictor
    {
        public bool x;
        public bool y;
        public bool z;

    }
    public AxisRestrictor axisRestrictions;

    private bool jumping = false;
    private Vector2 hVector = Vector3.zero;
    private Vector3 originalPos;
    Rigidbody rBody;

    public void Init()
    {
        if (myMotor == null)
            myMotor = gameObject.GetComponent<SFGCharacterMotor>();

        originalPos = transform.position;

        //apply the fighter's constraint settings to the rigidbody;
        if (rBody == null)
            rBody = myMotor.GetComponent<Rigidbody>();

        rBody.constraints = RigidbodyConstraints.None;

        if (axisRestrictions.x)
            rBody.constraints = rBody.constraints | RigidbodyConstraints.FreezePositionX;

        if (axisRestrictions.y)
            rBody.constraints = rBody.constraints | RigidbodyConstraints.FreezePositionY;

        if (axisRestrictions.z)
            rBody.constraints = rBody.constraints | RigidbodyConstraints.FreezePositionZ;

        //assume rotation restriction
        rBody.constraints = rBody.constraints | RigidbodyConstraints.FreezeRotation;
    }

    // Use this for initialization
    void Start ()
    {
        if (autoAssign)
        {
            Init();
        }

        hVector.x = 1;
    }

    // Update is called once per frame
    void Update()
    {
        ManageKeys();
        SyncWithCharacterMotor();
        AxisRestrict();
    }

    void ManageKeys()
    {


        if(Input.GetKeyDown(dirFlip))
        {
            hVector.x *= -1;
        }

        if (Input.GetKeyDown(attack))
        {
            myMotor.GetComponent<AttackManager>().StartAttack(0);
        }


        jumping = Input.GetKeyDown(jumpKey);

    }

    void SyncWithCharacterMotor()
    {
        if (myMotor != null)
        {
            myMotor.hVector = hVector;
            myMotor.jumpSwitch = jumping;
        }
    }

    void AxisRestrict()
    {
        Vector3 newPos = transform.position;

        if (axisRestrictions.x)
        {
            newPos.x = originalPos.x;
        }

        if (axisRestrictions.y)
        {
            newPos.y = originalPos.y;
        }

        if (axisRestrictions.z)
        {
            newPos.z = originalPos.z;
        }

        transform.position = newPos;
    }
}
