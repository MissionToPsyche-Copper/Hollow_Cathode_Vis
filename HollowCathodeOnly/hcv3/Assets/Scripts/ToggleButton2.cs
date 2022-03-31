using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton2 : MonoBehaviour
{

    Renderer rend;
    GameObject hollowCathode;


    public void ChangeMat()
    {

        Material mat1 = Resources.Load("transparentMat", typeof(Material)) as Material;
        Material mat2 = Resources.Load("solidMat", typeof(Material)) as Material;
        hollowCathode = GameObject.Find("Hollow Cathode");
        hollowCathode.GetComponent<MeshRenderer>();
        rend = GetComponent<MeshRenderer>();
        rend.enabled = true;

        if (hollowCathode.GetComponent<MeshRenderer>().material = mat1)
        {
            hollowCathode.GetComponent<MeshRenderer>().material = mat2;

        }
        
        if (hollowCathode.GetComponent<MeshRenderer>().material = mat2)
        {
            hollowCathode.GetComponent<MeshRenderer>().material = mat1;
        }
    }




}
