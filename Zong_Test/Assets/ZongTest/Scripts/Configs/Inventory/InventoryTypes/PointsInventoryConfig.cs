using UnityEngine;

namespace Scripts.Inventory
{
    [CreateAssetMenu(fileName = "PointsInventoryConfig" , menuName = "Configs/Inventory/PointsInventoryConfig")]
    public class PointsInventoryConfig : BaseInventoryConfig
    {
        private void Reset()
        {
            inventoryType = eInvetoryType.POINTS;
        }
    }

}
