using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    public Texture2D cursorTextureNormal;  // 正常状态下的鼠标指针图案
    public Texture2D cursorTexturePressed; // 按下鼠标后的鼠标指针图案

    private void Start()
    {
        // 设置初始鼠标指针图案为正常状态下的图案
        Cursor.SetCursor(cursorTextureNormal, Vector2.zero, CursorMode.Auto);
    }

    private void Update()
    {
        // 检测鼠标按下事件
        if (Input.GetMouseButtonDown(0))
        {
            // 切换鼠标指针图案为按下鼠标后的图案
            Cursor.SetCursor(cursorTexturePressed, Vector2.zero, CursorMode.Auto);

            // 获取鼠标位置
            Vector2 mousePosition = Input.mousePosition;

            // 在这里编写你希望执行的代码，可以使用鼠标位置进行判断或操作
        }
        // 检测鼠标抬起事件
        else if (Input.GetMouseButtonUp(0))
        {
            // 切换鼠标指针图案为正常状态下的图案
            Cursor.SetCursor(cursorTextureNormal, Vector2.zero, CursorMode.Auto);
        }
    }
}