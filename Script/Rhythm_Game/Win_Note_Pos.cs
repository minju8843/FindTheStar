using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class NotePositionData
{
    public float PositionX;
    public float PositionY;
    public float PositionZ;
}

[System.Serializable]
public class AllInitialPositionsData
{
    public List<NotePositionData> InitialPositions = new List<NotePositionData>();
}

public class Win_Note_Pos : MonoBehaviour
{
    public Note_1105[] Win_0_Note;
    public Long_Note[] Win_0_Long;
    public Long_Col[] Win_0_Long_Fin;

    public static Win_Note_Pos instance;

    public void Start()
    {
        instance = this;
        Save_AllPositions();  // �ʱ� ��ġ ���� (�ʿ��� ��� �ּ� ó��)
        //Load_AllPositions();  // ��ġ ������ �ҷ�����
    }

    public void Load_AllPositions()
    {
        string filePath = Application.persistentDataPath + "/Win_NotePositions.json";

        if (!File.Exists(filePath))
        {
            //Debug.LogWarning("����� ��ġ ������ ������ �����ϴ�.");
            return;
        }

        // JSON ���� �б�
        string jsonData = File.ReadAllText(filePath);
        AllInitialPositionsData allData = JsonUtility.FromJson<AllInitialPositionsData>(jsonData);

        int dataIndex = 0;

        // 1. �Ϲ� ��Ʈ ��ġ �ҷ�����
        var NoteArrays = new List<Note_1105[]>()
    {
        Win_0_Note,
        // Win_1_Note,
        // Win_2_Note,
        // Win_3_Note,
        // Win_4_Note
    };

        foreach (var array in NoteArrays)
        {
            foreach (var note in array)
            {
                if (note.rect != null && dataIndex < allData.InitialPositions.Count)
                {
                    float posX = allData.InitialPositions[dataIndex].PositionX;
                    float posY = allData.InitialPositions[dataIndex].PositionY;
                    float posZ = allData.InitialPositions[dataIndex].PositionZ;

                    note.rect.localPosition = new Vector3(posX, posY, posZ);

                    //Debug.Log($"�Ϲ� ��Ʈ ��ġ ���� - X: {posX}, Y: {posY}, Z: {posZ}");
                    dataIndex++;
                }
            }
        }

        // 2. �� ��Ʈ ��ġ �ҷ�����
        var Long_NoteArrays = new List<Long_Note[]>()
    {
        Win_0_Long,
        // Win_1_Long,
        // Win_2_Long,
        // Win_3_Long,
        // Win_4_Long
    };

        foreach (var array in Long_NoteArrays)
        {
            foreach (var longNote in array)
            {
                if (longNote.rect != null && dataIndex < allData.InitialPositions.Count)
                {
                    float posX = allData.InitialPositions[dataIndex].PositionX;
                    float posY = allData.InitialPositions[dataIndex].PositionY;
                    float posZ = allData.InitialPositions[dataIndex].PositionZ;

                    longNote.rect.localPosition = new Vector3(posX, posY, posZ);

                    //Debug.Log($"�� ��Ʈ ��ġ ���� - X: {posX}, Y: {posY}, Z: {posZ}");
                    dataIndex++;
                }
            }
        }

        // 3. �� ��Ʈ ���κ� ��ġ �ҷ�����
        var Long_Col_NoteArrays = new List<Long_Col[]>()
    {
        Win_0_Long_Fin,
        // Win_1_Long_Fin,
        // Win_2_Long_Fin,
        // Win_3_Long_Fin,
        // Win_4_Long_Fin
    };

        foreach (var array in Long_Col_NoteArrays)
        {
            foreach (var longNoteFin in array)
            {
                if (longNoteFin.rect != null && dataIndex < allData.InitialPositions.Count)
                {
                    float posX = allData.InitialPositions[dataIndex].PositionX;
                    float posY = allData.InitialPositions[dataIndex].PositionY;
                    float posZ = allData.InitialPositions[dataIndex].PositionZ;

                    longNoteFin.rect.localPosition = new Vector3(posX, posY, posZ);

                   // Debug.Log($"�� ��Ʈ ���κ� ��ġ ���� - X: {posX}, Y: {posY}, Z: {posZ}");
                    dataIndex++;
                }
            }
        }

        //Debug.Log("��� ��ġ�� �����Ǿ����ϴ�.");
    }


