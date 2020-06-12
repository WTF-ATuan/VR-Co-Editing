using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.Events;


public class RadialMenu : MonoBehaviour {

    public GameObject StageOne , StageTwo , StageThree; 

    public void TurnRight() {

        //TEXT 1 題目01

        //gameObject.transform.Rotate(new Vector3(0f, 0f, 60f));
        gameObject.transform.Find("Text").Rotate(new Vector3(0f, 0f, -60f));
        gameObject.transform.Find("Roulette").Rotate(new Vector3(0f, 0f, -60f));

        gameObject.transform.Find("Text").Find("Wa").Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localWaRotate = gameObject.transform.Find("Text").Find("Wa").localRotation.eulerAngles;//存當下Wa旋轉角度

        gameObject.transform.Find("Text").Find("A").Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localARotate = gameObject.transform.Find("Text").Find("A").localRotation.eulerAngles;//存當下A旋轉角度

        gameObject.transform.Find("Text").Find("Ra").Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localRaRotate = gameObject.transform.Find("Text").Find("Ra").localRotation.eulerAngles;//存當下Ra旋轉角度

        gameObject.transform.Find("Text").Find("I").Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localIRotate = gameObject.transform.Find("Text").Find("I").localRotation.eulerAngles;//存當下I旋轉角度

        gameObject.transform.Find("Text").Find("Long").Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localLongRotate = gameObject.transform.Find("Text").Find("Long").localRotation.eulerAngles;//存當下Long旋轉角度

        gameObject.transform.Find("Text").Find("A (1)").Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localA1Rotate = gameObject.transform.Find("Text").Find("A (1)").localRotation.eulerAngles;//存當下A (1)旋轉角度

        Text1Trigger(localWaRotate, localARotate, localRaRotate, localIRotate, localA1Rotate, localLongRotate);


        //TEXT 2 題目02

        gameObject.transform.Find("Text2").Rotate(new Vector3(0f, 0f, -60f));
        gameObject.transform.Find("Roulette").Rotate(new Vector3(0f, 0f, -60f));

        gameObject.transform.Find("Text2").Find("Se").Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localSeRotate = gameObject.transform.Find("Text2").Find("Se").localRotation.eulerAngles;//存當下Se旋轉角度

        gameObject.transform.Find("Text2").Find("Long (1)").Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localLong1Rotate = gameObject.transform.Find("Text2").Find("Long (1)").localRotation.eulerAngles;//存當下Long (1)旋轉角度

        gameObject.transform.Find("Text2").Find("Ri").Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localRiRotate = gameObject.transform.Find("Text2").Find("Ri").localRotation.eulerAngles;//存當下Ri旋轉角度

        gameObject.transform.Find("Text2").Find("Long (2)").Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localLong2Rotate = gameObject.transform.Find("Text2").Find("Long (2)").localRotation.eulerAngles;//存當下Long (2)旋轉角度



        Text2Trigger(localSeRotate, localLong1Rotate, localRiRotate, localLong2Rotate);


        //TEXT 3 題目03

        gameObject.transform.Find("Text3").Rotate(new Vector3(0f, 0f, -60f));
        gameObject.transform.Find("Roulette").Rotate(new Vector3(0f, 0f, -60f));

        gameObject.transform.Find("Text3").Find("Tsu").Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localTsuRotate = gameObject.transform.Find("Text3").Find("Tsu").localRotation.eulerAngles;//存當下Se旋轉角度

        gameObject.transform.Find("Text3").Find("Long (3)").Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localLong3Rotate = gameObject.transform.Find("Text3").Find("Long (3)").localRotation.eulerAngles;//存當下Long (1)旋轉角度

        gameObject.transform.Find("Text3").Find("I (1)").Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localI1Rotate = gameObject.transform.Find("Text3").Find("I (1)").localRotation.eulerAngles;//存當下Ri旋轉角度

        gameObject.transform.Find("Text3").Find("Long (4)").Rotate(new Vector3(0f, 0f, 60f));
        Vector3 localLong4Rotate = gameObject.transform.Find("Text3").Find("Long (4)").localRotation.eulerAngles;//存當下Long (2)旋轉角度



        Text3Trigger(localTsuRotate, localLong3Rotate, localI1Rotate, localLong4Rotate);


    }

