using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVE : MonoBehaviour
{
    public float rotatespeed=0.5f;
  //  public Vector3 rotatrAngles;
    // Start is called before the first frame update
    void Start()
    {
        //rotatrAngles = Vector3.forward * rotatespeed;
    }

    // Update is called once per frame
    void Update()
    {
        /* Vector3 pos = transform.position;
         pos.x += 0.1f;//pos +=1;����ȡ����Ϊpos�Ǳ���
         transform.position = pos;*/

        //transform.Rotate(new Vector3(0, 0, 1)/vector3.forward);

        //�ı��ٶ�,����
       transform.Rotate(Vector3.forward * rotatespeed);
        
        
       // transform.Rotate(rotatrAngles);//����
    }
}
