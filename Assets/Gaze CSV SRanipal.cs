using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;

namespace ViveSR
{
    namespace anipal
    {
        namespace Eye
        {
            public class GazeCSVSRanipal : MonoBehaviour
            {
                public int LengthOfRay = 25;
                [SerializeField] private LineRenderer GazeRayRenderer;
                private static EyeData_v2 eyeData = new EyeData_v2();
                private bool eye_callback_registered = false;
                public Vector3 Gaze;
                public Vector3 GazeO; //
                public Vector3 GazeL;
                public Vector3 GazeR;
                public Vector3 GazeOL;
                public Vector3 GazeOR;
                public Vector2 PupilL;
                public Vector2 PupilR;
                public Vector3 Kaoposi;
                public Vector3 Kaomuki;
                public GameObject rayed;
                private Ray ray;
                public Vector3 rayposi;
                public float time;
                public float perc;
                public GameObject Kouho;
                public GameObject kinki;
                public GameObject Kaso;
                public GameObject Indi;
                public GameObject Pie;
                public Vector3 Kasoposi;
                public string namae;

                private void Start()
                {
                    if (!SRanipal_Eye_Framework.Instance.EnableEye)
                    {
                        enabled = false;
                        return;
                    }
                    Assert.IsNotNull(GazeRayRenderer);
                }

