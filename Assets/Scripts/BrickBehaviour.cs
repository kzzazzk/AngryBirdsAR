using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{
    public enum DemolitionCuatriState
    {
        NOT_HIT,
        HIT_BY_BALL,
        HIT_BY_BRICK,
        FALLEN
    }
    public DemolitionCuatriState currentState;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.name == "Ball(Clone)" && !currentState.Equals(DemolitionCuatriState.FALLEN))
            {
                currentState = DemolitionCuatriState.HIT_BY_BALL;
            }
            if (currentState.Equals(DemolitionCuatriState.HIT_BY_BALL) && collision.gameObject.name == "Brick(Clone)" && collision.gameObject.GetComponent<BrickBehaviour>().currentState.Equals(DemolitionCuatriState.NOT_HIT))
            {
                collision.gameObject.GetComponent<BrickBehaviour>().currentState = DemolitionCuatriState.HIT_BY_BRICK;
            }
            if ((currentState.Equals(DemolitionCuatriState.HIT_BY_BALL) || currentState.Equals(DemolitionCuatriState.HIT_BY_BRICK) || (currentState.Equals(DemolitionCuatriState.NOT_HIT))) && collision.gameObject.name == "Floor")
            {
                currentState = DemolitionCuatriState.FALLEN;
                GameBehaviour.fallenBricks++;
            }
    }
}
