using UnityEngine;

public class InstBehavior : MonoBehaviour {

    [SerializeField] GameObject prefab;
    [SerializeField] GameObject topPlane;
    [SerializeField] GameObject bottomPlane;
    [SerializeField] Light deskLight;
    [SerializeField] [Range(1f, 200f)] float drawDistance = 50f;
    [SerializeField] Light spotlight;
    [SerializeField] Light backLight;


    GameObject drawObject;
    bool drawing = false;
    Vector3 mouseStartingPosition;
    bool cubeClicked = false;
    Camera cam;
    float sizeMorphing = 0f;
    Animator anim;

    void Start()
    {
        cam = GetComponent<Camera>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        drawObject = prefab as GameObject;

        if (sizeMorphing == 1)
            sizeMorphing += 0.01f;
        else
            sizeMorphing -= 0.0f;

        deskLight.transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            mouseStartingPosition = Input.mousePosition;
            Ray ray = cam.ScreenPointToRay(mouseStartingPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "frontPlane")
                {
                    drawObject.GetComponent<Rigidbody>().AddForce(new Vector3(10, 500, 0));
                }
                else if (hit.transform.name == "mouseCube")
                {
                    foreach (Collider c in topPlane.GetComponents<Collider>())
                    {
                        c.enabled = false;
                    }

                    cubeClicked = true;
                    anim.SetBool("scene2", true);
                }
            }
        }

        if (cubeClicked)
        {

            spotlight.color = Color.red;
            spotlight.intensity = 10f;
            spotlight.range = 12;

            backLight.color = Color.red;
            deskLight.color = Color.red;
        }
    }
}
