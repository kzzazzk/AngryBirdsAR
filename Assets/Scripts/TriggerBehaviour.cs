using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBehaviour : MonoBehaviour
{
    public static bool arrived;
    private float scaleY;
    private GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        prefab = Resources.Load("Brick") as GameObject;
        scaleY = prefab.transform.localScale.y / 2f;
        transform.position = new Vector3(0f, scaleY, 0f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider collision)
    {
        arrived = !arrived;
    }

    public void elevate()
    {
        transform.position += new Vector3(0, scaleY * 2, 0);
    }
    public void reset()
    {
        transform.position = new Vector3(0, scaleY, 0);
    }

}
