namespace DevOpsTools.Core
{
    public class DevopsService
    {
        private readonly IDevopsApi _devopsApi;

        public DevopsService(IDevopsApi devopsApi) =>
            _devopsApi = devopsApi; 
    }
}