    public void Save_AllPositions()
    {
        var allData = new AllInitialPositionsData();

        // �Ϲ� ��Ʈ ��ġ ����
        var NoteArrays = new List<Note_1105[]>()
    {
        Win_0_Note,
        // Win_1_Note,
        // Win_2_Note,
        // Win_3_Note,
        // Win_4_Note
    };

        foreach (var array in NoteArrays)
        {
            foreach (var note in array)
            {
                if (note.rect != null)
                {
                    NotePositionData data = new NotePositionData
                    {
                        PositionX = note.rect.localPosition.x,
                        PositionY = note.rect.localPosition.y,
                        PositionZ = note.rect.localPosition.z // Z �� ����
                    };
                    allData.InitialPositions.Add(data);
                    //Debug.Log($"��Ʈ ��ġ ���� - X: {data.PositionX}, Y: {data.PositionY}, Z: {data.PositionZ}");
                }
            }
        }

        // �� ��Ʈ ��ġ ����
        var Long_NoteArrays = new List<Long_Note[]>()
    {
        Win_0_Long,
        // Win_1_Long,
        // Win_2_Long,
        // Win_3_Long,
        // Win_4_Long
    };

        foreach (var array in Long_NoteArrays)
        {
            foreach (var longNote in array)
            {
                if (longNote.rect != null)
                {
                    NotePositionData data = new NotePositionData
                    {
                        PositionX = longNote.rect.localPosition.x,
                        PositionY = longNote.rect.localPosition.y,
                        PositionZ = longNote.rect.localPosition.z // Z �� ����
                    };
                    allData.InitialPositions.Add(data);
                    //Debug.Log($"�� ��Ʈ ��ġ ���� - X: {data.PositionX}, Y: {data.PositionY}, Z: {data.PositionZ}");
                }
            }
        }

        // �� ��Ʈ ���κ� ��ġ ����
        var Long_Col_NoteArrays = new List<Long_Col[]>()
    {
        Win_0_Long_Fin,
        // Win_1_Long_Fin,
        // Win_2_Long_Fin,
        // Win_3_Long_Fin,
        // Win_4_Long_Fin
    };

        foreach (var array in Long_Col_NoteArrays)
        {
            foreach (var longNoteFin in array)
            {
                if (longNoteFin.rect != null)
                {
                    NotePositionData data = new NotePositionData
                    {
                        PositionX = longNoteFin.rect.localPosition.x,
                        PositionY = longNoteFin.rect.localPosition.y,
                        PositionZ = longNoteFin.rect.localPosition.z // Z �� ����
                    };
                    allData.InitialPositions.Add(data);
                    //Debug.Log($"�� ��Ʈ ���κ� ��ġ ���� - X: {data.PositionX}, Y: {data.PositionY}, Z: {data.PositionZ}");
                }
            }
        }

        // JSON ���Ϸ� ����
        string jsonData = JsonUtility.ToJson(allData, true);
        File.WriteAllText(Application.persistentDataPath + "/Win_NotePositions.json", jsonData);

        //Debug.Log("��� ��ġ�� ����Ǿ����ϴ�.");
    }



    /*public void Save_AllPositions()
    {
        AllInitialPositionsData allData = new AllInitialPositionsData();

        // �Ϲ� ��Ʈ �ʱ� ��ġ ����
        var NoteArrays = new List<Note_1105[]>()
    {
        Win_0_Note,
        // Win_1_Note,
        // Win_2_Note,
        // Win_3_Note,
        // Win_4_Note
    };

        foreach (var array in NoteArrays)
        {
            foreach (var note in array)
            {
                if (note.rect != null)
                {
                    NotePositionData data = new NotePositionData
                    {
                        PositionX = note.rect.localPosition.x,
                        PositionY = note.rect.localPosition.y,
                        PositionZ = note.rect.localPosition.z
                    };
                    allData.InitialPositions.Add(data);
                    Debug.Log($"�Ϲ� ��Ʈ ��ġ - X: {data.PositionX}, Y: {data.PositionY},  Z: {data.PositionZ}");
                }
            }
        }

        // �� ��Ʈ �ʱ� ��ġ ����
        var Long_NoteArrays = new List<Long_Note[]>()
    {
        Win_0_Long,
        // Win_1_Long,
        // Win_2_Long,
        // Win_3_Long,
        // Win_4_Long
    };

        foreach (var array2 in Long_NoteArrays)
        {
            foreach (var longNote in array2)
            {
                if (longNote.rect != null)
                {
                    NotePositionData data = new NotePositionData
                    {
                        PositionX = longNote.rect.anchoredPosition.x,
                        PositionY = longNote.rect.anchoredPosition.y,
                        PositionZ = longNote.rect.localPosition.z
                    };
                    allData.InitialPositions.Add(data);
                    Debug.Log($"�ճ�Ʈ ��ġ - X: {data.PositionX}, Y: {data.PositionY},  Z: {data.PositionZ}");
                }
            }
        }

        // �ճ�Ʈ ���κ� ��ġ ���� (NotePositionData�� ����)

        var Long_Col_NoteArrays = new List<Long_Col[]>
    {
        Win_0_Long_Fin
    };

        foreach (var array3 in Long_Col_NoteArrays)
        {
            foreach (var longNote_Fin in array3)
            {
                if (longNote_Fin.rect != null)
                {
                    NotePositionData data = new NotePositionData
                    {
                        PositionX = longNote_Fin.rect.anchoredPosition.x,
                        PositionY = longNote_Fin.rect.anchoredPosition.y,
                        PositionZ = longNote_Fin.rect.localPosition.z
                    };
                    allData.InitialPositions.Add(data);
                    Debug.Log($"�ճ�Ʈ ���κ� ��ġ - X: {data.PositionX}, Y: {data.PositionY},  Z: {data.PositionZ}");
                }
            }
        }

        

        // JSON���� ��ȯ �� ���Ϸ� ����
        string jsonData = JsonUtility.ToJson(allData, true);
        File.WriteAllText(Application.persistentDataPath + "/Win_NotePositions.json", jsonData);

        Debug.Log("��ġ �����Ͱ� JSON ���Ϸ� ����Ǿ����ϴ�.");
    }*/



