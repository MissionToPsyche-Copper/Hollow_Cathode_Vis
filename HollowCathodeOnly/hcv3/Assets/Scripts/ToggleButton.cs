using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : MonoBehaviour
{
    public Material[] material;
    Renderer rend;
    GameObject hollowCathode;


    void start() {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        
    }

    public void ChangeMat(string mat) {
        
    }




}
