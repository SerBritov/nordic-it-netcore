using System.Security.Cryptography.X509Certificates;

namespace Classwork11
{
    
        class ButtonFactory
        {
            public bool PushOnCreate { get; set; }
            public Button CreateButton()
            {
            return new Button(PushOnCreate);
            }
        }
    
}