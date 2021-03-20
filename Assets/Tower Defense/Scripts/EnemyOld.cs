using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOld : MonoBehaviour
{
  public Path route;
  private Waypoint[] myPathThroughLife;
  public int coinWorth;
  public float health;
  public float speed = .25f;
  private int index = 0;
  private Vector3 nextWaypoint;
  private bool stop = false;

  void Awake()
  {
    myPathThroughLife = route.path;
    transform.position = myPathThroughLife[index].transform.position;
    Recalculate();
  }

  void Update()
  {
    if (!stop)
    {
      if ((transform.position - myPathThroughLife[index + 1].transform.position).magnitude < .1f)
      {
        index = index + 1;
        Recalculate();
      }


      Vector3 moveThisFrame = nextWaypoint * Time.deltaTime * speed;
      transform.Translate(moveThisFrame);
    }

  }

  void Recalculate()
  {
    if (index < myPathThroughLife.Length -1)
    {
      nextWaypoint = (myPathThroughLife[index + 1].transform.position - myPathThroughLife[index].transform.position).normalized;

    }
    else
    {
      stop = true;
    }
  }
}
