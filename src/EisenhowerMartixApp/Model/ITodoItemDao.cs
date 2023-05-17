namespace EisenhowerMatrixApp.src.EisenhowerMartixApp.Model
{
    public interface ITodoItemDao
    {
        /// <summary>
        /// Adds a new object to the database and sets the new ID.
        /// </summary>
        /// <param name="todoItem">A new object, with ID not yet set (null). </param>
        public void Add(TodoItem todoItem);

        /// <summary>
        /// Updates existing object's data in the database.
        /// </summary>
        /// <param name="todoItem">An object from the database, with ID already set.</param>
        public void Update(TodoItem todoItem);

        /// <summary>
        /// Get object by ID.
        /// </summary>
        /// <param name="id">ID to search by</param>
        /// <returns>An object with a given ID, or null if not found.</returns>
        public TodoItem Get(int id);

        /// <summary>
        /// Get all objects.
        /// </summary>
        /// <returns>List of all objects of this type in the database.</returns>
        public List<TodoItem> GetAll();

        /// <summary>
        /// Removes existing object's data from the database.
        /// </summary>
        /// <param name="id">ID of an object to be removed from the database.</param>
        public void Remove(int id);
    }
}
