using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneLikeCamera : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private float rotationSpeed = 5.0f;
    [SerializeField] private float zoomSpeed = 5.0f;

    [Header("Focus Object")]
    [SerializeField] private float focusLimit = 100f;
    [SerializeField] private float minFocusDistance = 5.0f;
    private float doubleClickTime = 0.05f;
    private float cooldown = 0;

    [SerializeField] private KeyCode forwardKey = KeyCode.W;
    [SerializeField] private KeyCode backKey = KeyCode.S;
    [SerializeField] private KeyCode leftKey = KeyCode.A;
    [SerializeField] private KeyCode rightKey = KeyCode.D;

    [SerializeField] private KeyCode anchoredMoveKey = KeyCode.Mouse3;
    [SerializeField] private KeyCode anchoredRotateKey = KeyCode.Mouse2;
    

    




    // Update is called once per frame
    void Update()
    {
        if(cooldown > 0 && Input.GetKeyDown(KeyCode.Mouse0))
        FocusObject();
        if(Input.GetKeyDown(KeyCode.Mouse0))
        cooldown = doubleClickTime;

        cooldown -= Time.deltaTime;

    }
    
    private void FocusObject()
    {
        //throw new NotImplementedException();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,focusLimit))
        {
            GameObject target = hit.collider.gameObject;
            Vector3 targetPos = target.transform.position;
            Vector3 targetSize = hit.collider.bounds.size;

            //transform.position = targetPos + new Vector3(0,2,-5);
            //new Vector3(0,2,-5
            transform.position = targetPos + GetOffset(targetPos, targetSize);
            transform.LookAt(target.transform);
            


        }
        
    }

    private Vector3 GetOffset(Vector3 targetPos, Vector3 targetSize)
    {
        Vector3 dirToTarget = targetPos - transform.position;

        float focusDistance = Mathf.Max(targetSize.x,targetSize.z);

        focusDistance = Mathf.Clamp(focusDistance, minFocusDistance,focusDistance);

        return -dirToTarget.normalized * focusDistance;
    }



    private void FixedUpdate()
    {
        Vector3 move = Vector3.zero;
        if(Input.GetKey (forwardKey))
        move += Vector3.forward * moveSpeed;
        if(Input.GetKey (backKey))
        move += Vector3.back * moveSpeed;
        if(Input.GetKey (leftKey))
        move += Vector3.left * moveSpeed;
        if(Input.GetKey (rightKey))
        move += Vector3.right * moveSpeed;
        
        float mouseMoveY = Input.GetAxis("Mouse Y");
        float mouseMoveX = Input.GetAxis("Mouse X");
        
        if(Input.GetKey(anchoredMoveKey))
        {
            move += Vector3.up * mouseMoveY * -moveSpeed;
            move += Vector3.right * mouseMoveX * -moveSpeed;
            //move += Vector3.up * -mouseMoveY * moveSpeed;
            //move += Vector3.right * -mouseMoveX * moveSpeed;
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

}
