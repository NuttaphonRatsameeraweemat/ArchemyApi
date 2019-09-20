using Archemy.Data.Repository.EF;

namespace Archemy.Data
{
    /// <summary>
    /// ArchemyUnitOfWork class is a unit of work for manipulating about utility data in database via repository.
    /// </summary>
    public class ArchemyUnitOfWork : EfUnitOfWork<ArchemyContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArchemyUnitOfWork" /> class.
        /// </summary>
        /// <param name="helpDeskDbContext">The Archemy database context what inherits from DbContext of EF.</param>
        public ArchemyUnitOfWork(ArchemyContext archemyDbContext) : base(archemyDbContext)
        { }
    }
}
