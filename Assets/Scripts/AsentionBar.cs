using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsentionBar : MonoBehaviour
{
    public GameManager gamemanager;

    private Button button;
    int QuantAs;
    double ascention = 0;
    double nextAscention;

    void Start() {
        ascention = gamemanager.Totaltoast;
        button = GetComponent<Button>();
        nextAscention = 1000000;
    }

    void Update() {
        if(QuantAs > 0){
            button.interactable = true;
        }
        else button.interactable = false;


        if(ascention >= nextAscention){
            nextAscention = nextAscention * 4;
            QuantAs++;
        }
    }



}
