using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class PlanetManager : MonoBehaviour
{
    public GameObject planetPrefab;
    private GameObject sun=null;//确定点击是否是太阳
   // List<GameObject> planets;
    Queue<GameObject> planets;
    int planetIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        //  for(int i = 0; i < 10; i++)
        // {
        //GameObject planet =Instantiate(planetPrefab,transform);//实例化,在Start里就实例化一次,在场景中显示一次
        //planet.transform.Translate(Vector3.right * 1);planet摆放位置
        //}
        planets = new Queue<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //用if判断用planet赋值给太阳
            if (sun == null)
            {
                sun = Instantiate(planetPrefab, transform);//实例化
                sun.transform.position = Vector3.zero;//太阳的位置   
                sun.GetComponent<SpriteRenderer>().color = Color.yellow;//太阳的颜色
            }
            else
            {
                if (planets.Count >= 10)
                {
                   // Destroy(planets[0]);
                    Destroy(planets.Dequeue());//从队列的头部移除并返回一个元素
                }
            GameObject planet = Instantiate(planetPrefab, transform);//实例化
            //planets.Add(planet);
            planets.Enqueue(planet);//将一个元素添加到队列的末尾
            planet.name = "planet" + planetIndex;
            planetIndex++;
                // planet.transform.position = Input.mousePosition;//行星离得太远，不在当前摄像机能够显示的位置，所以用世界坐标，第一种方法
                Vector3 pos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);//从屏幕空间到世界空间,第二种方法，mousePosition是像素坐标（屏幕坐标）而transform是世界坐标
            //在转换的过程中z不固定，z为视线的方向
            pos.z = 0;
            planet.transform.position = pos;
            planet.GetComponent<SpriteRenderer>().color = Random.ColorHSV();//如果要随机颜色则用Random,ColorHSV();表色调，明度，饱和度，都随机；例如（0，1，1，1，1，1，1，1）括号里可以什么都不填/color.blue
            planet.transform.localScale = Vector3.one * Random.Range(0.2f, 0.3f);
           
                
            RotateCircle rc = planet.AddComponent<RotateCircle>();//添加RotateCircle组件代码
            rc.center = sun.transform;//中心点的位置
            rc.rotateSpeed= Random.Range(0.1f, 0.2f);//旋转速度
                                                     //画线：LineRenderer是一个组件
            planet.AddComponent<DrawCircle>();

            }


        }
    }
}