                private void Update()
                {
                    if (SRanipal_Eye_Framework.Status != SRanipal_Eye_Framework.FrameworkStatus.WORKING &&
                        SRanipal_Eye_Framework.Status != SRanipal_Eye_Framework.FrameworkStatus.NOT_SUPPORT) return;

                    if (SRanipal_Eye_Framework.Instance.EnableEyeDataCallback == true && eye_callback_registered == false)
                    {
                        SRanipal_Eye_v2.WrapperRegisterEyeDataCallback(Marshal.GetFunctionPointerForDelegate((SRanipal_Eye_v2.CallbackBasic)EyeCallback));
                        eye_callback_registered = true;
                    }
                    else if (SRanipal_Eye_Framework.Instance.EnableEyeDataCallback == false && eye_callback_registered == true)
                    {
                        SRanipal_Eye_v2.WrapperUnRegisterEyeDataCallback(Marshal.GetFunctionPointerForDelegate((SRanipal_Eye_v2.CallbackBasic)EyeCallback));
                        eye_callback_registered = false;
                    }

                    Vector3 GazeOriginCombinedLocal, GazeDirectionCombinedLocal;

                    if (eye_callback_registered)
                    {
                        if (SRanipal_Eye_v2.GetGazeRay(GazeIndex.COMBINE, out GazeOriginCombinedLocal, out GazeDirectionCombinedLocal, eyeData)) { }
                        else return;
                    }
                    else
                    {
                        if (SRanipal_Eye_v2.GetGazeRay(GazeIndex.COMBINE, out GazeOriginCombinedLocal, out GazeDirectionCombinedLocal)) { }
                        else return;
                    }
                    Vector3 GazeOriginCombinedLocalL, GazeDirectionCombinedLocalL;

                    if (eye_callback_registered)
                    {
                        if (SRanipal_Eye_v2.GetGazeRay(GazeIndex.LEFT, out GazeOriginCombinedLocalL, out GazeDirectionCombinedLocalL, eyeData)) { }
                        else return;
                    }
                    else
                    {
                        if (SRanipal_Eye_v2.GetGazeRay(GazeIndex.LEFT, out GazeOriginCombinedLocalL, out GazeDirectionCombinedLocalL)) { }
                        else return;
                    }
                    Vector3 GazeOriginCombinedLocalR, GazeDirectionCombinedLocalR;

                    if (eye_callback_registered)
                    {
                        if (SRanipal_Eye_v2.GetGazeRay(GazeIndex.RIGHT, out GazeOriginCombinedLocalR, out GazeDirectionCombinedLocalR, eyeData)) { }
                        else return;
                    }
                    else
                    {
                        if (SRanipal_Eye_v2.GetGazeRay(GazeIndex.RIGHT, out GazeOriginCombinedLocalR, out GazeDirectionCombinedLocalR)) { }
                        else return;
                    }
                    Vector2 PupilPositionL;
                    if (eye_callback_registered)
                    {
                        if (SRanipal_Eye_v2.GetPupilPosition(EyeIndex.LEFT, out PupilPositionL, eyeData)) { }
                        else return;
                    }
                    else
                    {
                        if (SRanipal_Eye_v2.GetPupilPosition(EyeIndex.LEFT, out PupilPositionL)) { }
                        else return;
                    }
                    Vector2 PupilPositionR;
                    if (eye_callback_registered)
                    {
                        if (SRanipal_Eye_v2.GetPupilPosition(EyeIndex.RIGHT, out PupilPositionR, eyeData)) { }
                        else return;
                    }
                    else
                    {
                        if (SRanipal_Eye_v2.GetPupilPosition(EyeIndex.RIGHT, out PupilPositionR)) { }
                        else return;
                    }
                    Kaoposi = Camera.main.transform.position - Camera.main.transform.up * 0.05f;//恐らくゴーグルの位置,Y軸は頭の上方向、首を傾けても動作するための補正?
                    Kaomuki = Camera.main.transform.forward;
                    PupilL = PupilPositionL;
                    PupilR = PupilPositionR;

                    Vector3 GazeDirectionCombined = Camera.main.transform.TransformDirection(GazeDirectionCombinedLocal);
                    Gaze = GazeDirectionCombined;
                    GazeO = Kaoposi + Camera.main.transform.TransformDirection(GazeOriginCombinedLocal);// Combinedな視線の原点(単なる中点ではない、瞼の開き具合などによる重み含む)


                    GazeRayRenderer.SetPosition(0, GazeO + GazeDirectionCombined * 0.5f);//GazeOriginはゴーグルが基準？ GazeOから描画すると見づらい
                    GazeRayRenderer.SetPosition(1, GazeO + GazeDirectionCombined * LengthOfRay);


                    GazeL = Camera.main.transform.TransformDirection(GazeDirectionCombinedLocalL);
                    GazeR = Camera.main.transform.TransformDirection(GazeDirectionCombinedLocalR);
                    //GazeOL = Camera.main.transform.position - Camera.main.transform.up * 0.05f + Camera.main.transform.TransformDirection(GazeOriginCombinedLocalL);
                    //GazeOR = Camera.main.transform.position - Camera.main.transform.up * 0.05f + Camera.main.transform.TransformDirection(GazeOriginCombinedLocalR);
                    GazeOL = Kaoposi + Camera.main.transform.TransformDirection(GazeOriginCombinedLocalL);
                    GazeOR = Kaoposi + Camera.main.transform.TransformDirection(GazeOriginCombinedLocalR);

                    time += Time.deltaTime;
                    ray = new Ray(GazeO, GazeDirectionCombined);
                    if (Physics.Raycast(ray, out RaycastHit result, LengthOfRay))
                    {
                        if (result.collider.gameObject != kinki) 
                        {
                            rayed = result.collider.gameObject;
                            perc = 100 * time;
                            if (rayed == kinki) { rayposi = new Vector3(0, 0, 0); }
                            else { rayposi = result.point; }
                            Kasoposi = rayposi - GazeDirectionCombined * 0.01f;
                            Kaso.transform.position = Kasoposi;
                            Kaso.GetComponent<Renderer>().enabled = true;
                            Indi.GetComponent<Renderer>().enabled = true;
                            Pie.GetComponent<Renderer>().enabled = true;
                            Kaso.GetComponent<Renderer>().material.color = Color.magenta;
                            if (time > 0.0f)//待ち時間
                            {
                                Kouho = rayed;
                                perc = 100;
                            }
                            namae = rayed.name;
                        }
                        else
                        {
                            rayed = null;
                            rayposi = new Vector3(0, 0, 0);
                            time = 0.0f;
                            perc = 0.0f;
                            Kouho = null;
                            Kaso.GetComponent<Renderer>().enabled = false;
                            Indi.GetComponent<Renderer>().enabled = false;
                            Pie.GetComponent<Renderer>().enabled = false;
                        }
                    }
                    else
                    {
                        rayed = null;
                        rayposi = new Vector3(0, 0, 0);
                        time = 0.0f;
                        perc = 0.0f;
                        Kouho = null;
                        Kaso.GetComponent<Renderer>().enabled = false;
                        Indi.GetComponent <Renderer>().enabled = false;
                        Pie.GetComponent <Renderer>().enabled = false;
                    }



                }

                private void Release()
                {
                    if (eye_callback_registered == true)
                    {
                        SRanipal_Eye_v2.WrapperUnRegisterEyeDataCallback(Marshal.GetFunctionPointerForDelegate((SRanipal_Eye_v2.CallbackBasic)EyeCallback));
                        eye_callback_registered = false;
                    }
                }
                private static void EyeCallback(ref EyeData_v2 eye_data)
                {
                    eyeData = eye_data;
                }
            }
        }
    }
}
