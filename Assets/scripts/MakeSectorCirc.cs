using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeSectorCirc : MonoBehaviour
{

    public float value = 1f;
    public Color[] sectorColors;
    public Image sectorPrefab;

    void Start()
    {
        MakeSectors();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeSectors()
    {
        float zRot = 0f;
        for (int i = 0; i < value; i++)
        {
            Image newSector = Instantiate(sectorPrefab) as Image;
            newSector.transform.SetParent(transform, false);
            newSector.color = sectorColors[i % 2];
            newSector.fillAmount = (1 / value);
            newSector.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, zRot));
            zRot -= newSector.fillAmount * 360f;
        }
    } 
}
