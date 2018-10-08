using System;

namespace ALSIE_ProjectModule.Model
{
    public class UmlElement
    {
        private string identidier;

        public UmlElement()
        {
            this.identidier = this.GenerateUniqueIdentifier();
        }

        private string GenerateUniqueIdentifier()
        {
            return Guid.NewGuid().ToString("N");
        }

        public string GetIdentifier()
        {
            return this.identidier;
        }
    }
}
