using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeBarricada : MonoBehaviour
{
    //A barricada tem dois materiais
    public Material _myMaterial1; 
    public Material _myMaterial2;

    //Color picker no unity
    public Color _myColor;
  
    void Start()
    {
        _myMaterial1.color = _myColor;
        _myMaterial2.color = _myColor;
    }


}
