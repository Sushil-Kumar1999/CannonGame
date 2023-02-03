using CannonGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonGame.Interfaces;

public interface IUserDataService
{
    public IList<User> GetUsers();
    public void AddUser(User user);
}
