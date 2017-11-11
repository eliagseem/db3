using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClickScript : MonoBehaviour
{

    [SerializeField] GameObject table;
    [SerializeField] GameObject computer;
    [SerializeField] GameObject text;
    [SerializeField] GameObject particle1;
    [SerializeField] GameObject particle2;
    [SerializeField] GameObject endParticle;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform);
                if (hit.transform.name == "BigText")
                {
                    table.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    computer.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    text.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    particle1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    particle2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    endParticle.GetComponent<Animator>().SetBool("flipUp", true);

                    Destroy(gameObject);
                }
            }
        }
    }
}
