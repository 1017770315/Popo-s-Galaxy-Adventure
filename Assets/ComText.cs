using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComText : MonoBehaviour
{
    public Transform trans;
    public int flag = 1; // 当前对话的编号
    private int time = 1;
    private int ratetime = 4;
    public GameObject root;
    public GameObject grid;
   
    void Awake()
    {
        trans = this.transform; // 获取当前组件（canvas）节点
        root = GameObject.Find("Map");
        grid = root.transform.Find("Grid").gameObject;
        // popoTrans = GameObject.Find("popo").transform;

        InvokeRepeating("ShowText", time, ratetime);
    }

    void ShowText() // 展示当前的对话
    {
        if (flag>1 && flag<5)
        {
            trans.Find((flag-1).ToString()).gameObject.SetActive(false);
            trans.Find(flag.ToString()).gameObject.SetActive(true);
            ++flag;
        } 
        else if (flag == 1)
        {
            trans.Find(flag.ToString()).gameObject.SetActive(true);
            ++flag;
        }
        else{
            // 获取Grid，复原Grid，同时删去本节点
            grid.SetActive(true);
            Destroy(this.gameObject);
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
