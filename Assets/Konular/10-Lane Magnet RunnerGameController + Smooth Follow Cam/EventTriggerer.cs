using UnityEngine;
using UnityEngine.EventSystems;



public class EventTriggerer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public delegate void PointerDelegate();
    public static event PointerDelegate OnRelease;
    public Controller controller;
    public void Awake()
    {
        OnRelease += controller.GoToClosestLane;
    }
    public void OnPointerUp(PointerEventData eventData) // Kaldırıldı
    {
        OnRelease.Invoke();
    }
    public void OnPointerDown(PointerEventData eventData) // Tıklandı
    {
       
    }
}
