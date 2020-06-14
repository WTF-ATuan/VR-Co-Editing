using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.Events;


public class RadialMenu : MonoBehaviour
{

    


    [Header("Stage One Buttons")]
    public RadialSection textbuttonstageone1 = null;
    public RadialSection textbuttonstageone2 = null;
    public RadialSection textbuttonstageone3 = null;
    public RadialSection textbuttonstageone4 = null;
    public RadialSection textbuttonstageone5 = null;
    public RadialSection textbuttonstageone6 = null;

    [Header("Stage Two Buttons")]
    public RadialSection textbuttonstagetwo1 = null;
    public RadialSection textbuttonstagetwo2 = null;
    public RadialSection textbuttonstagetwo3 = null;
    public RadialSection textbuttonstagetwo4 = null;
    public RadialSection textbuttonstagetwo5 = null;
    public RadialSection textbuttonstagetwo6 = null;

    [Header("Stage Three Buttons")]
    public RadialSection textbuttonstagethree1 = null;
    public RadialSection textbuttonstagethree2 = null;
    public RadialSection textbuttonstagethree3 = null;
    public RadialSection textbuttonstagethree4 = null;
    public RadialSection textbuttonstagethree5 = null;
    public RadialSection textbuttonstagethree6 = null;

    [Header("Stage")]
    public GameObject StageOne = null;
    public GameObject StageTwo = null;
    public GameObject StageThree = null;


    private List<RadialSection> radialSections;

  
    private void CreatAndSetupSections()
    {
        radialSections = new List<RadialSection>()
        {
           

            textbuttonstageone1,
            textbuttonstageone2,
            textbuttonstageone3,
            textbuttonstageone4,
            textbuttonstageone5,
            textbuttonstageone6,

            textbuttonstagetwo1,
            textbuttonstagetwo2,
            textbuttonstagetwo3,
            textbuttonstagetwo4,
            textbuttonstagetwo5,
            textbuttonstagetwo6,

            textbuttonstagethree1,
            textbuttonstagethree2,
            textbuttonstagethree3,
            textbuttonstagethree4,
            textbuttonstagethree5,
            textbuttonstagethree6

};

        foreach (RadialSection section in radialSections)
            section.iconRenderer.sprite = section.icon;
    }

    private void Start()
    {
        ShowStageOne(true);
    }
    public void Update()
    {
        

    }

    public void ShowStageOne(bool value)
    {
            StageOne.SetActive(true);
            StageTwo.SetActive(false);
            StageThree.SetActive(false);

    }
    public void ShowStageTwo(bool value)
    {
        StageOne.SetActive(false);
        StageTwo.SetActive(true);
        StageThree.SetActive(false);

    }

