using System;
using System.Collections.Generic;

namespace Common.Core.Validation
{
    public static class Validator 
    {
        public static void ValidateNull(object item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), Consts.ValidationMessages.NullReference);
            }
        }

        public static void ValidateNullOrEmpty(string item)
        {
            if (string.IsNullOrEmpty(item))
            {
                throw new ArgumentNullException(nameof(item), Consts.ValidationMessages.StringNullOrEmpty);
            }
        }

        public static void ValidateCondition<TElement>(TElement element,Func<TElement,bool> condition)
        {
            bool validationResult = condition.Invoke(element);
            if (false == validationResult)
            {
                throw new Exception("Validation result of condition failed.");
            }
        }
    }
}