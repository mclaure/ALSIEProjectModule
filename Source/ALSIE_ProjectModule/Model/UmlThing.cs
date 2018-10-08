using System.Collections.Generic;

namespace ALSIE_ProjectModule.Model
{
    public class UmlThing : UmlElement
    {
        private Dictionary<string, UmlConnector> umlConnectors ;

        public UmlThing() : base()
        {
            this.umlConnectors  = new Dictionary<string, UmlConnector>();
        }

        protected void AddEmtyUmlConnector()
        {
            UmlConnector umlConnector = new UmlConnector(this.GetIdentifier());
            this.umlConnectors .Add(umlConnector.GetIdentifier(), umlConnector);
        }

        public Dictionary<string, UmlConnector> GetUmlConnectors()
        {
            return this.umlConnectors;
        }

        public UmlConnector GetUmlConnector(string umlConnectorIdentifier)
        {
            return this.umlConnectors [umlConnectorIdentifier];
        }
    }
}
