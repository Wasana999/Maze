using UnityEngine;

public class CandleItem : MonoBehaviour
{
    [SerializeField] private string candleID = "Candle_01"; // معرّف الشمعة إذا عندك أكثر من وحدة

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // إبلاغ مدير اللاعب أن الشمعة تم أخذها
            PlayerInventory.Instance.PickUpCandle(candleID);

            // إخفاء الشمعة من المشهد بدل تدميرها لسهولة إعادة إعادة إرجاعها
            gameObject.SetActive(false);
        }
    }
}