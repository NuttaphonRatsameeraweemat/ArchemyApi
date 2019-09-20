namespace Archemy.Helper.Interfaces
{
    public interface IManageToken
    {
        /// <summary>
        /// Get Email from payload token.
        /// </summary>
        string Email { get; }
        /// <summary>
        /// Get Full Name from payload token.
        /// </summary>
        string EmpName { get; }
    }
}
