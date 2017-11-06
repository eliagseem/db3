using UnityEngine;

public class InstBehavior : MonoBehaviour {

    [SerializeField] GameObject prefab;
    [SerializeField] GameObject topPlane;
    [SerializeField] GameObject bottomPlane;
    [SerializeField] Light deskLight;
    [SerializeField] [Range(1f, 200f)] float drawDistance = 50f;
    [SerializeField] Light spotlight;

    GameObject drawObject;
    bool drawing = false;
    Vector3 mouseStartingPosition;
    bool cubeClicked = false;
    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        deskLight.transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            drawObject = prefab as GameObject;
            mouseStartingPosition = Input.mousePosition;
            Ray ray = cam.ScreenPointToRay(mouseStartingPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "frontPlane")
                {
                    drawObject.GetComponent<Rigidbody>().AddForce(new Vector3(00, 500, 0));
                }
                else if (hit.transform.name == "Cube")
                {
                    foreach (Collider c in topPlane.GetComponents<Collider>())
                    {
                        c.enabled = false;
                    }

                    cubeClicked = true;
                }
            }
        }

        if (cubeClicked)
        {

            spotlight.color = Color.white;
            spotlight.intensity = 33f;
            spotlight.range = 12;

            deskLight.color = Color.blue;
        }
    }
}
