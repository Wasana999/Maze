using UnityEngine;

public class FallRespawn : MonoBehaviour
{
    // المكان الذي سنضع فيه نقطة البداية
    public Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        // نتحقق أن الكائن الذي سقط ولامس الأرضية هو اللاعب
        if (other.CompareTag("Player"))
        {
            // إذا كان اللاعب يستخدم CharacterController لنقل الحركة، نوقفه لحظياً للنقل
            CharacterController controller = other.GetComponent<CharacterController>();
            if (controller != null)
            {
                controller.enabled = false;
            }

            // نقل موقع اللاعب فوراً إلى نقطة البداية
            other.transform.position = spawnPoint.position;

            // إعادة تفعيل التحكم باللاعب
            if (controller != null)
            {
                controller.enabled = true;
            }
        }
    }
}