    public void ShowStageThree(bool value)
    {
        StageOne.SetActive(false);
        StageTwo.SetActive(false);
        StageThree.SetActive(true);

    }
   
    
    public void TurnRight()
    {

        gameObject.transform.Find("Text").Rotate(new Vector3(0f, 0f, -60f));
        gameObject.transform.Find("Roulette").Rotate(new Vector3(0f, 0f, -60f));


        textbuttonstageone1.iconRenderer.transform.Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localWaRotate = gameObject.transform.Find("Text").Find("Wa").localRotation.eulerAngles;//存當下Wa旋轉角度

        textbuttonstageone2.iconRenderer.transform.Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localARotate = gameObject.transform.Find("Text").Find("A").localRotation.eulerAngles;//存當下A旋轉角度

        textbuttonstageone3.iconRenderer.transform.Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localRaRotate = gameObject.transform.Find("Text").Find("Ra").localRotation.eulerAngles;//存當下Ra旋轉角度

        textbuttonstageone4.iconRenderer.transform.Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localIRotate = gameObject.transform.Find("Text").Find("I").localRotation.eulerAngles;//存當下I旋轉角度

        textbuttonstageone5.iconRenderer.transform.Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localLongRotate = gameObject.transform.Find("Text").Find("Long").localRotation.eulerAngles;//存當下Long旋轉角度

        textbuttonstageone6.iconRenderer.transform.Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localA1Rotate = gameObject.transform.Find("Text").Find("A (1)").localRotation.eulerAngles;//存當下A (1)旋轉角度

        //Text1Trigger(localWaRotate, localARotate, localRaRotate, localIRotate, localA1Rotate, localLongRotate);


        //TEXT 2 題目02

        gameObject.transform.Find("Text2").Rotate(new Vector3(0f, 0f, -60f));
        gameObject.transform.Find("Roulette").Rotate(new Vector3(0f, 0f, -60f));

        textbuttonstagetwo1.iconRenderer.transform.Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localSeRotate = gameObject.transform.Find("Text2").Find("Se").localRotation.eulerAngles;//存當下Se旋轉角度

        textbuttonstagetwo2.iconRenderer.transform.Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localLong1Rotate = gameObject.transform.Find("Text2").Find("Long (1)").localRotation.eulerAngles;//存當下Long (1)旋轉角度

        textbuttonstagetwo3.iconRenderer.transform.Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localRiRotate = gameObject.transform.Find("Text2").Find("Ri").localRotation.eulerAngles;//存當下Ri旋轉角度

        textbuttonstagetwo4.iconRenderer.transform.Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localLong2Rotate = gameObject.transform.Find("Text2").Find("Long (2)").localRotation.eulerAngles;//存當下Long (2)旋轉角度

        textbuttonstagetwo5.iconRenderer.transform.Rotate(new Vector3(0f, 0f, 60f));

        textbuttonstagetwo6.iconRenderer.transform.Rotate(new Vector3(0f, 0f, 60f));



        //Text2Trigger(localSeRotate, localLong1Rotate, localRiRotate, localLong2Rotate);


        //TEXT 3 題目03

        gameObject.transform.Find("Text3").Rotate(new Vector3(0f, 0f, -60f));
        gameObject.transform.Find("Roulette").Rotate(new Vector3(0f, 0f, -60f));

        textbuttonstagethree1.iconRenderer.transform.Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localTsuRotate = gameObject.transform.Find("Text3").Find("Tsu").localRotation.eulerAngles;//存當下Se旋轉角度

        textbuttonstagethree2.iconRenderer.transform.Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localLong3Rotate = gameObject.transform.Find("Text3").Find("Long (3)").localRotation.eulerAngles;//存當下Long (1)旋轉角度

        textbuttonstagethree3.iconRenderer.transform.Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localI1Rotate = gameObject.transform.Find("Text3").Find("I (1)").localRotation.eulerAngles;//存當下Ri旋轉角度

        textbuttonstagethree4.iconRenderer.transform.Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localLong4Rotate = gameObject.transform.Find("Text3").Find("Long (4)").localRotation.eulerAngles;//存當下Long (2)旋轉角度
        textbuttonstagethree5.iconRenderer.transform.Rotate(new Vector3(0f, 0f, 60f));
        textbuttonstagethree6.iconRenderer.transform.Rotate(new Vector3(0f, 0f, 60f));


        //Text3Trigger(localTsuRotate, localLong3Rotate, localI1Rotate, localLong4Rotate);


    }

