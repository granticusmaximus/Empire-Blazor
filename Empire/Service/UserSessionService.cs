using Empire.Data;
using Empire.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Newtonsoft.Json;

namespace Empire.Service
{
    public class UserSessionService
    {
        private readonly ProtectedLocalStorage _protectedLocalStorage;
        private readonly string storageKey = "session_identity";
        private readonly ApplicationDbContext _dbContext;

        public UserSessionService(ProtectedLocalStorage protectedLocalStorage, ApplicationDbContext dbContext)
        {
            _protectedLocalStorage = protectedLocalStorage;
            _dbContext = dbContext;
        }

        public UserSession? FindUserInDatabase(string email)
        {
            var userFound = _dbContext.Users.SingleOrDefault(user => user.Email == email);
            if (userFound == null)
            {
                return null;
            }
            var newUserSession = new UserSession()
            {
                ID = userFound.Id,
                Email = userFound.Email,
                Firstname = userFound.FirstName,
                Lastname = userFound.LastName
            };
            return newUserSession;
        }

        public async Task PersistUserSessionInBrowser(UserSession userSession)
        {
            string userJson = JsonConvert.SerializeObject(userSession);
            await _protectedLocalStorage.SetAsync(storageKey, userJson);
        }

        public async Task<UserSession> FetchUserSessionFromStorage()
        {
            try
            {
                var storedSessionResult = await _protectedLocalStorage.GetAsync<string>(storageKey);

                if (storedSessionResult.Success && !string.IsNullOrEmpty(storedSessionResult.Value))
                {
                    var userSession = JsonConvert.DeserializeObject<UserSession>(storedSessionResult.Value);
                    return userSession;
                }

                return null;
            }
            catch (InvalidOperationException)
            {

            }

            return null;

        }

        public async Task ClearBrowserSessionData() => await _protectedLocalStorage.DeleteAsync(storageKey);
    }
}