    public void TurnLeft() {

        //gameObject.transform.Rotate(new Vector3(0f, 0f, 60f));
        gameObject.transform.Find("Text").Rotate(new Vector3(0f, 0f, 60f));
        gameObject.transform.Find("Roulette").Rotate(new Vector3(0f, 0f, 60f));

        gameObject.transform.Find("Text").Find("Wa").Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localWaRotate = gameObject.transform.Find("Text").Find("Wa").localRotation.eulerAngles;//存當下Wa旋轉角度

        gameObject.transform.Find("Text").Find("A").Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localARotate = gameObject.transform.Find("Text").Find("A").localRotation.eulerAngles;//存當下A旋轉角度

        gameObject.transform.Find("Text").Find("Ra").Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localRaRotate = gameObject.transform.Find("Text").Find("Ra").localRotation.eulerAngles;//存當下Ra旋轉角度

        gameObject.transform.Find("Text").Find("I").Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localIRotate = gameObject.transform.Find("Text").Find("I").localRotation.eulerAngles;//存當下I旋轉角度

        gameObject.transform.Find("Text").Find("Long").Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localLongRotate = gameObject.transform.Find("Text").Find("Long").localRotation.eulerAngles;//存當下Long旋轉角度

        gameObject.transform.Find("Text").Find("A (1)").Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localA1Rotate = gameObject.transform.Find("Text").Find("A (1)").localRotation.eulerAngles;//存當下A (1)旋轉角度

        Text1Trigger(localWaRotate, localARotate, localRaRotate, localIRotate, localA1Rotate, localLongRotate);


        //TEXT 2 題目02

        gameObject.transform.Find("Text2").Rotate(new Vector3(0f, 0f, 60f));
        gameObject.transform.Find("Roulette").Rotate(new Vector3(0f, 0f, 60f));

        gameObject.transform.Find("Text2").Find("Se").Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localSeRotate = gameObject.transform.Find("Text2").Find("Se").localRotation.eulerAngles;//存當下Se旋轉角度

        gameObject.transform.Find("Text2").Find("Long (1)").Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localLong1Rotate = gameObject.transform.Find("Text2").Find("Long (1)").localRotation.eulerAngles;//存當下Long (1)旋轉角度

        gameObject.transform.Find("Text2").Find("Ri").Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localRiRotate = gameObject.transform.Find("Text2").Find("Ri").localRotation.eulerAngles;//存當下Ri旋轉角度

        gameObject.transform.Find("Text2").Find("Long (2)").Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localLong2Rotate = gameObject.transform.Find("Text2").Find("Long (2)").localRotation.eulerAngles;//存當下Long (2)旋轉角度



        Text2Trigger(localSeRotate, localLong1Rotate, localRiRotate, localLong2Rotate);

        //TEXT 3 題目03

        gameObject.transform.Find("Text3").Rotate(new Vector3(0f, 0f, 60f));
        gameObject.transform.Find("Roulette").Rotate(new Vector3(0f, 0f, 60f));

        gameObject.transform.Find("Text3").Find("Tsu").Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localTsuRotate = gameObject.transform.Find("Text3").Find("Tsu").localRotation.eulerAngles;//存當下Se旋轉角度

        gameObject.transform.Find("Text3").Find("Long (3)").Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localLong3Rotate = gameObject.transform.Find("Text3").Find("Long (3)").localRotation.eulerAngles;//存當下Long (1)旋轉角度

        gameObject.transform.Find("Text3").Find("I (1)").Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localI1Rotate = gameObject.transform.Find("Text3").Find("I (1)").localRotation.eulerAngles;//存當下Ri旋轉角度

        gameObject.transform.Find("Text3").Find("Long (4)").Rotate(new Vector3(0f, 0f, -60f));
        Vector3 localLong4Rotate = gameObject.transform.Find("Text3").Find("Long (4)").localRotation.eulerAngles;//存當下Long (2)旋轉角度



        Text3Trigger(localTsuRotate, localLong3Rotate, localI1Rotate, localLong4Rotate);


    }


    //如一開始用Random的文字不適用以下方法(因寫死的比對旋轉角度才能相同)

    public void Text1Trigger(Vector3 localWaRotate, Vector3 localARotate, Vector3 localRaRotate, Vector3 localIRotate, Vector3 localA1Rotate, Vector3 localLongRotate) {
        Vector3 WaRotate = new Vector3(0f, 0f, 240f);//Wa 按鈕確定位置
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

    public void Text2Trigger(Vector3 localSeRotate, Vector3 localLong1Rotate, Vector3 localRiRotate, Vector3 localLong2Rotate) {
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

     
    public void Text3Trigger(Vector3 localTsuRotate, Vector3 localLong3Rotate, Vector3 localI1Rotate, Vector3 localLong4Rotate) {
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



    }
}

