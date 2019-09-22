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
        /// <summary>
        /// Get Employee id from payload token.
        /// </summary>
        int EmpId { get; }
    }
}
