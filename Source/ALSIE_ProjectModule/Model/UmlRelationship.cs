namespace ALSIE_ProjectModule.Model
{
    public class UmlRelationship : UmlElement
    {
        private string startUmlConnectorIdentifier;
        private string endUmlConnectorIdentifier;

        public UmlRelationship(string startUmlConnectorIdentifier, string endUmlConnectorIdentifier) : base()
        {
            this.startUmlConnectorIdentifier = startUmlConnectorIdentifier;
            this.endUmlConnectorIdentifier = endUmlConnectorIdentifier;
        }

        public string GetStartUmlConnectorIdentifier()
        {
            return this.startUmlConnectorIdentifier;
        }

        public string GetEndUmlConnectorIdentifier()
        {
            return this.endUmlConnectorIdentifier;
        }
    }
}
