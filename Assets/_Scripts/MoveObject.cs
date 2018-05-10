using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MoveObject : MonoBehaviour
{

    public bool startMove;

    void Update()
    {
        if (startMove)
            MoveToGameObject(GameManager.Instance.objPlayer.transform,1.5f);
        if (GameManager.Instance.objPlayer != null && GameManager.Instance.objPlayer.GetComponent<PlayerMovement>().IsMagnet())
        {
            if(Vector3.Distance(transform.position, GameManager.Instance.objPlayer.transform.position) <= 5f)
            {
                startMove = true;
            }
        }
    }

  

    /// <summary>
    /// Đi đến một điểm xác định 
    /// </summary>
    /// <param name="checkPoint">Điểm đến</param>
    /// <param name="remingdistance">Khoảng cách gần nhất đến điểm đích để gọi hàm Stop</param>
    /// <param name="actionToCome">Hành động diễn ra sau khi đến điểm đã xác định </param>
    public void MoveToGameObject(Transform checkPoint, float remingdistance)
    {
        transform.position =  Vector3.MoveTowards(transform.position, checkPoint.position, remingdistance);
    }


}
