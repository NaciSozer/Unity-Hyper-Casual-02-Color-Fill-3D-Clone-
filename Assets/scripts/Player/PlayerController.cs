using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Rigidbody myBody;

    int boxControl = 0;

    public Material green;
    public Material red;
    public Material white;

    public Vector3Int gridPosition;
    public float gridMoveTimer;
    public float gridMoveTimerMax;
    public Vector3Int gridMoveDirection;


    public Vector3 firsPos;
    public Vector3 lastPos;

    [SerializeField] bool canMove = true;



    void Start()
    {
        myBody = this.GetComponent<Rigidbody>();

        firsPos = transform.position;
        gridPosition = new Vector3Int(0, 1, -7);


        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = new Vector3Int(0, 0, 0);


    }

    
    void FixedUpdate()
    {
        Movement();
    }


    private void Movement()
    {

        if (Input.GetKey(KeyCode.W))
        {

            canMove = true;
            gridMoveDirection.x = 0;
            gridMoveDirection.y = 0;
            gridMoveDirection.z = 1;

        }
        if (Input.GetKey(KeyCode.S))
        {
            canMove = true;
            gridMoveDirection.x = 0;
            gridMoveDirection.y = 0;
            gridMoveDirection.z = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            canMove = true;
            gridMoveDirection.x = -1;
            gridMoveDirection.y = 0;
            gridMoveDirection.z = 0;
        }
        if (Input.GetKey(KeyCode.D))
        {
            canMove = true;
            gridMoveDirection.x = 1;
            gridMoveDirection.y = 0;
            gridMoveDirection.z = 0;
        }


        if (canMove == true)
        {
            gridMoveTimer += Time.deltaTime;
            if(gridMoveTimer >= gridMoveTimerMax)
            {
                gridPosition += gridMoveDirection;
                gridMoveTimer -= gridMoveTimerMax;
            }

            transform.position = new Vector3(gridPosition.x, gridPosition.y, gridPosition.z);
            //transform.Translate(gridPosition.x, gridPosition.y, gridPosition.z);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        if (collision.transform.CompareTag("White"))
        {
            canMove = false;
            Debug.Log(transform.position.z.ToString("f0"));
            transform.position = new Vector3(int.Parse(transform.position.x.ToString("f0")), int.Parse(transform.position.y.ToString("f0")), int.Parse(transform.position.z.ToString("f0")));
            gridPosition.x = (int)transform.position.x;
            gridPosition.y = (int)transform.position.y;
            gridPosition.z = (int)transform.position.z;
            firsPos = transform.position;
            Vector3 matris = lastPos - firsPos;

            var box = Physics.OverlapBox(new Vector3((firsPos.x + lastPos.x) / 2, -0.5f, (firsPos.z + lastPos.z) / 2), new Vector3(0.1f, 0.1f, 0.1f));
            FloodFill(box[0].gameObject);


            var boxes = GameObject.FindGameObjectsWithTag("Box");
            var yellowBox = GameObject.FindGameObjectsWithTag("Obstacle");
            foreach (var item in boxes)
            {
                if (item.GetComponent<MeshRenderer>().material.name == "red ")
                {
                    boxControl = 1;
                    break;
                }
            }
            foreach (var item in yellowBox)
            {
                if (item.GetComponent<MeshRenderer>().material.name == "yellow ")
                {
                    boxControl = 1;
                    break;
                }
            }
            Debug.LogError(boxControl);
            if (boxControl == 0)
            {
                SceneManager.LoadScene(1);

            }
            boxControl = 0;
            


            firsPos = lastPos;

        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    void FloodFill(GameObject startBox)
    {
        if (startBox.GetComponent<MeshRenderer>().material.name == "green " || startBox.GetComponent<MeshRenderer>().material.name == "white ")
        {
            return;
        }
        else if (startBox.GetComponent<MeshRenderer>().material.name == "red " || startBox.GetComponent<MeshRenderer>().material.name == "yellow ")
        {
            if (startBox.GetComponent<MeshRenderer>().material.name == "yellow ")
            {
                startBox.gameObject.tag = "Box";
                startBox.GetComponent<MeshRenderer>().material = green;
            }
            else
            {
                startBox.GetComponent<MeshRenderer>().material = green;

            }
        }
        var rightBox = Physics.OverlapBox(new Vector3(startBox.transform.position.x + 1, -0.5f, startBox.transform.position.z), new Vector3(0.1f, 0.1f, 0.1f));
        var leftBox = Physics.OverlapBox(new Vector3(startBox.transform.position.x - 1, -0.5f, startBox.transform.position.z), new Vector3(0.1f, 0.1f, 0.1f));
        var upBox = Physics.OverlapBox(new Vector3(startBox.transform.position.x, -0.5f, startBox.transform.position.z + 1), new Vector3(0.1f, 0.1f, 0.1f));
        var downBox = Physics.OverlapBox(new Vector3(startBox.transform.position.x, -0.5f, startBox.transform.position.z - 1), new Vector3(0.1f, 0.1f, 0.1f));
        if (rightBox.Length > 0)
        {
            FloodFill(rightBox[0].gameObject);
        }
        if (leftBox.Length > 0)
        {
            FloodFill(leftBox[0].gameObject);
        }
        if (downBox.Length > 0)
        {
            FloodFill(downBox[0].gameObject);
        }
        if (upBox.Length > 0)
        {
            FloodFill(upBox[0].gameObject);
        }


    }
}
