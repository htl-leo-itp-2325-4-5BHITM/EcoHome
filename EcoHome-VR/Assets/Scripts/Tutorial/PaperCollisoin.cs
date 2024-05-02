using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperCollisoin : MonoBehaviour
{
    private string paperTrashTag = "PaperTrash";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == paperTrashTag) {
            Debug.Log("Paper Collision");
        }
        else {
            Debug.Log("No Paper Collision");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
