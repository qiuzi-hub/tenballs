using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawCircle : MonoBehaviour
{
    LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        
        line = GetComponent<LineRenderer>();//获取LineRenderer组件
        line.loop = true;//线循环
        line.startWidth = line.endWidth = 0.05f;//线的宽度
        line.startColor = line.endColor = GetComponent<SpriteRenderer>().color;//线的颜色
        line.positionCount = 36;//由线构成圆
        float radius = transform.position.magnitude;//圆的半径
        float angle = 360 / line.positionCount;//计算每个点之间的角度差,以便在循环中设置圆上各个点的位置
        line.material = Resources.Load<Material>("Materials/Circle");
        for(int i = 0; i < line.positionCount; i++)//设置线段各个点的坐标
        {   //angle 乘以 i，可以得到当前点相对于起始点的角度偏移量，相当于角度，在三角函数中的参数通常用弧度
            float curAngle = i * angle * Mathf.Deg2Rad;// PI/180//计算当前点的角度，角度转弧度

            //利用三角函数（正弦和余弦），计算出当前点在 x 和 y 方向上的坐标，并乘以圆的半径得到最终的点坐标
            line.SetPosition(i, new Vector3(Mathf.Sin(curAngle), Mathf.Cos(curAngle),0)*radius);   
        }
    }
}
