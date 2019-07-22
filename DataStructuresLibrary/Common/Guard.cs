using System;

namespace DataStructuresLibrary.Common
{
    public static class Guard
    {
        public static void NotNull(object objectToGuard, string objectToGuardName)
        {
            if (objectToGuard == null)
            {
                throw new InvalidOperationException($"{objectToGuardName} cannot be null.");
            }
        }

        public static void ArgumentNotNull(object objectToGuard, string objectToGuardName)
        {
            if (objectToGuard == null)
            {
                throw new ArgumentNullException(objectToGuardName);
            }
        }
    }
}
