using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;
using System.Linq;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // Simulating an in-memory database of users (in a real-world app, this would be a DB)
        private static List<User> users = new List<User>();

        // GET: api/users - Retrieves all users
        [HttpGet]
        public IActionResult GetUsers()
        {
            if (users.Count == 0)
            {
                return NoContent(); // Return 204 if there are no users
            }

            return Ok(users); // Return 200 with the list of users
        }

        // GET: api/users/{id} - Retrieves a user by ID
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new { error = "User not found." }); // Return 404 if not found
            }

            return Ok(user); // Return 200 with the user data
        }

        // POST: api/users - Adds a new user
        [HttpPost]
        public IActionResult PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return 400 if user data is invalid
            }

            // Simulate user ID generation (in real life, this would be done by the database)
            user.Id = users.Count + 1;
            users.Add(user);

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user); // Return 201 with created user
        }

        // PUT: api/users/{id} - Updates an existing user
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, [FromBody] User updatedUser)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new { error = "User not found." }); // Return 404 if not found
            }

            // Update user data (in a real scenario, we'd validate and possibly perform more checks here)
            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;

            return NoContent(); // Return 204 indicating successful update with no content
        }

        // DELETE: api/users/{id} - Deletes a user by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new { error = "User not found." }); // Return 404 if not found
            }

            users.Remove(user);
            return NoContent(); // Return 204 indicating successful deletion
        }
    }
}
