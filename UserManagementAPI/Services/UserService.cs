using UserManagementAPI.Models;

namespace UserManagementAPI.Services
{
    public class UserService
    {
        private readonly Dictionary<int, User> _users = new();
        private int _nextId = 1;

        public List<User> GetAllUsers() => new List<User>(_users.Values);

        public User? GetUserById(int id)
        {
            _users.TryGetValue(id, out var user);
            return user;
        }

        public void AddUser(User user)
        {
            user.Id = _nextId++;
            _users[user.Id] = user;
        }

        public bool UpdateUser(int id, User updatedUser)
        {
            if (!_users.ContainsKey(id)) return false;
            updatedUser.Id = id;
            _users[id] = updatedUser;
            return true;
        }

        public bool DeleteUser(int id)
        {
            return _users.Remove(id);
        }
    }
}
