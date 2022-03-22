using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class camControls2 : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private float rotationSpeed = 0.1f;
    [SerializeField] private float zoomSpeed = 5.0f;

    [SerializeField] private KeyCode anchoredMoveKey = KeyCode.Mouse2;
    [SerializeField] private KeyCode anchoredRotateKey = KeyCode.Mouse0;

    [SerializeField] private KeyCode fRotateKey = KeyCode.W;
    [SerializeField] private KeyCode bRotateKey = KeyCode.S;
    [SerializeField] private KeyCode lRotateKey = KeyCode.A;
    [SerializeField] private KeyCode rRotateKey = KeyCode.D;

    [SerializeField] public float xAngle, yAngle, zAngle;
    [SerializeField] private float degreeStep = 60f;

    Vector3 OriginalPos;
    public Transform target;

    private void FixedUpdate()
    {
        Vector3 move = Vector3.zero;   
        Vector3 targetDirection = target.position -transform.position;
        float step = degreeStep * Time.deltaTime;
        Vector3 targetPos = target.transform.position;

        if (Input.GetKey(fRotateKey))
        {
            // target.transform.Rotate(Vector3.left * rotationSpeed);
            transform.RotateAround(target.transform.position,Vector3.left, degreeStep*Time.deltaTime);
        }
        if (Input.GetKey(bRotateKey))
        {
            // target.transform.Rotate(Vector3.right * rotationSpeed);
            transform.RotateAround(target.transform.position,Vector3.right, degreeStep*Time.deltaTime);
        }
        if (Input.GetKey(lRotateKey))
        {
            target.transform.Rotate(Vector3.up * rotationSpeed);
        }

        if (Input.GetKey(rRotateKey))
        {
            target.transform.Rotate(Vector3.down * rotationSpeed);
        }

        float mouseMoveY = Input.GetAxis("Mouse Y");
        float mouseMoveX = Input.GetAxis("Mouse X");

        if(Input.GetKey(anchoredMoveKey))
            {
                move += Vector3.up * mouseMoveY * moveSpeed;
                move += Vector3.right * mouseMoveX * moveSpeed;
            }

        if(Input.GetKey(anchoredRotateKey))
            {
                transform.RotateAround(transform.position,transform.right, mouseMoveY * -rotationSpeed);
                transform.RotateAround(transform.position, Vector3.up, mouseMoveX * -rotationSpeed);
            }


        transform.Translate(move);

    }

    private void LateUpdate()
    {
        float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate (Vector3.forward * mouseScroll * zoomSpeed);
    }

    // public void ResetObject(){
    //     target.transform.position = OriginalPos;
    // }

    // void Start() {
    //     OriginalPos = target.transform.position;
    // }

    // function ResetObject() {

    // }




}