    /*public void Load_AllPositions()
    {
        string filePath = Application.persistentDataPath + "/Win_NotePositions.json";

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            AllInitialPositionsData allData = JsonUtility.FromJson<AllInitialPositionsData>(jsonData);

            int dataIndex = 0;

            // �Ϲ� ��Ʈ ��ġ �ҷ�����
            var NoteArrays = new List<Note_1105[]>()
        {
            Win_0_Note,
            // Win_1_Note,
            // Win_2_Note,
            // Win_3_Note,
            // Win_4_Note
        };

            foreach (var array in NoteArrays)
            {
                foreach (var note in array)
                {
                    if (note.rect != null && dataIndex < allData.InitialPositions.Count)
                    {
                        float posX = allData.InitialPositions[dataIndex].PositionX;
                        float posY = allData.InitialPositions[dataIndex].PositionY;
                        float posZ = allData.InitialPositions[dataIndex].PositionZ;
                        note.rect.anchoredPosition = new Vector3(posX, posY, posZ);

                        Debug.Log($"���� �Ϲ� ��Ʈ ��ġn - X: {posX}, Y: {posY}, Z: {posZ}");

                        dataIndex++;
                    }
                }
            }

            // �� ��Ʈ ��ġ �ҷ�����
            var Long_NoteArrays = new List<Long_Note[]>()
        {
            Win_0_Long,
            // Win_1_Long,
            // Win_2_Long,
            // Win_3_Long,
            // Win_4_Long
        };

            foreach (var array2 in Long_NoteArrays)
            {
                foreach (var longNote in array2)
                {
                    if (longNote.rect != null && dataIndex < allData.InitialPositions.Count)
                    {
                        float posX = allData.InitialPositions[dataIndex].PositionX;
                        float posY = allData.InitialPositions[dataIndex].PositionY;
                        float posZ = allData.InitialPositions[dataIndex].PositionZ;
                        longNote.rect.anchoredPosition = new Vector3(posX, posY, posZ);

                        Debug.Log($"���� �ճ�Ʈ ��ġ - X: {posX}, Y: {posY}, Z: {posZ}");

                        dataIndex++;
                    }
                }
            }

            var Long_Col_NoteArrays = new List<Long_Col[]>
{
    Win_0_Long_Fin
};

            //int dataIndex = 0; // Initial position data index

            foreach (var array3 in Long_Col_NoteArrays)
            {
                foreach (var longNote_Fin in array3)
                {
                    if (longNote_Fin.rect != null && dataIndex < allData.InitialPositions.Count)
                    {
                        float posX = allData.InitialPositions[dataIndex].PositionX;
                        float posY = allData.InitialPositions[dataIndex].PositionY;
                        float posZ = allData.InitialPositions[dataIndex].PositionZ;
                        longNote_Fin.rect.anchoredPosition = new Vector3(posX, posY, posZ);

                        Debug.Log($"���� �ճ�Ʈ ���κ� ��ġ - X: {posX}, Y: {posY}, Z {posZ}");

                        dataIndex++;
                    }
                }
            }
       

        }

        else
        {
            Debug.LogError("Position data file not found.");
        }
    }*/

}


