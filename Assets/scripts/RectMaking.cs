using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RectMaking : MonoBehaviour
{
    public Color[] colrs;
    public Image wedge;
    System.DateTime startTime;
    public float duration = 2f;
    float count = 0;
    public float value = 12f;
    public float shift = 1f;
    public float low = 10f;
    public float offset = 0f;

    float posX = 0;
    bool flag = true;
    float prevTime;
    float newTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = System.DateTime.UtcNow;
    }

    // Update is called once per frame
    void Update()
    {
        System.TimeSpan timeDel = System.DateTime.UtcNow - startTime;
        newTime = timeDel.Seconds;
        if (flag)
        {
            if (timeDel.Seconds > 0 && newTime % duration == 0 && newTime-prevTime >= 1f)
            {
                ShowSectUp(); count++; posX += shift; prevTime = newTime;
                if(count >= value)
                {
                    flag = false;
                }
            }
            if (timeDel.Seconds > 0 && newTime % duration == 1 && newTime - prevTime >= 1f)
            {
                ShowSectDown(); count++; posX += shift; prevTime = newTime;
                if (count >= value)
                {
                    flag = false;
                }
            }
        }
    }

    void ShowSectUp()
    {
        Image newWedge = Instantiate(wedge) as Image;
        newWedge.transform.SetParent(transform, false);
        newWedge.color = colrs[0];
        newWedge.fillAmount = 1 / value;
        newWedge.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 20f));
        newWedge.rectTransform.anchoredPosition = new Vector3(posX-offset, -1*low, 0);
    }

    void ShowSectDown()
    {
        Image newWedge = Instantiate(wedge) as Image;
        newWedge.transform.SetParent(transform, false);
        newWedge.color = colrs[1];
        newWedge.fillAmount = 1 / value;
        newWedge.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 200f));
        newWedge.rectTransform.anchoredPosition = new Vector3(posX, low, 0);
    }
}