    public void TurnLeft()
    {

        gameObject.transform.Find("Text").Rotate(new Vector3(0f, 0f, 60f));
        gameObject.transform.Find("Roulette").Rotate(new Vector3(0f, 0f, 60f));


        textbuttonstageone1.iconRenderer.transform.Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localWaRotate = gameObject.transform.Find("Text").Find("Wa").localRotation.eulerAngles;//存當下Wa旋轉角度

        textbuttonstageone2.iconRenderer.transform.Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localARotate = gameObject.transform.Find("Text").Find("A").localRotation.eulerAngles;//存當下A旋轉角度

        textbuttonstageone3.iconRenderer.transform.Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localRaRotate = gameObject.transform.Find("Text").Find("Ra").localRotation.eulerAngles;//存當下Ra旋轉角度

        textbuttonstageone4.iconRenderer.transform.Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localIRotate = gameObject.transform.Find("Text").Find("I").localRotation.eulerAngles;//存當下I旋轉角度

        textbuttonstageone5.iconRenderer.transform.Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localLongRotate = gameObject.transform.Find("Text").Find("Long").localRotation.eulerAngles;//存當下Long旋轉角度

        textbuttonstageone6.iconRenderer.transform.Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localA1Rotate = gameObject.transform.Find("Text").Find("A (1)").localRotation.eulerAngles;//存當下A (1)旋轉角度

        //Text1Trigger(localWaRotate, localARotate, localRaRotate, localIRotate, localA1Rotate, localLongRotate);


        //TEXT 2 題目02

        gameObject.transform.Find("Text2").Rotate(new Vector3(0f, 0f, 60f));
        gameObject.transform.Find("Roulette").Rotate(new Vector3(0f, 0f, 60f));

        textbuttonstagetwo1.iconRenderer.transform.Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localSeRotate = gameObject.transform.Find("Text2").Find("Se").localRotation.eulerAngles;//存當下Se旋轉角度

        textbuttonstagetwo2.iconRenderer.transform.Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localLong1Rotate = gameObject.transform.Find("Text2").Find("Long (1)").localRotation.eulerAngles;//存當下Long (1)旋轉角度

        textbuttonstagetwo3.iconRenderer.transform.Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localRiRotate = gameObject.transform.Find("Text2").Find("Ri").localRotation.eulerAngles;//存當下Ri旋轉角度

        textbuttonstagetwo4.iconRenderer.transform.Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localLong2Rotate = gameObject.transform.Find("Text2").Find("Long (2)").localRotation.eulerAngles;//存當下Long (2)旋轉角度

        textbuttonstagetwo5.iconRenderer.transform.Rotate(new Vector3(0f, 0f, -60f));

        textbuttonstagetwo6.iconRenderer.transform.Rotate(new Vector3(0f, 0f, -60f));



        //Text2Trigger(localSeRotate, localLong1Rotate, localRiRotate, localLong2Rotate);


        //TEXT 3 題目03

        gameObject.transform.Find("Text3").Rotate(new Vector3(0f, 0f, 60f));
        gameObject.transform.Find("Roulette").Rotate(new Vector3(0f, 0f, 60f));

        textbuttonstagethree1.iconRenderer.transform.Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localTsuRotate = gameObject.transform.Find("Text3").Find("Tsu").localRotation.eulerAngles;//存當下Se旋轉角度

        textbuttonstagethree2.iconRenderer.transform.Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localLong3Rotate = gameObject.transform.Find("Text3").Find("Long (3)").localRotation.eulerAngles;//存當下Long (1)旋轉角度

        textbuttonstagethree3.iconRenderer.transform.Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localI1Rotate = gameObject.transform.Find("Text3").Find("I (1)").localRotation.eulerAngles;//存當下Ri旋轉角度

        textbuttonstagethree4.iconRenderer.transform.Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localLong4Rotate = gameObject.transform.Find("Text3").Find("Long (4)").localRotation.eulerAngles;//存當下Long (2)旋轉角度
        textbuttonstagethree5.iconRenderer.transform.Rotate(new Vector3(0f, 0f, -60f));
        textbuttonstagethree6.iconRenderer.transform.Rotate(new Vector3(0f, 0f, -60f));


        //Text3Trigger(localTsuRotate, localLong3Rotate, localI1Rotate, localLong4Rotate);
    }


    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    //如一開始用Random的文字不適用以下方法(因寫死的比對旋轉角度才能相同)

    public void Text1Trigger(Vector3 localWaRotate,Vector3 localARotate,Vector3 localRaRotate, Vector3 localIRotate, Vector3 localA1Rotate, Vector3 localLongRotate)
    {
        Vector3 WaRotate = new Vector3(0f, 0f,240f);//Wa 按鈕確定位置
        Vector3 ARotate = new Vector3(0f, 0f, 60f);// A 按鈕確定位置
        Vector3 RaRotate = new Vector3(0f, 0f, 120f);// Ra 按鈕確定位置
        Vector3 IRotate = new Vector3(0f, 0f, 300f);// I 按鈕確定位置
        Vector3 A1Rotate = new Vector3(0f, 0f, 180f);// A (1) 按鈕確定位置
        Vector3 LongRotate = new Vector3(0f, 0f, 0f);// Long 按鈕確定位置

        bool WaTrue = false;
        bool ATrue = false;
        bool RaTrue = false;
        bool ITrue = false;
        bool A1True = false;
        bool LongTrue = false;


        if (localWaRotate == WaRotate)//判斷Wa按鈕是否為發送位置
        {
            WaTrue = true;
            print("Text1 Wa按鍵發送位置");
            //print(WaTrue);
        
        }

        if (localARotate == ARotate)//判斷Wa按鈕是否為發送位置
        {
            ATrue = true;
            print("Text1 A按鍵發送位置");
           // print(ATrue);


        }

        if (localRaRotate == RaRotate)//判斷Ra按鈕是否為發送位置
        {
            RaTrue = true;
            print("Text1 Ra按鍵發送位置");
            // print(RaTrue);


        }

        if (localIRotate == IRotate)//判斷I按鈕是否為發送位置
        {
            ITrue = true;
            print("Text1 I按鍵發送位置");
            // print(ITrue);


        }

        if (localA1Rotate == A1Rotate)//判斷A (1)按鈕是否為發送位置
        {
            A1True = true;
            print("Text1 A1按鍵發送位置");
            // print(A1True);


        }

        if (localLongRotate == LongRotate)//判斷Long按鈕是否為確定發送位置
        {
            LongTrue = true;
            print("Text1 Long按鍵發送位置");
            // print(LongTrue);


        }

        //print("外圈"+WaTrue);
        //VRUIInput(WaTrue);
    }

