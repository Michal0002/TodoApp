using Todo.Models;
using System.Data.SqlClient;

namespace Todo.Services
{
    public class TaskDAO
    {
        List<TaskModel> tasks = new List<TaskModel>();
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Tasks;Integrated Security=True;Connect Timeout=30;Encrypt=False;";


        public List<TaskModel> GetAllTasks()
        {
            string sqlStatement = "SELECT * FROM dbo.Tasks";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        tasks.Add(new TaskModel() { Id = (int)reader[0], Title = (string)reader[1], Description = (string)reader[2], CreatedDate = (DateTime)reader[3], DueDate = (DateTime)reader[4], Status = (string)reader[5], Priority = (string)reader[6] } );
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return tasks;
        }
        public TaskModel GetElementById(int id)
        {
            TaskModel foundItem = null;

            string sqlStatement = "SELECT * FROM dbo.Tasks WHERE Id= @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundItem = new TaskModel { Id = (int)reader[0], Title = (string)reader[1], Description = (string)reader[2], CreatedDate = (DateTime)reader[3], DueDate = (DateTime)reader[4], Status = (string)reader[5], Priority = (string)reader[6] };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return foundItem;
        }

        public TaskModel Create(TaskModel model)
        {
            string sqlStatement = "INSERT INTO dbo.Tasks (Title, Description, CreatedDate, DueDate, Status, Priority) VALUES (@Title, @Description, @CreatedDate, @DueDate, @Status, @Priority);";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Title", model.Title);
                command.Parameters.AddWithValue("@Description", model.Description);
                command.Parameters.AddWithValue("@CreatedDate", model.CreatedDate);
                command.Parameters.AddWithValue("@DueDate", model.DueDate);
                command.Parameters.AddWithValue("@Status", model.Status);
                command.Parameters.AddWithValue("@Priority", model.Priority);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return model;
        }
    }
}
