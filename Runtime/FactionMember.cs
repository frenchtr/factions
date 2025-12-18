using UnityEngine;

namespace TravisRFrench.Factions.Runtime
{
    public class FactionMember : MonoBehaviour
    {
        [SerializeField]
        private Faction faction;

        public IFaction Faction => this.faction;
    }
}