/*[System.Serializable]
public class NotePositionData
{
    public float PositionX; // x ��ǥ
    public float PositionY; // y ��ǥ
}

[System.Serializable]
public class AllNotesData
{
    public List<NotePositionData> NotesPositions = new List<NotePositionData>(); // ��� Note�� ��ġ�� ����
}

public class Win_Note_Pos : MonoBehaviour
{
    public static Win_Note_Pos instance;
    //public Note_1105[] Win_0_Note; // ��ġ�� ������ Note �迭

    public void Start()
    {
        instance = this;

       
    }

    public void Save_LongNote_Fin_Pos()
    {
        //�� ��Ʈ ���κ�
        AllNotesData allData2 = new AllNotesData();

        for (int i = 0; i < Winter_Music.instance.Win_0_Long_Fin.Length; i++)
        {
            // �� Note�� ���� ��ġ �����͸� ����
            foreach (var note2 in Winter_Music.instance.Win_0_Long_Fin)
            {
                NotePositionData data2 = new NotePositionData
                {
                    PositionX = note2.rect[i].anchoredPosition.x,
                    PositionY = note2.rect[i].anchoredPosition.y
                };
                allData2.NotesPositions.Add(data2);
            }
        }

        // JSON ���ڿ��� ��ȯ �� ���Ϸ� ���� (���� �ۿ��� ����)
        string jsonData2 = JsonUtility.ToJson(allData2);
        File.WriteAllText(Application.persistentDataPath + "/Win_0_FinNote_Pos.json", jsonData2);
    }

    public void Save_LongNote_Pos()
    {
        //�� ��Ʈ
        AllNotesData allData1 = new AllNotesData();

        // �� Note�� ���� ��ġ �����͸� ����
        foreach (var note1 in Winter_Music.instance.Win_0_Long)
        {
            NotePositionData data1 = new NotePositionData
            {
                PositionX = note1.rect.anchoredPosition.x,
                PositionY = note1.rect.anchoredPosition.y
            };
            allData1.NotesPositions.Add(data1);
        }

        // JSON ���ڿ��� ��ȯ �� ����
        string jsonData1 = JsonUtility.ToJson(allData1);
        File.WriteAllText(Application.persistentDataPath + "/Win_0_LongNote_Pos.json", jsonData1);
    }

    public void Save_Note_Pos()
    {
        AllNotesData allData = new AllNotesData();

        // �� Note�� ���� ��ġ �����͸� ����
        foreach (var note in Winter_Music.instance.Win_0_Note)
        {
            NotePositionData data = new NotePositionData
            {
                PositionX = note.rect.anchoredPosition.x,
                PositionY = note.rect.anchoredPosition.y
            };
            allData.NotesPositions.Add(data);
        }

        // JSON ���ڿ��� ��ȯ �� ����
        string jsonData = JsonUtility.ToJson(allData);
        File.WriteAllText(Application.persistentDataPath + "/Win_0_Note_Pos.json", jsonData);


    }

    public bool Load_Note_Pos()
    {
        string path = Application.persistentDataPath + "/Win_0_Note_Pos.json";
        //string path1 = Application.persistentDataPath + "/Win_0_LongNote_Pos.json";
        //string path2 = Application.persistentDataPath + "/Win_0_FinNote_Pos.json";

        // ������ �����ϴ��� Ȯ��
        if (File.Exists(path)) //|| File.Exists(path1) || File.Exists(path2))
        {
            // ������ �����ϸ� JSON ���ڿ��� �о�ͼ� ����
            string json = File.ReadAllText(path);
            AllNotesData allData = JsonUtility.FromJson<AllNotesData>(json);

            // ������ ������ �迭 ũ�� Ȯ�� �� ��ġ ����
            if (allData.NotesPositions.Count == Winter_Music.instance.Win_0_Note.Length)
            {
                for (int i = 0; i < Winter_Music.instance.Win_0_Note.Length; i++)
                {
                    Vector2 loadedPosition = new Vector2(
                        allData.NotesPositions[i].PositionX,
                        allData.NotesPositions[i].PositionY
                    );
                    Winter_Music.instance.Win_0_Note[i].rect.anchoredPosition = loadedPosition;
                    Debug.Log($"�Ϲ� Note {i} ��ġ: X = {loadedPosition.x}, Y = {loadedPosition.y}");
                }
                return true;
            }
            else
            {
                Debug.LogWarning("��Ʈ ����.");
            }

            
        }

        return false;
        //�� ��Ʈ
        /* if (File.Exists(path1))
         {
             // ������ �����ϸ� JSON ���ڿ��� �о�ͼ� ����
             string json1 = File.ReadAllText(path1);
             AllNotesData allData1 = JsonUtility.FromJson<AllNotesData>(json1);

             // ������ ������ �迭 ũ�� Ȯ�� �� ��ġ ����
             if (allData1.NotesPositions.Count == Winter_Music.instance.Win_0_Note.Length)
             {
                 for (int i = 0; i < Winter_Music.instance.Win_0_Long.Length; i++)
                 {
                     Vector2 loadedPosition1 = new Vector2(
                         allData1.NotesPositions[i].PositionX,
                         allData1.NotesPositions[i].PositionY
                     );
                     Winter_Music.instance.Win_0_Long[i].rect.anchoredPosition = loadedPosition1;
                     Debug.Log($"�� Note {i} ��ġ: X = {loadedPosition1.x}, Y = {loadedPosition1.y}");
                 }
                 return true;
             }
             else
             {
                 Debug.LogWarning("�� ��Ʈ ����.");
             }
         }

         //�� ��Ʈ ���κ�
         if (File.Exists(path2))
         {
             // ������ �����ϸ� JSON ���ڿ��� �о�ͼ� ����
             string json2 = File.ReadAllText(path2);
             AllNotesData allData2 = JsonUtility.FromJson<AllNotesData>(json2);

             // ������ ������ �迭 ũ�� Ȯ�� �� ��ġ ����
             if (allData2.NotesPositions.Count == Winter_Music.instance.Win_0_Long_Fin.Length)
             {
                 for (int i = 0; i < Winter_Music.instance.Win_0_Long_Fin.Length; i++)
                 {
                     Vector2 loadedPosition2 = new Vector2(
                         allData2.NotesPositions[i].PositionX,
                         allData2.NotesPositions[i].PositionY
                     );
                     Winter_Music.instance.Win_0_Long_Fin[i].rect[i].anchoredPosition = loadedPosition2;
                     Debug.Log($"�� ���κ� Note {i} ��ġ: X = {loadedPosition2.x}, Y = {loadedPosition2.y}");
                 }
                 return true;
             }
             else
             {
                 Debug.LogWarning("�� ��Ʈ ���κ� ����.");
             }
         }
        */
