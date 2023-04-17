using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbadge_collector : MonoBehaviour
{

    public GameObject plastic_trashbin, glass_trashbin, paper_trashbin, metal_trashbin;
    Vector3 newPosition, tbPos, plastic_trashbinPos, glass_trashbinPos, metal_trashbinPos, paper_trashbinPos;
    // Start is called before the first frame update
    void Start()
    {
        plastic_trashbin = GameObject.Find("TrashBin_plastic");
        glass_trashbin = GameObject.Find("TrashBin_pp");
        metal_trashbin = GameObject.Find("TrashBin_glass");
        paper_trashbin = GameObject.Find("TrashBin_b");
        plastic_trashbinPos = plastic_trashbin.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        newPosition = Vector3.Lerp(transform.position, plastic_trashbinPos, Time.deltaTime * 2);
        transform.position = newPosition;
        Debug.Log(transform.position);
    }
}
