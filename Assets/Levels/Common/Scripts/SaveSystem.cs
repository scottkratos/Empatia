using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem control;
    private void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }
    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file;
        file = File.Create(Application.persistentDataPath + "/playerinfo.scott");
        PlayerData data = new PlayerData();
        //coisa pra salvar
        data.pos[0] = CheckpointManager.CheckPosition.position.x;
        data.pos[1] = CheckpointManager.CheckPosition.position.y;
        data.pos[2] = CheckpointManager.CheckPosition.position.z;
        data.IsWithDavid = PlayerMovement.control.HaveCompanion;
        data.Level = PlayerMovement.control.Level;
        //fim de coisas
        formatter.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerinfo.scott"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerinfo.scott", FileMode.Open);
            PlayerData data = (PlayerData)formatter.Deserialize(file);
            file.Close();
            SceneManager.LoadScene(data.Level);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        if (File.Exists(Application.persistentDataPath + "/playerinfo.scott"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerinfo.scott", FileMode.Open);
            PlayerData data = (PlayerData)formatter.Deserialize(file);
            file.Close();
            //data.variavel p/ setar as coisas
            PlayerMovement.control.transform.position = new Vector3(data.pos[0], data.pos[1], data.pos[2]);
            PlayerMovement.control.HaveCompanion = data.IsWithDavid;
            if (data.IsWithDavid)
            {
                CompanionMovement.control.transform.position = new Vector3(data.pos[0], data.pos[1], data.pos[2]);
            }
            ScreenChange.control.ScreenFadeOut();
            PlayerMovement.control.IsAlive = true;
        }
    }
}

[Serializable]
public class PlayerData
{
    public int Level = 0;
    public float[] pos = new float[3];
    public bool IsWithDavid;
}