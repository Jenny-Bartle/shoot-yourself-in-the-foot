using UnityEngine;
using System.Collections;
using Assets.Utility;

public class Foot : MonoBehaviour {

    private float moveDelay = 2f;
    private float moveDelta;
    private float lastMoveTime = 0;
    private Vector3 dest;
    private Rigidbody rigidBody;

    public CharacterController playerController;

    public bool IsShot;

    // Use this for initialization
    void Start () {
        lastMoveTime = System.DateTime.Now.Second;
        moveDelta = 1 / moveDelay;
        rigidBody = GetComponent<Rigidbody>();
        dest = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        lastMoveTime += Time.deltaTime;
        if (lastMoveTime > moveDelay)
        {
            var ccPos = playerController.transform.position;
            var rand = VectorUtil.CreateRandomUnitVectorXZPlane();

            // Only move if going away from player
            if (Vector3.Distance(ccPos, transform.position) < Vector3.Distance(ccPos, (transform.position + rand)))
            {
                dest = rand * 2;
                lastMoveTime = 0;
            }
        }
        Move(dest);
    }

    protected void Move(Vector3 end)
    {
        var sqrRemainingDistance = (transform.position - end).sqrMagnitude;
        var pos = Vector3.MoveTowards(transform.position, end, 0.1f);// moveDelta * Time.deltaTime);
        rigidBody.MovePosition(pos);
        var rotate = Vector3.RotateTowards(transform.position, end, 1f, 0f);
        rigidBody.rotation = Quaternion.LookRotation(rotate);
    }
}
