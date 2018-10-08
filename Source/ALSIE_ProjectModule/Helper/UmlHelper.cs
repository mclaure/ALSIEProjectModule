using ALSIE_ProjectModule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALSIE_ProjectModule.Helper
{
    public static class UmlHelper
    {
        public static UmlConnector GetFirstUmlConnector(UmlThing umlThing)
        {
            Dictionary<string, UmlConnector> connectors = umlThing.GetUmlConnectors();
            var firstConnector = connectors.FirstOrDefault();
            string firstConnectorKey = firstConnector.Key;

            return umlThing.GetUmlConnector(firstConnectorKey);
        }
    }
}
