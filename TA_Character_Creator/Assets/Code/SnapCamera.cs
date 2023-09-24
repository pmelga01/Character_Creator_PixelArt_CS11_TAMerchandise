using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;


[RequireComponent(typeof(Camera))]
public class SnapCamera : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void UNITY_SAVE(string content, string name, string MIMEType);
    
    [DllImport ("__Internal")]
    private static extern void UNITY_SAVE_BYTEARRAY(byte[] array, int byteLength, string name, string MIMEType);

    [DllImport("__Internal")]
    private static extern void init();

    [DllImport("__Internal")]
    private static extern bool UNITY_IS_SUPPORTED();

    static bool hasinit = false;

    public static void SaveFile(string content, string fileName, string MIMEType = "text/plain;charset=utf-8")
    {
       if (!CheckSupportAndInit()) return;

        UNITY_SAVE (content, fileName, MIMEType);
    }
    
    public static void SaveFile(byte[] content, string fileName, string MIMEType = "text/plain;charset=utf-8")
    {
        if (content == null)
        {
            Debug.LogError("null parameter passed for content byte array");
            return;
        }
        if (!CheckSupportAndInit()) return;

        UNITY_SAVE_BYTEARRAY (content, content.Length, fileName, MIMEType);
    }

    static bool CheckSupportAndInit()
    {
        if (Application.isEditor)
        {
            Debug.Log("Saving will not work in editor.");
            return false;
        }
        if (Application.platform != RuntimePlatform.WebGLPlayer)
        {
            Debug.Log("Saving must be on a WebGL build.");
            return false;
        }

        CheckInit();

        if (!IsSavingSupported())
        { 
            Debug.LogWarning("Saving is not supported on this device.");
            return false;
        }
        return true;
    }

    static void CheckInit()
    {
        if (!hasinit)
        {
            init();
            hasinit = true;
        }
    }

    public static bool IsSavingSupported()
    {
        if (Application.isEditor)
        {
            Debug.Log("Saving will not work in editor.");
            return false;
        }
        if (Application.platform != RuntimePlatform.WebGLPlayer)
        {
            Debug.Log("Saving must be on a WebGL build.");
            return false;
        }
        CheckInit();
        return UNITY_IS_SUPPORTED();
    }





    Camera snapCam;

    int resWidth = 250;
    int resHeight = 250;

    // Start is called before the first frame update

    void Start()
    {


    }

    void Awake()
    {
        snapCam = GetComponent<Camera>();
        if (snapCam.targetTexture == null) {
            snapCam.targetTexture = new RenderTexture(resWidth, resHeight, 24);
        } else {
            resWidth = snapCam.targetTexture.width;
            resHeight = snapCam.targetTexture.height;
        }

        snapCam.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        if (snapCam.gameObject.activeInHierarchy) {
            Texture2D snapshot = new Texture2D(resWidth, 
                                               resHeight, 
                                               TextureFormat.RGB24, 
                                               false);
            snapCam.Render();
            RenderTexture.active = snapCam.targetTexture;
            snapshot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            byte[] bytes = snapshot.EncodeToPNG();
            string filename = SnapshotName();

            #if UNITY_EDITOR
                System.IO.File.WriteAllBytes(filename, bytes);
            #else 
                SaveFile(bytes, filename, "image/png");
            #endif

            Debug.Log("Snapshot was taken! at: " + 
                       System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") );

            Debug.Log("The filename is: " + filename);

            snapCam.gameObject.SetActive(false);
        }
    }

    public void CallTakeSnapshot()
    {
        snapCam.gameObject.SetActive(true);

    }

    string SnapshotName()
    {
        #if UNITY_EDITOR
                return string.Format("{0}/Snapshots/snap_{1}x{2}_{3}.png", 
                            Application.dataPath, 
                            resWidth, 
                            resHeight, 
                            System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
        #else
                return string.Format("snap_{0}x{1}_{2}.png",
                            resWidth, 
                            resHeight, 
                            System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
        #endif
        
    }
}


// [DllImport("__Internal")]
// private static extern void Function();


// void Start() {
//    Function();
// }
