using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gongzhuan : MonoBehaviour
{
    public float rotatespeed = 0.5f;
    public Transform RotateCenter;//GameObjectҲ����

    // Start is called before the first frame update
    void Start()
    {
        //transform.gameObject/gameObject.transform
    }

    // Update is called once per frame
    void Update()
    {
        //transform.RotateAround(Vector3.zero);
        //�ض�����
        transform.RotateAround(RotateCenter.position, Vector3.forward, rotatespeed);
    }
}
