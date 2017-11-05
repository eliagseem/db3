using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstBehavior : MonoBehaviour {

    [SerializeField] GameObject prefab;
    [SerializeField] [Range(1f, 200f)] float drawDistance = 50f;

    GameObject drawObject;
    bool drawing = false;
    Vector3 mouseStartingPosition;

    Camera cam;

    void Start()
    {
        // load our camera
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if we want to start, end, or continue drawing
        if (Input.GetMouseButtonDown(0))
        {
            startDraw();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            endDraw();
        }
        else if (drawing)
        {
            whileDrawing();
        }
    }

    void startDraw()
    {
        // create a new instance
        drawObject = prefab as GameObject;

        // save our draw starting point
        mouseStartingPosition = Input.mousePosition;

        // put the new instance where we pointed to with a set distance (or collision)
        Ray ray = cam.ScreenPointToRay(mouseStartingPosition);
        //drawObject.transform.position = drawObject.transform.position + ray.GetPoint(drawDistance);

        // allow the Update to call whileDrawing()
        drawing = true;
    }

    void endDraw()
    {
        // forbid the Update do call whileDrawing()
        drawing = false;
    }

    void whileDrawing()
    {
        // manipulate the instance in whatever way you like
        float mouseDistance = Vector3.Distance(mouseStartingPosition, Input.mousePosition);
        drawObject.transform.localScale = new Vector3(mouseDistance / 100, mouseDistance/100, mouseDistance / 100);
    }
}
