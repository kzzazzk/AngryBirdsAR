using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public static int ballsThrown = 0;
    private GameObject spherePrefab, ball, ARCamera;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity += new Vector3(0, -18.6f, 0);
        spherePrefab = Resources.Load("Ball") as GameObject;
        ARCamera = GameObject.Find("ARCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameBehaviour.finishedContruction && !GameBehaviour.gameOver)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.fingerId == 0)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        ball = Instantiate(spherePrefab, new Vector3(ARCamera.transform.position.x, ARCamera.transform.position.y - 40, ARCamera.transform.position.z), ARCamera.transform.rotation) as GameObject;
                        ball.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 100000, ForceMode.Force);
                        ballsThrown++;
                        ball.hideFlags = HideFlags.HideInHierarchy;
                        Destroy(ball, 5f);
                    }
                }
            }
        }
    }
}
