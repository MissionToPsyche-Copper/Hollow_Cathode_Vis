using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : MonoBehaviour
{
    public Material[] material;
    Renderer rend;
    GameObject hollowCathode;
    public Material mat1;
    public Material mat2;


    // void start() {
    //     rend = GetComponent<Renderer>();
    //     rend.enabled = true;
    //     rend.sharedMaterial = material[0];
    //     hollowCathode = GameObject.Find("Hollow Cathode");
    //     mat1=Resources.Load("transparentMat") as Material;
    //     hollowCathode.GetComponent<MeshRenderer>().material = mat1;
    // }

    public void ChangeMat() {

        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        hollowCathode = GameObject.Find("Hollow Cathode");



        if (hollowCathode.GetComponent<MeshRenderer>().material == mat1) {
            mat2=Resources.Load("solidMat") as Material;
            hollowCathode.GetComponent<MeshRenderer>().material = mat2;
        } else if (hollowCathode.GetComponent<MeshRenderer>().material == mat2) {
            mat1=Resources.Load("transparentMat") as Material;
        hollowCathode.GetComponent<MeshRenderer>().material = mat1;
        }
    }




}
