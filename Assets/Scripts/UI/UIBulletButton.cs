using UnityEngine;

public class UIBulletButton : MonoBehaviour
{
    public BulletTimeManager bulletTime;

    public void OnClick()
    {
        if (bulletTime)
            bulletTime.ToggleBulletTime();
    }
}
