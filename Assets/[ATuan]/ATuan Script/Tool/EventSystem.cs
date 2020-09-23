using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class EventSystem : UnityEvent<Object> { }
public class DataEvent<T> : UnityEvent<T> { }

   
