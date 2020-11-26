using System;

namespace IGSCrud.Application.Common.Validators
{
    public static class Guard
    {
        public static void AgainstNullArgument(object argValue, string argName)
        {
            if (argValue == null)
            {
                throw new ArgumentNullException(argName);
            }
        }
    }
}
