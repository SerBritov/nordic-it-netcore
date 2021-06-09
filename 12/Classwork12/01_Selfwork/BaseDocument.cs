using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Selfwork
{
    public class BaseDocument
    {
        protected string DocName;
        protected string DocNumber;
        protected DateTimeOffset IssueDate;
        public virtual string PropertiesString
        {
            get
            {
                return $"Name: {DocName}; Number: {DocNumber}; Issue date: {IssueDate.ToString()}";
            }
            set { }            
        }

        public void WriteToConsole()
        {
            Console.WriteLine(PropertiesString);
        }

        public BaseDocument(string name, string number, DateTimeOffset issueDate)
        {
            DocName = name;
            DocNumber = number;
            IssueDate = issueDate;
        }

        public BaseDocument()
        { }

        public virtual void SetProperties(string name, string number, DateTimeOffset issueDate)
        {
            DocName = name;
            DocNumber = number;
            IssueDate = issueDate;
        }

        public override bool Equals(object document)
        {
            return (document is BaseDocument) &&                
                ((BaseDocument)document).DocName == DocName &&
                ((BaseDocument)document).DocNumber == DocNumber &&
                ((BaseDocument)document).IssueDate == IssueDate;
        }

    }

}
