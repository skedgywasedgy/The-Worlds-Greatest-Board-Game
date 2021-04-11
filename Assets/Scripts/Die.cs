using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class Die : MonoBehaviour {
    private Rigidbody body;

    public bool preRoll = false;

    public bool still = false;
    public int value = 0;

    private float stillTime = 1;

    private void Awake () {
        body = GetComponent<Rigidbody> ();
    }

    public void Roll () {
        body.velocity = new Vector3 (Random.Range (-10, 10), -Random.Range (20, 30), Random.Range (-10, 10));
        body.angularVelocity = new Vector3 (Random.Range (-50, 50), Random.Range (-50, 50), Random.Range (-50, 50));
        preRoll = false;
        body.useGravity = true;
    }

    public void StartPreRoll (Vector3 pos) {
        transform.position = pos + new Vector3 (Random.Range (-4, 4), 0, Random.Range (-4, 4));
        preRoll = true;
        body.useGravity = false;
        still = false;
    }

    private void FixedUpdate () {
        if (preRoll) {
            body.velocity = Vector3.zero;
            still = false;
            body.angularVelocity = new Vector3 (50 * Mathf.PerlinNoise (Time.timeSinceLevelLoad * 0.3f, 0), 50 * Mathf.PerlinNoise (0, Time.timeSinceLevelLoad * 0.3f), 50 * Mathf.PerlinNoise (Time.timeSinceLevelLoad * -0.3f, Time.timeSinceLevelLoad * -0.3f));
        } else {
            Vector3 xDir = transform.TransformDirection (Vector3.right);
            Vector3 yDir = transform.TransformDirection (Vector3.up);
            Vector3 zDir = transform.TransformDirection (Vector3.forward);
            float threshold = Mathf.Sqrt (0.5f);

            if (yDir.y >= threshold) {
                value = 6;
            } else if (yDir.y <= -threshold) {
                value = 1;
            } else if (xDir.y >= threshold) {
                value = 5;
            } else if (xDir.y <= -threshold) {
                value = 2;
            } else if (zDir.y >= threshold) {
                value = 3;
            } else {
                value = 4;
            }

            if (body.velocity.magnitude <= 0.05f && body.angularVelocity.magnitude <= 0.05f) {
                stillTime -= 0.02f;

                still = stillTime <= 0;
            } else {
                stillTime = 1;
                still = false;
            }

            if (body.position.y < -50) {
                body.position = new Vector3 (0, 10, 0);
            }
        }
    }
}