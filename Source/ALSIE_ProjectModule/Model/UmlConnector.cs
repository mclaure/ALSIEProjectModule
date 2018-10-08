using System.Collections.Generic;

namespace ALSIE_ProjectModule.Model
{
    public class UmlConnector : UmlElement
    {
        private string umlThingIdentifier;
        private List<string> relationshipIdentifiers;

        public UmlConnector(string umlThingIdentifier) : base()
        {
            this.umlThingIdentifier = umlThingIdentifier;
            this.relationshipIdentifiers = new List<string>();
        }

        public string GetUmlThingIdentifier()
        {
            return this.umlThingIdentifier;
        }

        public bool HasUmlRelationships()
        {
            return (this.relationshipIdentifiers.Count > 0);
        }

        public void AddRelationshipIdentifer(string identifier)
        {
            this.relationshipIdentifiers.Add(identifier);
        }

        public void RemoveRelationshipIdentifier(string id)
        {
            this.relationshipIdentifiers.Remove(id);
        }
    }
}
