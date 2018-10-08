using System.Collections.Generic;

namespace ALSIE_ProjectModule.Model
{
    public class UmlDiagram
    {
        private Dictionary<string, UmlElement> umlElements;

        public UmlDiagram()
        {
            this.umlElements = new Dictionary<string, UmlElement>();
        }

        public void AddUmlElement(UmlElement umlElement)
        {
            this.umlElements.Add(umlElement.GetIdentifier(), umlElement);
        }

        public UmlElement GetUmlElement(string elementIdentifier)
        {
            return this.umlElements[elementIdentifier];
        }
    }
}
