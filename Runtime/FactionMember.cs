using UnityEngine;

namespace Factions
{
    public class FactionMember : MonoBehaviour
    {
        [SerializeField]
        private Faction faction;

        public IFaction Faction => this.faction;
    }
}
