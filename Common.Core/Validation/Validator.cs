using System;

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
    }
}