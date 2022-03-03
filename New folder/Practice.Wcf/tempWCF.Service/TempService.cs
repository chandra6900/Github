
using System;
using tempWCF.Contracts;
using tempWCF.Entities;

namespace tempWCF.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TempService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TempService.svc or TempService.svc.cs at the Solution Explorer and start debugging.
    public class TempService : ITempServiceContract
    {
        public string GetSimpleType(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public ComplexType GetComplexType(ComplexType temp)
        {
            if (temp == null)
            {
                throw new ArgumentNullException("temp");
            }
            if (temp.BoolValue)
            {
                temp.StringValue += "Suffix";
            }
            return temp;
        }
    }
}
