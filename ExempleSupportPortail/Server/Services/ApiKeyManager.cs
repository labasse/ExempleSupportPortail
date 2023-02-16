namespace ExempleSupportPortail.Server.Services
{
    public class ApiKeyManager
    {
        private Guid authorized;

        public ApiKeyManager(Guid authorized) => this.authorized = authorized;

        public bool IsAuthorized(Guid key) => key == authorized;
    }
}
