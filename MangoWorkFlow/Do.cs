using System;

namespace MangoWorkFlow
{
    public class DoFlow
    {
        private readonly bool _isValid;

        public DoFlow(bool isValid)
        {
            _isValid = isValid;
        }

        public DoFlow Do(Action action)
        {
            if (_isValid)
            {
                action();
            }

            return new DoFlow(_isValid);
        }
        
        public IfFlow If(Func<bool> condition)
        {
            if(condition() && _isValid)
            {
               return new IfFlow(true);
            } 

            return new IfFlow(false);
         }
    }
}
