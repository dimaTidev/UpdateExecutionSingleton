using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UpdateSingleton : MonoBehaviour
{
    static UpdateSingleton instance;
    public static UpdateSingleton Instance => instance ??= (new GameObject(typeof(UpdateSingleton).Name + "SINGLETON").AddComponent<UpdateSingleton>());

    #region Update
    //---------------------------------------------------------------------------------
    public event Action update;
    /// <summary>
    /// Method in argument will be executed in Update by UpdateSingleton.cs
    /// </summary>
    /// <param name="act"></param>
    public static void ExecuteIn_Update(Action act)
    {
        RemoveFrom_Update(act);
        Instance.update += act;
    }
    public static void RemoveFrom_Update(Action act) => Instance.update -= act;
    private void Update() => update?.Invoke();
    //---------------------------------------------------------------------------------
    #endregion

    #region FixedUpdate
    //---------------------------------------------------------------------------------
    public event Action fixedUpdate;
    /// <summary>
    /// Method in argument will be executed in FixedUpdate by UpdateSingleton.cs
    /// </summary>
    /// <param name="act"></param>
    public static void ExecuteIn_FixedUpdate(Action act)
    {
        RemoveFrom_FixedUpdate(act);
        Instance.fixedUpdate += act;
    }
    public static void RemoveFrom_FixedUpdate(Action act) => Instance.fixedUpdate -= act;
    private void FixedUpdate() => fixedUpdate?.Invoke();
    //---------------------------------------------------------------------------------
    #endregion

    #region LateUpdate
    //---------------------------------------------------------------------------------
    public event Action lateUpdate;
    /// <summary>
    /// Method in argument will be executed in LateUpdate by UpdateSingleton.cs
    /// </summary>
    /// <param name="act"></param>
    public static void ExecuteIn_LateUpdate(Action act)
    {
        RemoveFrom_LateUpdate(act);
        Instance.lateUpdate += act;
    }
    public static void RemoveFrom_LateUpdate(Action act) => Instance.lateUpdate -= act;
    private void LateUpdate() => lateUpdate?.Invoke();
    //---------------------------------------------------------------------------------
    #endregion

   
}
