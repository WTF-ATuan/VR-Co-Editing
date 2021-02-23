using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
[System.Serializable]
public class LevelData:MonoBehaviour
{
    public Material passWordMat;
    public Material passFrame;
    public Material failFrame;
    public BulletData answerBullet;
    
    public bool pass;
    [MyReadOnly]
    public bool miss;
    public SoundFile goodSound;
    public SoundFile badSound;
}