using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    systemMove systemMove;
    [SerializeField]GameObject systemMoveObject;
    [SerializeField] List<GameObject> objectsToOff = new List<GameObject>();
    [SerializeField] List<GameObject> objectsToOn = new List<GameObject>();

    private void Start()
    {
        systemMove = systemMoveObject.GetComponent<systemMove>();
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && systemMove.isFinished) {

            systemMove.Success = true;
           
            foreach (GameObject obj in objectsToOff) {
                obj.SetActive(false);
            }
            foreach (GameObject obj in objectsToOn)
            {
                obj.SetActive(true);
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            systemMove.Success = false;
        }
    }
    
}
