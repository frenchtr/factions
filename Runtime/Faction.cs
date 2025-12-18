using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace TravisRFrench.Factions.Runtime
{
    [CreateAssetMenu(menuName = "Scriptables/Faction")]
    public class Faction : ScriptableObject, IFaction
    {
        [Serializable]
        private class FactionRelationship
        {
            public Faction Faction;
            public FactionAttitude Attitude;
        }

        [SerializeField]
        private List<FactionRelationship> relationships;
        
        public FactionAttitude GetAttitudeWithFaction(IFaction faction)
        {
            var relationship = this.relationships
                .FirstOrDefault(relationship => relationship.Faction == faction);

            if (relationship == null)
            {
                return FactionAttitude.Neutral;
            }
            
            return relationship.Attitude;
        }

        #if UNITY_EDITOR
        private void OnValidate()
        {
            var factions = AssetDatabase.FindAssets("t:Faction")
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(AssetDatabase.LoadAssetAtPath<Faction>)
                .Where(faction => faction != null)
                .ToList();
            
            foreach (var faction in factions)
            {
                if (this.relationships.Any(r => r.Faction == faction))
                {
                    continue;
                }
                
                var relationship = new FactionRelationship()
                {
                    Faction = faction,
                    Attitude = FactionAttitude.Neutral,
                };
                
                this.relationships.Add(relationship);
            }
        }
        #endif
    }
}
