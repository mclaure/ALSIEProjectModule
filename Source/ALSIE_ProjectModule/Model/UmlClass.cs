namespace ALSIE_ProjectModule.Model
{
    public class UmlClass : UmlThing
    {
        private static readonly int TOTAL_CONNECTORS = 4;
        public string ClassName { get; set; }

        public UmlClass(string className) : base()
        {
            this.CreateDefaultConnectors();
            this.ClassName = className;
        }

        private void CreateDefaultConnectors()
        {
            for (int i = 0; i < TOTAL_CONNECTORS; i++)
            {
                this.AddEmtyUmlConnector();
            }
        }
    }
}
