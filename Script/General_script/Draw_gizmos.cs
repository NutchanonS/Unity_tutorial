using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw_gizmos : MonoBehaviour
{
    void Draw_Waypoints_Bear()
    {
        GameObject go_draw_Bear = GameObject.FindGameObjectsWithTag("WayPoints_Bear")[0];

        foreach (Transform t_Bear in go_draw_Bear.transform)
        {
            //waypoints.Add(t);
            Gizmos.DrawWireSphere(t_Bear.position, 2);
        }
    }

    void Draw_Waypoints_Troll()
    {
        GameObject go_draw_Troll = GameObject.FindGameObjectsWithTag("WayPoints_Troll")[0];
        foreach (Transform t_Troll in go_draw_Troll.transform)
        {
            //waypoints.Add(t);
            Gizmos.DrawWireSphere(t_Troll.position, 2);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //List<Transform> waypoints_draw = new List<Transform>();
        Draw_Waypoints_Bear();
        Draw_Waypoints_Troll();

        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        //foreach (Transform t in waypoints)
        //{
        //    Vector3 tt = t.position;
        //    Gizmos.DrawWireSphere(tt, 10);
        //}
        //Gizmos.DrawWireSphere(agent.transform.position, 5);
    }
}
