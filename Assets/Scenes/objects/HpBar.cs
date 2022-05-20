using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public GameObject parent;

    private Block block;
    private Slider slider;
    private GameObject camera;

    void Start()
    {
        this.gameObject.transform.position = parent.gameObject.transform.position;
        block = parent.GetComponent<Block>();
        slider = this.gameObject.transform.Find("slider").transform.GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = (float)block.hp_current/ (float)block.hp_max;

        if (slider.value <= 0)
            Destroy(this.gameObject);

        camera = GameObject.Find("MainCamera"); 
        transform.rotation = camera.transform.rotation;
    } 
}
