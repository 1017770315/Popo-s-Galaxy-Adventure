using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetSwitch : MonoBehaviour
{
    public Transform gridTrans;
    private Object canvasPreb;
    private GameObject cvsPreb;
    // Start is called before the first frame update
    void Start()
    {
        gridTrans = GameObject.Find("Grid").transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Go planet");
            // 隐藏grid
            gridTrans.gameObject.SetActive(false);
            Destroy(this.gameObject); 
            // 根据当前物体的标签动态加载对话prefab   
            switch(this.gameObject.tag)
            {
                case "p1": canvasPreb = Resources.Load("Canvas1"); break;
                case "p2": canvasPreb = Resources.Load("Canvas2"); break;
                case "p3": canvasPreb = Resources.Load("Canvas3"); break;
                case "p4": canvasPreb = Resources.Load("Canvas4"); break;
                case "p5": canvasPreb = Resources.Load("Canvas5"); break;
                case "p6": canvasPreb = Resources.Load("Canvas6"); break;
                case "p7": canvasPreb = Resources.Load("Canvas7"); break;
                case "p8": canvasPreb = Resources.Load("Canvas8"); break;
                case "p9": canvasPreb = Resources.Load("Canvas9"); break;
                case "p10": canvasPreb = Resources.Load("Canvas10"); break;
                default: break;
            }
            cvsPreb = Instantiate(canvasPreb) as GameObject;
            cvsPreb.transform.parent = GameObject.Find("Map").transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
