using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnviromentStorage
{
    //private readonly SceneObjectConfig _config;
    private readonly IInstantiator _instantiator;

    private Dictionary<Type, SceneObject> _dict= new Dictionary<Type, SceneObject>();
    
    public EnviromentStorage(        
        IInstantiator instantiator
    )
    {        
        _instantiator = instantiator;
    }

    public T Get<T>() where T:SceneObject
    {
        var type = typeof(T);
        if(_dict.ContainsKey(type))
        {
            return _dict[type].GetComponent<T>();
        }
        Debug.LogError($"No spawned scene object with name [{type}]");
        return null;
    }

    public T Spawn<T>(string name, Transform parent = null) where T: SceneObject
    {
        var type = typeof(T);        
        Debug.Log($"spawn start type {type} contains {_dict.ContainsKey(type)}");
        if(_dict.ContainsKey(type))
        {
            Debug.LogError($"Scene object with [{type}] already spawned");
            return null;
        }        
        //var go = Resources.Load("Enviroment", typeof(T)) as T;//не знаю почему но это не работает
        var go = Resources.Load($"Enviroment/{name}");
        var p = _instantiator.InstantiatePrefabForComponent<T>(go);
        _dict.Add(type, p);
        if(parent!=null)
        {
            p.transform.parent = parent;
        }
        Debug.Log($"spawn start type {type} contains {_dict.ContainsKey(type)}");
        return p;
    }

    public void Clear<T>() where T : SceneObject
    {
        var type = typeof(T);
        Debug.Log($"clearing type  {type}");
        if(!_dict.ContainsKey(type))
        {
            Debug.LogError($"SceneObject with name {type} does not exist");
            return;
        }
        GameObject.Destroy(_dict[type].gameObject);
        _dict.Remove(type);
        Debug.Log($"clearing type {type} ends {_dict.ContainsKey(type)}");
    }
}
