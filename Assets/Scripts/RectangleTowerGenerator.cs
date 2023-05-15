using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RectangleTowerGenerator : TowerGenerator
{
    public InputField widthField, depthField, heightField;
    // Start is called before the first frame update
    void Start()
    {
        towerCard = GameObject.Find("RectangleTowerCard");
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        generation(width, depth, height);
        endClause();
    }

    public void setWidthFromInputField()
    {
        setWidth(int.Parse(widthField.text));
    }

    public void setDepthFromInputField()
    {
        setDepth(int.Parse(depthField.text));
    }

    public void setHeightFromInputField()
    {
        setHeight(int.Parse(heightField.text));
    }

    public void resetRectangleTower()
    {
        //if (this.gameObject.transform.childCount > 0)
        //{
            foreach (Transform child in towerCard.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            resetBrickPosition();
            GameBehaviour.setFinishedConstruction(false);
            total = 0;
            this.gameObject.SetActive(false);
        //}
    }

    public void endClause()
    {
        if (total >= (height * (width + depth) * 2))
        {
            makeTowerKinematic();
            GameBehaviour.setFinishedConstruction(true);
            this.gameObject.SetActive(false);
        }
    }
}
