using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class display : MonoBehaviour
{
    private float fps;
    private float allocated_mem;
    private float reserved_mem;

    public TMPro.TextMeshProUGUI displayText;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("getInfo", 1, 1);
    }

    void getInfo()
    {
        fps = (int)(1f / Time.unscaledDeltaTime);
        allocated_mem = Profiler.GetTotalAllocatedMemoryLong() / 1048576;
        reserved_mem = Profiler.GetTotalReservedMemoryLong() / 1048576;

        displayText.text = "FPS: " + fps.ToString() + "\nAllocated Memory: " + allocated_mem.ToString() + "mb\nReserved Memory: " + reserved_mem.ToString() + "mb";
    }
}