    public void Text2Trigger(Vector3 localSeRotate, Vector3 localLong1Rotate, Vector3 localRiRotate, Vector3 localLong2Rotate)
    {
        Vector3 SeRotate = new Vector3(0f, 0f, 180f);//Se 按鈕確定位置
        Vector3 Long1Rotate = new Vector3(0f, 0f, 300f);// Long1 按鈕確定位置
        Vector3 RiRotate = new Vector3(0f, 0f, 60f);// Ri 按鈕確定位置
        Vector3 Long2Rotate = new Vector3(0f, 0f, 120f);// Long2 按鈕確定位置
       

        bool SeTrue = false;
        bool Long1True = false;
        bool RiTrue = false;
        bool Long2True = false;
      


        if (localSeRotate == SeRotate)//判斷Se按鈕是否為發送位置
        {
            SeTrue = true;
            print("Text2 Se按鍵發送位置");
            //print(SeTrue);

        }

        if (localLong1Rotate == Long1Rotate)//判斷Long1按鈕是否為發送位置
        {
            Long1True = true;
            print("Text2 Long (1)按鍵發送位置");
            // print(Long1True);


        }

        if (localRiRotate == RiRotate)//判斷Ri按鈕是否為發送位置
        {
            RiTrue = true;
            print("Text2 Ri按鍵發送位置");
            // print(RiTrue);


        }

        if (localLong2Rotate == Long2Rotate)//判斷Long2按鈕是否為發送位置
        {
            Long2True = true;
            print("Text2 Long (2)按鍵發送位置");
            // print(Long1True);


        }


       

        //print("外圈"+SeTrue);
        //VRUIInput(SeTrue);



    }


    public void Text3Trigger(Vector3 localTsuRotate, Vector3 localLong3Rotate, Vector3 localI1Rotate, Vector3 localLong4Rotate)
    {
        Vector3 TsuRotate = new Vector3(0f, 0f, 240f);//Tsu 按鈕確定位置
        Vector3 Long3Rotate = new Vector3(0f, 0f, 300f);// Long3 按鈕確定位置
        Vector3 I1Rotate = new Vector3(0f, 0f, 60f);// I1按鈕確定位置
        Vector3 Long4Rotate = new Vector3(0f, 0f, 120f);// I 按鈕確定位置


        bool TsuTrue = false;
        bool Long3True = false;
        bool I1True = false;
        bool Long4True = false;



        if (localTsuRotate == TsuRotate)//判斷Tsu按鈕是否為發送位置
        {
            TsuTrue = true;
            print("Text3 Tsu按鍵發送位置");
            //print(TsuTrue);

        }

        if (localLong3Rotate == Long3Rotate)//判斷Long3按鈕是否為發送位置
        {
            Long3True = true;
            print("Text3 Long (3)按鍵發送位置");
            // print(Long3True);


        }

        if (localI1Rotate == I1Rotate)//判斷I1按鈕是否為發送位置
        {
            I1True = true;
            print("Text3 I1按鍵發送位置");
            // print(I1True);


        }

        if (localLong4Rotate == Long4Rotate)//判斷Long4按鈕是否為發送位置
        {
            Long4True = true;
            print("Text3 Long (4)按鍵發送位置");
            // print(Long1True);


        }




        //print("外圈"+TsuTrue);
        //VRUIInput(TsuTrue);



    }
    //!不能觸發
    //public void VRUIInput(bool WaTrue)
    //{
    //    Debug.Log("VR" + WaTrue);
    //    if (WaTrue == true)
    //    {
    //        Debug.Log("VR內" + WaTrue);

    //        if (GripTextAction.GetStateDown(SteamVR_Input_Sources.Any)) //讀取FireActicon GrapGrip值  
    //        {
    //            Debug.Log("OpenUIVRInput");


    //        }
    //    }

    //}



}

