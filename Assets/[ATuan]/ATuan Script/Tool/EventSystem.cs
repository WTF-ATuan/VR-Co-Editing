using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class EventSystem : UnityEvent<Object> { }
[System.Serializable]
public class DataEvent<T> : UnityEvent<T> { }


   
