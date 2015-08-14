using System;

namespace MangoWorkFlow
{
   public class IfFlow
    {
       private readonly bool _isValid;

       public IfFlow(bool isValid)
       {
           _isValid = isValid;
       }

       public IfFlow If(Func<bool> condition)
       {
           if (condition() && _isValid)
           {
               return new IfFlow(true);
           }

           return new IfFlow(false);
       }

        public DoIfFlow DoIf(Func<bool> eval, Action action)
        {
            //Check if the previous conditions were met
            if (_isValid)
            {
                if (eval())
                {
                    action();
                }
                else
                {
                    return new DoIfFlow(true, true);
                }
            }

            return new DoIfFlow(false, false);
        }

        public DoFlow Do(Action action)
       {
           if (_isValid)
           {
               action();
           }

           return new DoFlow(_isValid);
       }
    }
}
