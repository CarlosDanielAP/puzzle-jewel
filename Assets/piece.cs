using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piece : MonoBehaviour {
    float distance = 9;
    public bool firstMove;
    public GameObject gameManager;
    private Transform[] spaces;

    void Start()
    {
        firstMove = true;
        spaces= gameManager.GetComponent<Manager>().spaces;

    }

    void Update()
    {
        if (firstMove)
        {
            if (Vector2.Distance(transform.position, spaces[0].transform.position) < 0.5f)
            {
                Debug.Log("cerca");
                //si no esta ocupado lo tomamos
                if (spaces[0].GetComponent<space>().empty)
                {
                    //si soltamos la pieza ocupa el lugar del espacio
                    if (Input.GetMouseButtonUp(0))
                    {
                        Debug.Log("ocupar");
                        transform.position = new Vector3(spaces[0].transform.position.x, spaces[0].transform.position.y, transform.position.z);
                        //ahora el espacio esta ocupado y ya no podemos mover esta pieza
                        spaces[0].GetComponent<space>().empty = false;
                        firstMove = false;

                    }
                }
            }
        }
        
       
    }

    void OnMouseDrag()
    {

        if (firstMove)
        {


            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
    }

}
