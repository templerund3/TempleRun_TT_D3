using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MoveObject : MonoBehaviour
{

    //Class xử lý xự di chuyển của một đối tượng

    public enum TypeMove
    {
        None,
        MoveToDirection,
        MoveToDirectionWithAction,
        MoveToCheckPoint
    }

    private TypeMove typeMove;//Kiểu di chuyển
    private Vector2 directionMove;//Hướng di chuyển
    private Vector3 checkPoint;//Điểm đến 
    private UnityAction actionToCome;//Hành động diễn ra sau khi đến đích 
    private bool startMove;//Cho phép di chuyển
    private Vector3 posFirst;
    private Vector3 myScale;
    private float remingdistance;//Khoảng cách còn lại 

    public float speedMove;//Tốc độ di chuyển

    private void Start()
    {
        posFirst = this.transform.position;
        myScale = this.transform.localScale;
    }

    void Update()
    {
        if (startMove)
            MoveHandle();
    }

    /// <summary>
    /// Xử lý di chuyển
    /// </summary>
    private void MoveHandle()
    {
        switch (typeMove)
        {
            case TypeMove.MoveToCheckPoint:
                //transform.transform.Translate(directionMove * speedMove * Time.deltaTime);
                //Debug.Log("Distance " + Vector3.Distance(this.checkPoint, this.transform.position));
                transform.position = Vector3.Lerp(this.transform.position, checkPoint, speedMove);

                if (Vector2.Distance(this.checkPoint, this.transform.position) <= remingdistance)
                    if (actionToCome != null)
                    {
                        actionToCome();
                        Stop();
                    }
                break;
            case TypeMove.MoveToDirection:
                transform.Translate(directionMove * speedMove * Time.deltaTime);
                break;
            case TypeMove.MoveToDirectionWithAction:
                transform.Translate(directionMove * speedMove * Time.deltaTime);
                break;
        }
    }

    /// <summary>
    /// Đi theo một hướng
    /// </summary>
    /// <param name="dir">Hướng</param>
    public void MoveToDirection(Vector3 dir)
    {
        typeMove = TypeMove.MoveToDirection;
        directionMove = dir;
        startMove = true;
    }

    /// <summary>
    /// Đi theo một hướng
    /// </summary>
    /// <param name="dir">Hướng</param>
    public IEnumerator MoveToDirectionWithAction(Vector3 dir, float timeLife, UnityAction action, bool isStop = false)
    {
        typeMove = TypeMove.MoveToDirectionWithAction;
        directionMove = dir;
        actionToCome = action;
        startMove = true;

        yield return new WaitForSeconds(timeLife);

        action();
        if (isStop)
            Stop();
    }

    /// <summary>
    /// Đi đến một điểm xác định 
    /// </summary>
    /// <param name="checkPoint">Điểm đến</param>
    /// <param name="remingdistance">Khoảng cách gần nhất đến điểm đích để gọi hàm Stop</param>
    /// <param name="actionToCome">Hành động diễn ra sau khi đến điểm đã xác định </param>
    public void MoveToCheckPoint(Vector2 checkPoint, float remingdistance, UnityAction actionToCome = null)
    {
        typeMove = TypeMove.MoveToCheckPoint;
        this.checkPoint = checkPoint;
        directionMove = checkPoint - new Vector2(this.transform.position.x, this.transform.position.y);
        this.remingdistance = remingdistance;
        if (actionToCome != null)
            this.actionToCome = actionToCome;

        startMove = true;
    }

    public void Stop()
    {
        startMove = false;
        this.transform.position = posFirst;
        typeMove = TypeMove.None;
        this.gameObject.SetActive(false);
        this.remingdistance = 0;
        this.transform.localScale = myScale;
        actionToCome = () => { };
    }

}
