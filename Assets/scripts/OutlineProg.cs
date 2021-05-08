using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OutlineProg : MonoBehaviour
{
    public Image outlinePrefab;
    public float progress = 0f;
    Image newOut;

    private void Start()
    {
        newOut = Instantiate(outlinePrefab) as Image;
        newOut.transform.SetParent(transform, false);
        newOut.fillAmount = progress;
    }

    void Update()
    {
        bool flag = FindObjectOfType<Sector>().flag;
        if (!flag)
        {
            progress += 0.1f * Time.deltaTime;
            if(progress <= 1.015f)
            {
                MakeOutline();
            }
            if(progress > 1.015f)
            {
                progress = 1.015f;
            }
        }
    }

    void MakeOutline()
    {
        newOut.fillAmount = progress;
    }
}
