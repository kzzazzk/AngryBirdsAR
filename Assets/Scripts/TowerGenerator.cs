using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class TowerGenerator : MonoBehaviour
{
    public int width;
    public int depth;
    public int height;

    protected float scaleX;

    private Vector3 x_axis_translation;
    private Vector3 y_axis_translation;
    private Vector3 z_axis_translation;

    private Vector3 microAdjustmentA = new Vector3(0.5f, 0, 0.5f);
    private Vector3 microAdjustmentB = new Vector3(1.5f, 0, 1.5f);

    protected GameObject brickPrefab, towerCard, brick;
    protected Vector3 brickPosition;
    private GameObject trigger;

    public static int total = 0;
    private int x = 0;
    private int sum = 0;
    private int z = 0;
    private bool isOrientedLeftToRight = true;
    private bool isWritingXRow = true;
    private bool secondRow = false;

    // Start is called before the first frame update
    public void Start()
    {
        TimeController.outOfBounds = true;
        trigger = GameObject.Find("FloatingTrigger");
        brickPrefab = Resources.Load("Brick") as GameObject;
        scaleX = brickPrefab.transform.localScale.x / 2;

        x_axis_translation = new Vector3(2, 0, 0) * scaleX;
        y_axis_translation = new Vector3(0, 1, 0) * scaleX;
        z_axis_translation = new Vector3(0, 0, 2) * scaleX;

        brickPosition = new Vector3(-1.5f * (width / 2 * scaleX), scaleX / 2, -2 * (depth / 2 * scaleX));

        setOnFloor(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generation(int width, int depth, int height)
    {
        if (isWritingXRow)
        {
            if (isInBound(x, width) && isOnFloor())
            {
                setOnFloor(false);
                placeBrick(x_axis_translation);
                setFloorBricks(width, depth);
                x++;
                sum++;
            }

            if (!isInBound(x, width))
            {
                x = 0;
                isWritingXRow = !isWritingXRow;

                // Update brickPosition based on orientation and row position
                if (isOrientedLeftToRight)
                    brickPosition += (secondRow ? Vector3.Scale(microAdjustmentA, Vector3.one - 2 * Vector3.right) : Vector3.Scale(microAdjustmentB, Vector3.one - 2 * Vector3.right)) * scaleX;
                else
                    brickPosition += (secondRow ? Vector3.Scale(microAdjustmentA, Vector3.one - 2 * Vector3.forward) : Vector3.Scale(microAdjustmentB, Vector3.one - 2 * Vector3.forward)) * scaleX;

                isOrientedLeftToRight = !isOrientedLeftToRight;
            }
        }
        else
        {
            if (isInBound(z, depth) && isOnFloor())
            {
                setOnFloor(false);
                placeBrick(z_axis_translation);
                setFloorBricks(width, depth);
                z++;
                sum++;
            }

            if (!isInBound(z, depth))
            {
                z = 0;
                isWritingXRow = !isWritingXRow;

                // Update brickPosition based on orientation and row position
                if (!isOrientedLeftToRight)
                    brickPosition += (secondRow ? Vector3.Scale(microAdjustmentA, Vector3.one - 2 * Vector3.right - 2 * Vector3.forward) : Vector3.Scale(microAdjustmentB, Vector3.one - 2 * Vector3.right - 2 * Vector3.forward)) * scaleX;
                else
                {
                    brickPosition += (secondRow ? Vector3.Scale(microAdjustmentA, Vector3.one + 2 * Vector3.right) : Vector3.Scale(microAdjustmentA, Vector3.one + 2 * Vector3.forward)) * scaleX;
                    secondRow = !secondRow;
                }
            }
        }

        if (sum != 0 && (sum % ((width + depth) * 2) == 0))
        {
            total += sum;
            sum = 0;
            trigger.GetComponent<TriggerBehaviour>().elevate();
            brickPosition += y_axis_translation;
            setOnFloor(true);
        }
    }
    public void placeBrick(Vector3 translation)
    {
        brick = Instantiate(brickPrefab, brickPosition, transform.rotation) as GameObject;
        Renderer brickRenderer = brick.GetComponentInChildren<Renderer>(true);
        brickRenderer.material.color = Random.ColorHSV(0f, 0.025f, 0.7f, 1f, 0.6f, 1f);
        brick.transform.parent = towerCard.transform;
        //brick.hideFlags = HideFlags.HideInHierarchy;
        if (isWritingXRow)
            brickPosition += isOrientedLeftToRight ? translation : -translation;
        else
        {
            brick.transform.Rotate(Vector3.up * (isOrientedLeftToRight ? 90f : -90f));
            brickPosition += isOrientedLeftToRight ? -translation : translation;
        }
    }

    public void setWidth(int width)
    {
        this.width = width;
    }

    public void setHeight(int height)
    {
        this.height = height;
    }

    public void setDepth(int depth)
    {
        this.depth = depth;
    }


    public bool isOnFloor()
    {
        return TriggerBehaviour.arrived;
    }
    public bool isInBound(int axis, int measure)
    {
        return (axis < measure);
    }

    public void setOnFloor(bool value)
    {
        TriggerBehaviour.arrived = value;
    }

    public void setFloorBricks(int horizontalDim1, int horizontalDim2)
    {
        if (total <= (horizontalDim1 + horizontalDim2) * 2)
            brick.GetComponent<BrickBehaviour>().currentState = BrickBehaviour.DemolitionCuatriState.HIT_BY_BALL;
    }

    public void makeTowerKinematic()
    {
        foreach (Transform child in towerCard.transform)
        {
            child.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    public void resetBrickPosition()
    {
        brickPosition = new Vector3(-1.5f * (width / 2 * scaleX), scaleX / 2, -2 * (depth / 2 * scaleX));
    }
}
