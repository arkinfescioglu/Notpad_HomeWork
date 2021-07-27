using PasswordHashing;

namespace Notepad.Utilities.Helpers
{
    public static class Hash
    {
        #region Hash Password

        public static string Make(string value)
        {
            return PasswordHasher.Hash(value);
        }

        #endregion

        #region Validate Hashed Password

        public static bool Check(string value, string hashedValue)
        {
            return PasswordHasher.Validate(value, hashedValue);
        }

        public static bool CheckConstraint(string value, string hashedValue)
        {
            return Check(value, hashedValue);
        }

        #endregion
    }
}