// ������ ���ų� �����Ͱ� ��ġ���� ���� ��� false ��ȯ

//}

/*public void Load_LongNote_Pos()
{
    string path1 = Application.persistentDataPath + "/Win_0_LongNote_Pos.json";
    //string path2 = Application.persistentDataPath + "/Win_0_FinNote_Pos.json";

    // ������ �����ϴ��� Ȯ��
    if (File.Exists(path1)) //|| File.Exists(path1) || File.Exists(path2))
    {
        // ������ �����ϸ� JSON ���ڿ��� �о�ͼ� ����
        string json1 = File.ReadAllText(path1);
        AllNotesData allData1 = JsonUtility.FromJson<AllNotesData>(json1);

        // ������ ������ �迭 ũ�� Ȯ�� �� ��ġ ����
        if (allData.NotesPositions.Count == Winter_Music.instance.Win_0_Note.Length)
        {
            for (int i = 0; i < Winter_Music.instance.Win_0_Note.Length; i++)
            {
                Vector2 loadedPosition = new Vector2(
                    allData.NotesPositions[i].PositionX,
                    allData.NotesPositions[i].PositionY
                );
                Winter_Music.instance.Win_0_Note[i].rect.anchoredPosition = loadedPosition;
                Debug.Log($"�Ϲ� Note {i} ��ġ: X = {loadedPosition.x}, Y = {loadedPosition.y}");
            }
            return true;
        }
        else
        {
            Debug.LogWarning("��Ʈ ����.");
        }


    }

    return false;
}*/

/*public void Reset_AllPositions()
{
    string path = Application.persistentDataPath + "/Win_0_Note_Positions.json";

    // ������ ������ ��� ����
    if (File.Exists(path))
    {
        File.Delete(path);
        Debug.Log("��� Note ��ġ ������ ���� �Ϸ�");
    }

    // ��� Note�� ��ġ�� ���� ��ġ�� �ʱ�ȭ�Ͽ� �ٽ� ����
    Save_AllPositions();
    Debug.Log("��� Note ��ġ ���� ��ġ�� �ʱ�ȭ �� ���� �Ϸ�");
}*/
//}
